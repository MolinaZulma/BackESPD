using BackESPD.Application.DTOs.SendEmail;

namespace BackESPD.Application.Interfaces
{
    public interface ISendEmail
    {
        void SendEmail(EmailDto emailDto);
    }
}
