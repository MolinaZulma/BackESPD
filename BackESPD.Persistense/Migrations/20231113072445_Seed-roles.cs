using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackESPD.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class Seedroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DescriptionDamage",
                table: "DamageReport",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "AddressDamage",
                table: "DamageReport",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "739f71a6-2661-4045-ab2c-0805686ed19c", null, "Administrator", "ADMINISTRATOR" },
                    { "d9d1fd96-421f-45dc-b24d-e5f657fcb37d", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalIdentificationNumber", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "27864f56-63c2-461b-9fc9-432b146e0c2c", 0, "b632fed7-8512-4042-a992-4bc0dc2e9b2a", "nieves@gmail.com", false, "nieves", false, new DateTimeOffset(new DateTime(2123, 11, 13, 7, 24, 45, 3, DateTimeKind.Unspecified).AddTicks(2618), new TimeSpan(0, 0, 0, 0, 0)), "1017123111", "NIEVES@GMAIL.COM", "NIEVES@GMAIL.COM", "AQAAAAIAAYagAAAAEL3tNKmRjssSUdXyGHfpyXkwvdR2fsYEXwy3ss7Roq1KRd038DsNUbaLLN+WucsTyQ==", "11111111", false, "f5f02167-ce7f-40e0-85a5-14ea4be71784", false, "nieves@gmail.com" },
                    { "671949f9-d6de-40ed-8dff-e2375898da77", 0, "2eed8265-8ff3-480d-8330-5679ab8723bb", "esteban@gmail.com", false, "esteban", false, new DateTimeOffset(new DateTime(2123, 11, 13, 7, 24, 45, 3, DateTimeKind.Unspecified).AddTicks(2599), new TimeSpan(0, 0, 0, 0, 0)), "1017123503", "ESTEBAN@GMAIL.COM", "ESTEBAN@GMAIL.COM", "AQAAAAIAAYagAAAAEEmLrvE/xpLOKPQtHp0Mcu/8/MepU2uhzkq6b5pE9hpuMFvQXVs2cSZDGvTOEKsqLw==", "11111111", false, "fc999bd3-5478-475e-9f72-304f482cd326", false, "esteban@gmail.com" },
                    { "89def332-2344-49aa-ba69-3191c58df683", 0, "400602b9-8a40-4c76-9723-27ebef894c9b", "sara@gmail.com", false, "sara", false, new DateTimeOffset(new DateTime(2123, 11, 13, 7, 24, 45, 3, DateTimeKind.Unspecified).AddTicks(2611), new TimeSpan(0, 0, 0, 0, 0)), "1017123700", "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAEACwt8MmGZl6WzB4XrD9CTjlghUSthPad7l4Uk9Bz6lOuOpLAwotZuBmHkurodgGsg==", "11111111", false, "e0754902-ed60-40bd-a302-3969c594f247", false, "sara@gmail.com" },
                    { "a26df1b9-d21d-49c4-82c2-19273db7e63d", 0, "c020a2df-daea-45b9-9955-65152ee03144", "mar@gmail.com", false, "mar", false, new DateTimeOffset(new DateTime(2123, 11, 13, 7, 24, 45, 3, DateTimeKind.Unspecified).AddTicks(2517), new TimeSpan(0, 0, 0, 0, 0)), "1017182914", "MAR@GMAIL.COM", "MAR@GMAIL.COM", "AQAAAAIAAYagAAAAEGuL/ohcKzSabSmo55ouC0dzK/liJb7SHJCbPtktWsIBZf+pt7Xgj6r6ItB8QG3THw==", "11111111", false, "958f6ef6-15b2-41b5-92db-e6acf5f56781", false, "mar@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "739f71a6-2661-4045-ab2c-0805686ed19c", "27864f56-63c2-461b-9fc9-432b146e0c2c" },
                    { "d9d1fd96-421f-45dc-b24d-e5f657fcb37d", "671949f9-d6de-40ed-8dff-e2375898da77" },
                    { "739f71a6-2661-4045-ab2c-0805686ed19c", "89def332-2344-49aa-ba69-3191c58df683" },
                    { "739f71a6-2661-4045-ab2c-0805686ed19c", "a26df1b9-d21d-49c4-82c2-19273db7e63d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "739f71a6-2661-4045-ab2c-0805686ed19c", "27864f56-63c2-461b-9fc9-432b146e0c2c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d9d1fd96-421f-45dc-b24d-e5f657fcb37d", "671949f9-d6de-40ed-8dff-e2375898da77" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "739f71a6-2661-4045-ab2c-0805686ed19c", "89def332-2344-49aa-ba69-3191c58df683" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "739f71a6-2661-4045-ab2c-0805686ed19c", "a26df1b9-d21d-49c4-82c2-19273db7e63d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "739f71a6-2661-4045-ab2c-0805686ed19c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9d1fd96-421f-45dc-b24d-e5f657fcb37d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27864f56-63c2-461b-9fc9-432b146e0c2c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "671949f9-d6de-40ed-8dff-e2375898da77");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89def332-2344-49aa-ba69-3191c58df683");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a26df1b9-d21d-49c4-82c2-19273db7e63d");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionDamage",
                table: "DamageReport",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "AddressDamage",
                table: "DamageReport",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);
        }
    }
}
