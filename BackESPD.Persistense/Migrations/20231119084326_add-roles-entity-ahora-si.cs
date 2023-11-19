using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackESPD.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class addrolesentityahorasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95f1c2ff-7ef9-4a50-823e-c3954d11be24", null, "IdentityRole", "User", "USER" },
                    { "cebfd97f-beeb-4db4-9eb6-814882a43b8c", null, "IdentityRole", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalIdentificationNumber", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0131740f-7143-4c29-8eae-70f10dfb39a4", 0, "b1cc0c13-61fd-4100-a3a7-26264a751a74", "esteban@gmail.com", false, "esteban", false, new DateTimeOffset(new DateTime(2123, 11, 19, 8, 43, 25, 607, DateTimeKind.Unspecified).AddTicks(5212), new TimeSpan(0, 0, 0, 0, 0)), "1017123503", "ESTEBAN@GMAIL.COM", "ESTEBAN@GMAIL.COM", "AQAAAAIAAYagAAAAECHLbSONWOrv5f3SrrPYqjUa52gadpVle03ZeknsmA6PPoTq7hCzcmw/VsXhWm5WQQ==", "11111111", false, "d96bb914-5bd7-4d18-bec4-18f45d7de386", false, "esteban@gmail.com" },
                    { "8b999a6e-3070-4caf-aca4-90bb1ab0d389", 0, "b912d791-e7a3-439e-b7d6-c88c8b888bef", "mar@gmail.com", false, "mar", false, new DateTimeOffset(new DateTime(2123, 11, 19, 8, 43, 25, 607, DateTimeKind.Unspecified).AddTicks(5179), new TimeSpan(0, 0, 0, 0, 0)), "1017182914", "MAR@GMAIL.COM", "MAR@GMAIL.COM", "AQAAAAIAAYagAAAAEIKkmBAR0NlwVf3QVj8M5FIyFj6AIn9xVUDoz7uxVBz4qXlLSGGyImjUaKj0F93MfA==", "11111111", false, "da4c3c89-3a67-45a0-b0b3-349f8d03657c", false, "mar@gmail.com" },
                    { "8f7544bb-4498-4d8c-899b-dcf2188bd0a3", 0, "9815a7a2-9295-4dce-ba33-5b18ceb29b09", "sara@gmail.com", false, "sara", false, new DateTimeOffset(new DateTime(2123, 11, 19, 8, 43, 25, 607, DateTimeKind.Unspecified).AddTicks(5221), new TimeSpan(0, 0, 0, 0, 0)), "1017123700", "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAEO0m457yMZ3e+oX8iZNqJEJUmJICYR7itcMtgpsnrOrUod/eMqmhOE0pbHCRCvrXuQ==", "11111111", false, "f8b9428b-6215-4852-90cd-5d8a69955736", false, "sara@gmail.com" },
                    { "e434caed-72ea-48aa-ad0c-96bef429c20c", 0, "9a9e5213-845b-475b-a191-40910e4868b4", "nieves@gmail.com", false, "nieves", false, new DateTimeOffset(new DateTime(2123, 11, 19, 8, 43, 25, 607, DateTimeKind.Unspecified).AddTicks(5229), new TimeSpan(0, 0, 0, 0, 0)), "1017123111", "NIEVES@GMAIL.COM", "NIEVES@GMAIL.COM", "AQAAAAIAAYagAAAAEBRYXwEo3shEbO7LBsKFbzyKwPVPaDIb2GsQEsKwFWR4XAOXiw7gOj7sUUxylkTPSg==", "11111111", false, "164763ed-b4be-4fc1-89fc-f2297c695390", false, "nieves@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "95f1c2ff-7ef9-4a50-823e-c3954d11be24", "0131740f-7143-4c29-8eae-70f10dfb39a4" },
                    { "cebfd97f-beeb-4db4-9eb6-814882a43b8c", "8b999a6e-3070-4caf-aca4-90bb1ab0d389" },
                    { "cebfd97f-beeb-4db4-9eb6-814882a43b8c", "8f7544bb-4498-4d8c-899b-dcf2188bd0a3" },
                    { "cebfd97f-beeb-4db4-9eb6-814882a43b8c", "e434caed-72ea-48aa-ad0c-96bef429c20c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "95f1c2ff-7ef9-4a50-823e-c3954d11be24", "0131740f-7143-4c29-8eae-70f10dfb39a4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cebfd97f-beeb-4db4-9eb6-814882a43b8c", "8b999a6e-3070-4caf-aca4-90bb1ab0d389" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cebfd97f-beeb-4db4-9eb6-814882a43b8c", "8f7544bb-4498-4d8c-899b-dcf2188bd0a3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cebfd97f-beeb-4db4-9eb6-814882a43b8c", "e434caed-72ea-48aa-ad0c-96bef429c20c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95f1c2ff-7ef9-4a50-823e-c3954d11be24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cebfd97f-beeb-4db4-9eb6-814882a43b8c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0131740f-7143-4c29-8eae-70f10dfb39a4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b999a6e-3070-4caf-aca4-90bb1ab0d389");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f7544bb-4498-4d8c-899b-dcf2188bd0a3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e434caed-72ea-48aa-ad0c-96bef429c20c");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

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
    }
}
