    using BackESPD.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BackESPD.Persistense.Seeds
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Crear ROLES
            List<IdentityRole> roles = new List<IdentityRole>() {
                new IdentityRole { Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                new IdentityRole { Name = "User", NormalizedName = "USER" },
                new IdentityRole { Name = "Ptap", NormalizedName = "PTAP" },
                new IdentityRole { Name = "Ptar", NormalizedName = "PTAR" }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            // Crear USERS
            List<User> users = new List<User>() {
                new User {
                    NationalIdentificationNumber = "1017182914",
                    UserName = "mar@gmail.com",
                    FullName = "mar",
                    NormalizedUserName = "MAR@GMAIL.COM",
                    Email = "mar@gmail.com",
                    NormalizedEmail = "MAR@GMAIL.COM",                                        
                    LockoutEnabled = false,
                    LockoutEnd = DateTime.UtcNow.AddYears(100),
                    PhoneNumber = "11111111"
                },
                new User {
                    NationalIdentificationNumber = "1017123503",
                    UserName = "esteban@gmail.com",
                    FullName = "esteban",
                    NormalizedUserName = "ESTEBAN@GMAIL.COM",
                    Email = "esteban@gmail.com",
                    NormalizedEmail = "ESTEBAN@GMAIL.COM",                                        
                    LockoutEnabled = false,
                    LockoutEnd = DateTime.UtcNow.AddYears(100),
                    PhoneNumber = "11111111"
                },
                new User {
                    NationalIdentificationNumber = "1017123700",
                    UserName = "sara@gmail.com",
                    FullName = "sara",
                    NormalizedUserName = "SARA@GMAIL.COM",
                    Email = "sara@gmail.com",
                    NormalizedEmail = "SARA@GMAIL.COM",                                        
                    LockoutEnabled = false,
                    LockoutEnd = DateTime.UtcNow.AddYears(100),
                    PhoneNumber = "11111111"
                },
                new User {
                    NationalIdentificationNumber = "1017123111",
                    UserName = "nieves@gmail.com",
                    FullName = "nieves",
                    NormalizedUserName = "NIEVES@GMAIL.COM",
                    Email = "nieves@gmail.com",
                    NormalizedEmail = "NIEVES@GMAIL.COM",                                        
                    LockoutEnabled = false,
                    LockoutEnd = DateTime.UtcNow.AddYears(100),
                    PhoneNumber = "11111111"
                }
            };
            modelBuilder.Entity<User>().HasData(users);

            // Agregar contraseña a los usuarios
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Admin123*");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Admin123*");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Admin123*");
            users[3].PasswordHash = passwordHasher.HashPassword(users[3], "Admin123*");

            // Agregar roles a usuario
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "PTAP").Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "User").Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[2].Id,
                RoleId = roles.First(q => q.Name == "PTAR").Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[3].Id,
                RoleId = roles.First(q => q.Name == "Administrator").Id
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

        }
    }
}
