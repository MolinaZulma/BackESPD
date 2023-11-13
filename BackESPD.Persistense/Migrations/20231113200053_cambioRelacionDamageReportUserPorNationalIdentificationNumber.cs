using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackESPD.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class cambioRelacionDamageReportUserPorNationalIdentificationNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DamageReport_AspNetUsers_IdUser",
                table: "DamageReport");

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
                name: "NationalIdentificationNumber",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_NationalIdentificationNumber",
                table: "AspNetUsers",
                column: "NationalIdentificationNumber");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "87901e2a-b3d7-4fce-aaa8-46b0c4f0309c", null, "User", "USER" },
                    { "b74068d1-00bc-4450-9685-b6f11cd6a567", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalIdentificationNumber", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "583121cd-1937-460c-8809-5bbce66289e9", 0, "6de3a397-d4e2-4d32-b9f9-b3c97c151942", "nieves@gmail.com", false, "nieves", false, new DateTimeOffset(new DateTime(2123, 11, 13, 20, 0, 53, 135, DateTimeKind.Unspecified).AddTicks(8811), new TimeSpan(0, 0, 0, 0, 0)), "1017123111", "NIEVES@GMAIL.COM", "NIEVES@GMAIL.COM", "AQAAAAIAAYagAAAAEId5vRwT1bEdqfR6Opokql/KD0UdmwAiA7iT7zvBch+ykqHbh+toypd2IJYm40Ix/g==", "11111111", false, "fc40e0fc-7ec9-45fc-b970-5cb4c9f0b7bd", false, "nieves@gmail.com" },
                    { "5a6f583e-7c21-4349-9018-55b14c7708d9", 0, "f14cedad-e43c-4318-b5fa-9365227395e2", "esteban@gmail.com", false, "esteban", false, new DateTimeOffset(new DateTime(2123, 11, 13, 20, 0, 53, 135, DateTimeKind.Unspecified).AddTicks(8791), new TimeSpan(0, 0, 0, 0, 0)), "1017123503", "ESTEBAN@GMAIL.COM", "ESTEBAN@GMAIL.COM", "AQAAAAIAAYagAAAAEEgnwm8YY5THAgcLafO+eEu7ZoX5ensAnJFKsvOIlHpUYno/d+gHXNK+02C0wXYpuA==", "11111111", false, "51328027-b300-4c2b-b612-07b81e94fe85", false, "esteban@gmail.com" },
                    { "8910b2fd-4a8c-4ddf-a0ff-17b1f491fb2a", 0, "d2397b56-56d9-4bc3-b807-e25dcfd1c633", "mar@gmail.com", false, "mar", false, new DateTimeOffset(new DateTime(2123, 11, 13, 20, 0, 53, 135, DateTimeKind.Unspecified).AddTicks(8758), new TimeSpan(0, 0, 0, 0, 0)), "1017182914", "MAR@GMAIL.COM", "MAR@GMAIL.COM", "AQAAAAIAAYagAAAAEEZbq/VVASj/wzVb4+8P5PLzumKjB6ftd25oznOLXLx8KSjSN+tStT4hN+HvsenDkw==", "11111111", false, "4fa86e1c-354d-49b3-9278-f59c6e75fa7a", false, "mar@gmail.com" },
                    { "da775b18-1fb2-4b5b-b296-4368fe04800f", 0, "ff21d445-1890-47b7-a0d9-3ae09eecc668", "sara@gmail.com", false, "sara", false, new DateTimeOffset(new DateTime(2123, 11, 13, 20, 0, 53, 135, DateTimeKind.Unspecified).AddTicks(8803), new TimeSpan(0, 0, 0, 0, 0)), "1017123700", "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAECI0+njFsn97nW87wb7oeDmX+P4uEyXZ1qVrXM3EyTUDyOZTI6PQz/3/K78pFWXaXw==", "11111111", false, "cd27c2c8-2ace-477b-9f2b-38060ad6e3b9", false, "sara@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b74068d1-00bc-4450-9685-b6f11cd6a567", "583121cd-1937-460c-8809-5bbce66289e9" },
                    { "87901e2a-b3d7-4fce-aaa8-46b0c4f0309c", "5a6f583e-7c21-4349-9018-55b14c7708d9" },
                    { "b74068d1-00bc-4450-9685-b6f11cd6a567", "8910b2fd-4a8c-4ddf-a0ff-17b1f491fb2a" },
                    { "b74068d1-00bc-4450-9685-b6f11cd6a567", "da775b18-1fb2-4b5b-b296-4368fe04800f" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DamageReport_AspNetUsers_IdUser",
                table: "DamageReport",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "NationalIdentificationNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DamageReport_AspNetUsers_IdUser",
                table: "DamageReport");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_NationalIdentificationNumber",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b74068d1-00bc-4450-9685-b6f11cd6a567", "583121cd-1937-460c-8809-5bbce66289e9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "87901e2a-b3d7-4fce-aaa8-46b0c4f0309c", "5a6f583e-7c21-4349-9018-55b14c7708d9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b74068d1-00bc-4450-9685-b6f11cd6a567", "8910b2fd-4a8c-4ddf-a0ff-17b1f491fb2a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b74068d1-00bc-4450-9685-b6f11cd6a567", "da775b18-1fb2-4b5b-b296-4368fe04800f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87901e2a-b3d7-4fce-aaa8-46b0c4f0309c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b74068d1-00bc-4450-9685-b6f11cd6a567");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "583121cd-1937-460c-8809-5bbce66289e9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a6f583e-7c21-4349-9018-55b14c7708d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8910b2fd-4a8c-4ddf-a0ff-17b1f491fb2a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da775b18-1fb2-4b5b-b296-4368fe04800f");

            migrationBuilder.AlterColumn<string>(
                name: "NationalIdentificationNumber",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DamageReport_AspNetUsers_IdUser",
                table: "DamageReport",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
