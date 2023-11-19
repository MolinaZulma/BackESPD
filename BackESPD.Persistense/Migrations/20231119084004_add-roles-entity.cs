using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackESPD.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class addrolesentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3bd6469b-a15d-46ed-8b74-632fb9054469", "226e37d7-7a04-47d4-9c96-315532559a52" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "adcb4d02-a7ca-4008-bfeb-76ae1dbd7cc6", "587b2f71-9f00-4afc-8d44-35c63f106684" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3bd6469b-a15d-46ed-8b74-632fb9054469", "6e08593e-99bf-4e20-bc84-5e411c1fd270" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3bd6469b-a15d-46ed-8b74-632fb9054469", "bc0887f6-fae8-4d64-9a3e-d5238daa1806" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bd6469b-a15d-46ed-8b74-632fb9054469");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adcb4d02-a7ca-4008-bfeb-76ae1dbd7cc6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "226e37d7-7a04-47d4-9c96-315532559a52");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "587b2f71-9f00-4afc-8d44-35c63f106684");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e08593e-99bf-4e20-bc84-5e411c1fd270");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0887f6-fae8-4d64-9a3e-d5238daa1806");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c347337-f25c-41b9-9777-b56d7b937f79", null, "User", "USER" },
                    { "9b0c28ca-cea3-4bce-9a0e-96b2a17af309", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalIdentificationNumber", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2f8d37bd-0cf1-4c47-9a31-b4d820f185f6", 0, "d827caeb-466c-4f8e-8ef1-a9c3ea3259fd", "esteban@gmail.com", false, "esteban", false, new DateTimeOffset(new DateTime(2123, 11, 19, 8, 40, 3, 990, DateTimeKind.Unspecified).AddTicks(7310), new TimeSpan(0, 0, 0, 0, 0)), "1017123503", "ESTEBAN@GMAIL.COM", "ESTEBAN@GMAIL.COM", "AQAAAAIAAYagAAAAEECLlYOg/VYNUrXFa1gXWJVhEL+3rbiunvUlpkYyRabp2x4uDhlQbQz4DHQMmOB/gg==", "11111111", false, "3f902ed0-ba5a-40fd-b23d-0bca489b9f2b", false, "esteban@gmail.com" },
                    { "7721ba37-bbf5-4c99-b1d1-3fc99af6f177", 0, "a18bc499-ffb2-4000-b4ff-432f00fa8220", "sara@gmail.com", false, "sara", false, new DateTimeOffset(new DateTime(2123, 11, 19, 8, 40, 3, 990, DateTimeKind.Unspecified).AddTicks(7320), new TimeSpan(0, 0, 0, 0, 0)), "1017123700", "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAEFGAJiUNjtH8qcHpnusLmXrPkXXMEV69XVijxs/TfkmzoRI9ApcZEe2QV1g7Mg2LJQ==", "11111111", false, "02235ea8-2530-461a-b940-730d3bff912c", false, "sara@gmail.com" },
                    { "9e4ed4fe-f954-4262-a7c3-df7f4d7e5950", 0, "718c63c4-56a6-4474-a59b-9518bb97ac51", "mar@gmail.com", false, "mar", false, new DateTimeOffset(new DateTime(2123, 11, 19, 8, 40, 3, 990, DateTimeKind.Unspecified).AddTicks(7284), new TimeSpan(0, 0, 0, 0, 0)), "1017182914", "MAR@GMAIL.COM", "MAR@GMAIL.COM", "AQAAAAIAAYagAAAAEBgmWgNvQAzsiLwpl4KD1KZveyNLFw1Ub6ZtbJFgbH7pt2rBO4BFeKkBlY/mmdu2Kg==", "11111111", false, "04ba140d-1d34-4223-8873-260e4f890d80", false, "mar@gmail.com" },
                    { "ecd0e666-1663-4976-a5d9-a9ef3e0db21b", 0, "c85238c4-4a36-4940-a21a-416283a43b84", "nieves@gmail.com", false, "nieves", false, new DateTimeOffset(new DateTime(2123, 11, 19, 8, 40, 3, 990, DateTimeKind.Unspecified).AddTicks(7327), new TimeSpan(0, 0, 0, 0, 0)), "1017123111", "NIEVES@GMAIL.COM", "NIEVES@GMAIL.COM", "AQAAAAIAAYagAAAAEBQ50rvPOw1GnqsTf6WsONWXCxZfXLCCj+weNqz/U1/g04RH5CIo4wUnZuLP6wHzuA==", "11111111", false, "ceecdd56-b88e-4d82-92ff-c57214b9a52f", false, "nieves@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3c347337-f25c-41b9-9777-b56d7b937f79", "2f8d37bd-0cf1-4c47-9a31-b4d820f185f6" },
                    { "9b0c28ca-cea3-4bce-9a0e-96b2a17af309", "7721ba37-bbf5-4c99-b1d1-3fc99af6f177" },
                    { "9b0c28ca-cea3-4bce-9a0e-96b2a17af309", "9e4ed4fe-f954-4262-a7c3-df7f4d7e5950" },
                    { "9b0c28ca-cea3-4bce-9a0e-96b2a17af309", "ecd0e666-1663-4976-a5d9-a9ef3e0db21b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3c347337-f25c-41b9-9777-b56d7b937f79", "2f8d37bd-0cf1-4c47-9a31-b4d820f185f6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9b0c28ca-cea3-4bce-9a0e-96b2a17af309", "7721ba37-bbf5-4c99-b1d1-3fc99af6f177" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9b0c28ca-cea3-4bce-9a0e-96b2a17af309", "9e4ed4fe-f954-4262-a7c3-df7f4d7e5950" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9b0c28ca-cea3-4bce-9a0e-96b2a17af309", "ecd0e666-1663-4976-a5d9-a9ef3e0db21b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c347337-f25c-41b9-9777-b56d7b937f79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b0c28ca-cea3-4bce-9a0e-96b2a17af309");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2f8d37bd-0cf1-4c47-9a31-b4d820f185f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7721ba37-bbf5-4c99-b1d1-3fc99af6f177");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e4ed4fe-f954-4262-a7c3-df7f4d7e5950");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ecd0e666-1663-4976-a5d9-a9ef3e0db21b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bd6469b-a15d-46ed-8b74-632fb9054469", null, "Administrator", "ADMINISTRATOR" },
                    { "adcb4d02-a7ca-4008-bfeb-76ae1dbd7cc6", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalIdentificationNumber", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "226e37d7-7a04-47d4-9c96-315532559a52", 0, "7f93035b-c4ac-4d8d-a7ca-8ae99d7ac5f7", "mar@gmail.com", false, "mar", false, new DateTimeOffset(new DateTime(2123, 11, 19, 8, 6, 48, 364, DateTimeKind.Unspecified).AddTicks(7339), new TimeSpan(0, 0, 0, 0, 0)), "1017182914", "MAR@GMAIL.COM", "MAR@GMAIL.COM", "AQAAAAIAAYagAAAAECAlyd+8NIrwMtVqC2NKN9MhfKzO9MhgKM2grt2jY7KlCxn0QlLE3FyOfwA7CSXCCQ==", "11111111", false, "7590a304-9868-4c68-a455-39b797dfb245", false, "mar@gmail.com" },
                    { "587b2f71-9f00-4afc-8d44-35c63f106684", 0, "32733da8-d531-4513-8c47-9e418b1c4cc3", "esteban@gmail.com", false, "esteban", false, new DateTimeOffset(new DateTime(2123, 11, 19, 8, 6, 48, 364, DateTimeKind.Unspecified).AddTicks(7366), new TimeSpan(0, 0, 0, 0, 0)), "1017123503", "ESTEBAN@GMAIL.COM", "ESTEBAN@GMAIL.COM", "AQAAAAIAAYagAAAAEMw4VXfYRoCGWPYy3bS4JxYhpB4jlLYSFO/wh8KJ2dAORSww2RONbkn3UdWTJ8d/JA==", "11111111", false, "b6aa9191-39af-4308-8fc1-9f82c9c80a78", false, "esteban@gmail.com" },
                    { "6e08593e-99bf-4e20-bc84-5e411c1fd270", 0, "a99c63d5-998b-4110-844a-1f697d25ba40", "sara@gmail.com", false, "sara", false, new DateTimeOffset(new DateTime(2123, 11, 19, 8, 6, 48, 364, DateTimeKind.Unspecified).AddTicks(7375), new TimeSpan(0, 0, 0, 0, 0)), "1017123700", "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAEMVBMi4rIZxyNFjep5Nz2u9E6DGm+XSb5A9KUV6e3fL3OZc4PwBqt0JPlDUhPH9hmw==", "11111111", false, "a31ea129-9184-499f-95a0-6cc25d07b47d", false, "sara@gmail.com" },
                    { "bc0887f6-fae8-4d64-9a3e-d5238daa1806", 0, "717ce815-d348-4458-be25-a07d9dd850e2", "nieves@gmail.com", false, "nieves", false, new DateTimeOffset(new DateTime(2123, 11, 19, 8, 6, 48, 364, DateTimeKind.Unspecified).AddTicks(7382), new TimeSpan(0, 0, 0, 0, 0)), "1017123111", "NIEVES@GMAIL.COM", "NIEVES@GMAIL.COM", "AQAAAAIAAYagAAAAEDHg/nownEMiXPokY/Ro1U9RPpfffNFMiyZyyLzFBzrtiS8136zLaVYhb338IImfow==", "11111111", false, "0de3b75b-61f5-48c6-831e-1d3fc75b9a52", false, "nieves@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3bd6469b-a15d-46ed-8b74-632fb9054469", "226e37d7-7a04-47d4-9c96-315532559a52" },
                    { "adcb4d02-a7ca-4008-bfeb-76ae1dbd7cc6", "587b2f71-9f00-4afc-8d44-35c63f106684" },
                    { "3bd6469b-a15d-46ed-8b74-632fb9054469", "6e08593e-99bf-4e20-bc84-5e411c1fd270" },
                    { "3bd6469b-a15d-46ed-8b74-632fb9054469", "bc0887f6-fae8-4d64-9a3e-d5238daa1806" }
                });
        }
    }
}
