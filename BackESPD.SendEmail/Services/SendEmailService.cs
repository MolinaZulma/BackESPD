using BackESPD.Application.DTOs.SendEmail;
using BackESPD.Application.Interfaces;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace BackESPD.SendEmail.Services
{
    public class SendEmailService : ISendEmail
    {
        private readonly IConfiguration configuration;

        public SendEmailService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public void SendEmail(EmailDto emailDto)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(configuration.GetSection("SendEmail:Username").Value));
            email.To.Add(MailboxAddress.Parse(emailDto.ForEmailUser));
            email.Subject = emailDto.Subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = emailDto.Content
            };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(
                configuration.GetSection("SendEmail:Host").Value,
                Convert.ToInt32(configuration.GetSection("SendEmail:Port").Value),
                SecureSocketOptions.StartTls);

            smtp.Authenticate(
                configuration.GetSection("SendEmail:Username").Value,
                configuration.GetSection("SendEmail:Password").Value
                );

            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
