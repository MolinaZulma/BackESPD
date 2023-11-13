namespace BackESPD.Application.DTOs.Users.Account
{
    public class RegisterRequestDto
    {
        public string NationalIdentificationNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string NameRole { get; set; }
    }
}
