using BackESPD.Application.DTOs.SendEmail;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackESPD.Application.Features.Users.Commands.RecoverPassword
{
    public class RecoverPasswordCommand : IRequest<GenericResponse<bool>>
    {
        public string ForEmailUser { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }

    internal class RecoverPasswordCommandHandler : IRequestHandler<RecoverPasswordCommand, GenericResponse<bool>>
    {
        private readonly ISendEmail _sendEmail;

        public RecoverPasswordCommandHandler(ISendEmail sendEmail)
        {
            _sendEmail = sendEmail;
        }

        public async Task<GenericResponse<bool>> Handle(RecoverPasswordCommand request, CancellationToken cancellationToken)
        {
            var baseUrl = "https://translate.google.com/";

            var contentEmail = $"<!DOCTYPE html><html lang='en'><head><meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'><title>Document</title></head><body><p>Hola Humano este mensaje es para que recuperes tu contrase;a por olvidad@ no siendo mas puedes reestablecerla 😑😑😑😑😖🙁🙁</p><img src=`https://uploads-ssl.webflow.com/63634f4a7b868a399577cf37/63e10adfa64a34de9592b9a3_nombres%20para%20perritos%20blancos.jpg` alt='perrito' style='height: 50px; height: 50px;'><span style='background-color: fuchsia;'>${baseUrl}</span></body></html>";

            //--------------------------------------------
            EmailDto emailDto = new EmailDto()
            {
                ForEmailUser = request.ForEmailUser,
                Subject = request.Subject,
                Content = contentEmail,
            };

            _sendEmail.SendEmail(emailDto);

            return new GenericResponse<bool>(true);
        }
    }
}
