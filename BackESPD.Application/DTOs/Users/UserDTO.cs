namespace BackESPD.Application.DTOs.Users
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string IdRol { get; set; }
    }
}
