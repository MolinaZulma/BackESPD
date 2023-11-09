using Microsoft.AspNetCore.Identity;

namespace BackESPD.Domain.Entities
{
    public class User : IdentityUser
    {
        public int NationalIdentificationNumber {  get; set; }
        public string FullName {  get; set; }
    }
}
