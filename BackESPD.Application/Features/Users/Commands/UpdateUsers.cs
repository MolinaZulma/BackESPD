using BackESPD.Application.DTOs.SendEmail;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BackESPD.Application.Features.Users.Commands
{
    public class ResetPassword : IRequest<GenericResponse<bool>>
    {
        public string Email { get; set; }
    }

    internal class UpdateUsersHandler : IRequestHandler<ResetPassword, GenericResponse<bool>>
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ISendEmail _sendEmail;


        public UpdateUsersHandler(UserManager<User> userManager, SignInManager<User> signInManager, ISendEmail sendEmail)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _sendEmail = sendEmail;
        }

        public async Task<GenericResponse<bool>> Handle(ResetPassword request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _userManager.FindByEmailAsync(request.Email);
                if (usuario != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);

                    Guid uuid = Guid.NewGuid();
                    string newPassword = uuid.ToString();
                    string password = newPassword.Substring(0, 5) + "ESPD*10";

                    var resultado = await _userManager.ResetPasswordAsync(usuario, token, password);

                    if (resultado.Succeeded)
                    {
                        SendEmailNewPassword(request.Email, password);
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

        public void SendEmailNewPassword(string email, string password)
        {

            var contentEmail = $"<!DOCTYPE html><html lang='en'><head><meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'><title>Document</title></head><body><p>Nueva contraseña: </p>{password}</body></html>";

            EmailDto emailDto = new EmailDto()
            {
                ForEmailUser = email,
                Subject = "Servicios Públicos Domiciliarios - Támesis le informa su nueva contraseña🔐",
                Content = contentEmail,
            };

            _sendEmail.SendEmail(emailDto);
        }
    }
}
