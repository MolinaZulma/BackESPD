namespace BackESPD.Application.DTOs.SendEmail
{
    public class EmailDto
    {
        public string ForEmailUser { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
