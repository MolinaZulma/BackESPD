using BackESPD.Application.DTOs.Users.Account;
using BackESPD.Application.Exceptions;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using BackESPD.Domain.Settings;
using BackESPD.Persistense.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BackESPD.Persistense.Services
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JWTSettings _jwtSettings;
        private readonly IDateTimeService _dateTimeService;

        public AccountService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IOptions<JWTSettings> jwtSettings, IDateTimeService dateTimeService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _dateTimeService = dateTimeService;
        }

        public async Task<GenericResponse<AuthenticationResponseDto>> AuthenticateAsync(AuthenticationRequestDto request, string ipAddress)
        {
            var usuario = await _userManager.FindByEmailAsync(request.Email);
            if (usuario is null)
            {
                throw new ApiException($"No hay una cuenta registrada con el email {request.Email}.");
            }
            var result = await _signInManager.PasswordSignInAsync(usuario.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new ApiException($"Las credenciales del usuario no son validas  {request.Email}.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJwtToken(usuario);
            AuthenticationResponseDto authenticationResponse = new AuthenticationResponseDto();
            authenticationResponse.Id = usuario.Id;
            authenticationResponse.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authenticationResponse.Email = usuario.Email;
            authenticationResponse.UserName = usuario.UserName;
            authenticationResponse.NationalIdentificationNumber = usuario.NationalIdentificationNumber;

            var rolesList = await _userManager.GetRolesAsync(usuario).ConfigureAwait(false);
            authenticationResponse.Roles = rolesList.ToList();
            authenticationResponse.IsVerified = true; //revisar, deberia ir linea de abajo
            //authenticationResponse.IsVerified = usuario.EmailConfirmed;

            var refreshToken = GenerateRefreshToken(ipAddress);
            authenticationResponse.RefreshToken = refreshToken.Token;
            return new GenericResponse<AuthenticationResponseDto>(authenticationResponse, $"Usuario Autenticado {usuario.UserName}");
        }

        private async Task<JwtSecurityToken> GenerateJwtToken(User usuario)
        {
            var userClaims = await _userManager.GetClaimsAsync(usuario);
            var roles = await _userManager.GetRolesAsync(usuario);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            string ipAddres = IpHelper.GetIpAddress();
            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, usuario.UserName),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim("uid", usuario.Id),
                new Claim("ip", ipAddres),
                new Claim("NationalIdentificationNumber", usuario.NationalIdentificationNumber)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }

        public async Task<GenericResponse<string>> RegisterAsync(RegisterRequestDto request, string origin)
        {
            var usuarioConElMismoUserName = await _userManager.FindByNameAsync(request.UserName);
            if (usuarioConElMismoUserName != null)
            {
                throw new ApiException($"El nombre de usuario {request.UserName} ya fue registrado previamente.");
            }
            User usuario = new User
            {

                NationalIdentificationNumber = request.NationalIdentificationNumber,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                FullName = request.FullName,
                UserName = request.UserName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
                LockoutEnd = DateTime.UtcNow.AddYears(100),
            };


            var usuarioConElMismoCorreo = await _userManager.FindByEmailAsync(request.Email);
            if (usuarioConElMismoCorreo != null)
            {
                throw new ApiException($"El email {request.Email} ya fue registrado previamente.");
            }
            else
            {
                try
                {
                    var result = await _userManager.CreateAsync(usuario, request.Password);
                    if (result.Succeeded)
                    {
                        //if (await _roleManager.RoleExistsAsync(request.NameRole))
                        //{
                        await _userManager.AddToRoleAsync(usuario, request.NameRole.ToString());
                        //await _userManager.AddToRoleAsync(usuario, Roles.User.ToString());
                        return new GenericResponse<string>(usuario.Id, message: $"Usuario registrado exitosamente. {request.UserName}, rol {request.NameRole}");
                        //}
                    }
                    else
                    {
                        throw new ApiException($"{result.Errors}.");
                    }

                }
                catch (Exception ex)
                {
                    // Asigna un mensaje de error personalizado a la excepción.
                    throw new Exception("Ocurrió un error al crear el usuario: " + ex.Message);
                }
            }
        }

        public RefreshTokenDto GenerateRefreshToken(string ipAddress)
        {
            return new RefreshTokenDto
            {
                Token = RandomTokenString(),
                Expires = DateTime.Now.AddDays(1),
                Created = DateTime.Now,
                CreatedByIp = ipAddress
            };
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}
