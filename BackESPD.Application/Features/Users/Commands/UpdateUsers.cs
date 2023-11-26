using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BackESPD.Application.Features.Users.Commands
{
    public class UpdateUsers : IRequest<GenericResponse<bool>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    internal class UpdateUsersHandler : IRequestHandler<UpdateUsers, GenericResponse<bool>>
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UpdateUsersHandler(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<GenericResponse<bool>> Handle(UpdateUsers request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _userManager.FindByEmailAsync(request.Email);
                if (usuario != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                    var resultado = await _userManager.ResetPasswordAsync(usuario, token, request.Password);

                    if (resultado.Succeeded)
                    {
                        await _signInManager.SignOutAsync();
                        await _signInManager.SignInAsync(usuario, isPersistent: false);
                    }
                    else
                    {
                        throw new KeyNotFoundException($"Error al cambiar la contraseña {resultado.Errors} ");
                    }
                }
                else
                {
                    throw new KeyNotFoundException($"Usuario con el correo: {request.Email} no existe");
                }

                return new GenericResponse<bool>(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
