using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackESPD.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NationalIdentificationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.UniqueConstraint("AK_AspNetUsers_NationalIdentificationNumber", x => x.NationalIdentificationNumber);
                });

            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TypePlant = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DamageReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressDamage = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DescriptionDamage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrueInformation = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TypeDamage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NationalIdentificationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DamageReport_AspNetUsers_NationalIdentificationNumber",
                        column: x => x.NationalIdentificationNumber,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalIdentificationNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLogsForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeActivity = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NationalIdentificationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPlant = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogsForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLogsForm_AspNetUsers_NationalIdentificationNumber",
                        column: x => x.NationalIdentificationNumber,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalIdentificationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityLogsForm_Plant_IdPlant",
                        column: x => x.IdPlant,
                        principalTable: "Plant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormatPTAPForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeWater = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    AlkalinityPh = table.Column<double>(type: "float", nullable: false),
                    AlkalineChlorine = table.Column<double>(type: "float", nullable: false),
                    AlkalineInitialReading = table.Column<double>(type: "float", nullable: false),
                    AlkalineFinalReading = table.Column<double>(type: "float", nullable: false),
                    AlkalineTotal = table.Column<double>(type: "float", nullable: false),
                    Alkaline = table.Column<double>(type: "float", nullable: false),
                    ChlorineGas = table.Column<double>(type: "float", nullable: false),
                    ParticlesPerMillion = table.Column<double>(type: "float", nullable: false),
                    NationalIdentificationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPlant = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormatPTAPForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormatPTAPForm_AspNetUsers_NationalIdentificationNumber",
                        column: x => x.NationalIdentificationNumber,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalIdentificationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormatPTAPForm_Plant_IdPlant",
                        column: x => x.IdPlant,
                        principalTable: "Plant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JarFormatForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JarConcentration = table.Column<int>(type: "int", nullable: false),
                    JarOptime = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PhJar = table.Column<int>(type: "int", nullable: false),
                    NationalIdentificationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPlant = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JarFormatForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JarFormatForm_AspNetUsers_NationalIdentificationNumber",
                        column: x => x.NationalIdentificationNumber,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalIdentificationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JarFormatForm_Plant_IdPlant",
                        column: x => x.IdPlant,
                        principalTable: "Plant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SampleForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleNumber = table.Column<int>(type: "int", nullable: false),
                    MediumFlow = table.Column<double>(type: "float", nullable: false),
                    TemperatureC = table.Column<double>(type: "float", nullable: false),
                    Ph = table.Column<double>(type: "float", nullable: false),
                    CreamWeightKilos = table.Column<double>(type: "float", nullable: false),
                    SiftingWeightKilos = table.Column<double>(type: "float", nullable: false),
                    NationalIdentificationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPlant = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleForm_AspNetUsers_NationalIdentificationNumber",
                        column: x => x.NationalIdentificationNumber,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalIdentificationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SampleForm_Plant_IdPlant",
                        column: x => x.IdPlant,
                        principalTable: "Plant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterControlForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalHours = table.Column<double>(type: "float", nullable: false),
                    AmountWaterCaptured = table.Column<double>(type: "float", nullable: false),
                    AmountWaterSupplied = table.Column<double>(type: "float", nullable: false),
                    AluminumSulfate = table.Column<double>(type: "float", nullable: false),
                    SodiumHypochlorite = table.Column<double>(type: "float", nullable: false),
                    ChlorineGas = table.Column<double>(type: "float", nullable: false),
                    ParticlesPerMillion = table.Column<double>(type: "float", nullable: false),
                    NationalIdentificationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPlant = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterControlForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterControlForm_AspNetUsers_NationalIdentificationNumber",
                        column: x => x.NationalIdentificationNumber,
                        principalTable: "AspNetUsers",
                        principalColumn: "NationalIdentificationNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaterControlForm_Plant_IdPlant",
                        column: x => x.IdPlant,
                        principalTable: "Plant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a42f37c-2f7c-46be-b7e6-5298f410c9b2", null, "Ptap", "PTAP" },
                    { "d3594500-4e63-46e4-a229-4d362caa9d4c", null, "Administrator", "ADMINISTRATOR" },
                    { "da16af62-6b8c-4f0f-b778-c20ed0b29862", null, "User", "USER" },
                    { "ec6adfd0-48c5-456d-a753-80d245e8faae", null, "Ptar", "PTAR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalIdentificationNumber", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "451fae64-a7ec-4ba5-bc97-58eea05d3818", 0, "9a0872a7-fd1d-4ef6-b73d-d820e1545d2f", "esteban@gmail.com", false, "esteban", false, new DateTimeOffset(new DateTime(2123, 11, 20, 5, 20, 31, 503, DateTimeKind.Unspecified).AddTicks(3418), new TimeSpan(0, 0, 0, 0, 0)), "1017123503", "ESTEBAN@GMAIL.COM", "ESTEBAN@GMAIL.COM", "AQAAAAIAAYagAAAAEBW++Etq3G0k/oS3TbN9RmVrmH4yYCwGuWn4hrUqbGzvWc8JFzngENjaGAYCPQ0wEw==", "11111111", false, "db893b83-389d-49cc-8178-0b6ee288535c", false, "esteban@gmail.com" },
                    { "746ba24b-13a5-4f35-8155-157227729447", 0, "5d386392-aaca-4959-bf99-33ce206c8733", "nieves@gmail.com", false, "nieves", false, new DateTimeOffset(new DateTime(2123, 11, 20, 5, 20, 31, 503, DateTimeKind.Unspecified).AddTicks(3473), new TimeSpan(0, 0, 0, 0, 0)), "1017123111", "NIEVES@GMAIL.COM", "NIEVES@GMAIL.COM", "AQAAAAIAAYagAAAAEDTq7iW/tM2X5+6HEvkWzHmya2x6MDVywwwCXaLARcFvk04b1+A3fZw140yp6QU2cA==", "11111111", false, "133547c5-6c92-4142-a05d-9e84dbc88976", false, "nieves@gmail.com" },
                    { "bba2613c-0367-4c16-973a-ac5dda299805", 0, "f215bc73-e3d0-4613-911e-6c4edba6aa79", "mar@gmail.com", false, "mar", false, new DateTimeOffset(new DateTime(2123, 11, 20, 5, 20, 31, 503, DateTimeKind.Unspecified).AddTicks(3386), new TimeSpan(0, 0, 0, 0, 0)), "1017182914", "MAR@GMAIL.COM", "MAR@GMAIL.COM", "AQAAAAIAAYagAAAAEN45SwIRc4oKawF06RF48Mia1389QYcj58hP3DoWhbf1gcdZem3tuMlos5Oz9ouClw==", "11111111", false, "41f1188d-23f1-4b91-b648-e65ae1133d9d", false, "mar@gmail.com" },
                    { "d1395217-b8db-4225-8b61-a4c6821b5996", 0, "65d4fe9d-6c54-4a8c-8d4e-f5343100a39a", "sara@gmail.com", false, "sara", false, new DateTimeOffset(new DateTime(2123, 11, 20, 5, 20, 31, 503, DateTimeKind.Unspecified).AddTicks(3426), new TimeSpan(0, 0, 0, 0, 0)), "1017123700", "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAEOfLAC2uXH4/lcdQDOypYInUYidHsV87vesjg1mRM7Qa+FoIcZP6NJPxsmAbA6WECw==", "11111111", false, "f82b2456-c349-493b-93ee-584a9deb4b45", false, "sara@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "da16af62-6b8c-4f0f-b778-c20ed0b29862", "451fae64-a7ec-4ba5-bc97-58eea05d3818" },
                    { "d3594500-4e63-46e4-a229-4d362caa9d4c", "746ba24b-13a5-4f35-8155-157227729447" },
                    { "d3594500-4e63-46e4-a229-4d362caa9d4c", "bba2613c-0367-4c16-973a-ac5dda299805" },
                    { "d3594500-4e63-46e4-a229-4d362caa9d4c", "d1395217-b8db-4225-8b61-a4c6821b5996" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogsForm_IdPlant",
                table: "ActivityLogsForm",
                column: "IdPlant");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogsForm_NationalIdentificationNumber",
                table: "ActivityLogsForm",
                column: "NationalIdentificationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DamageReport_NationalIdentificationNumber",
                table: "DamageReport",
                column: "NationalIdentificationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_FormatPTAPForm_IdPlant",
                table: "FormatPTAPForm",
                column: "IdPlant");

            migrationBuilder.CreateIndex(
                name: "IX_FormatPTAPForm_NationalIdentificationNumber",
                table: "FormatPTAPForm",
                column: "NationalIdentificationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_JarFormatForm_IdPlant",
                table: "JarFormatForm",
                column: "IdPlant");

            migrationBuilder.CreateIndex(
                name: "IX_JarFormatForm_NationalIdentificationNumber",
                table: "JarFormatForm",
                column: "NationalIdentificationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SampleForm_IdPlant",
                table: "SampleForm",
                column: "IdPlant");

            migrationBuilder.CreateIndex(
                name: "IX_SampleForm_NationalIdentificationNumber",
                table: "SampleForm",
                column: "NationalIdentificationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_WaterControlForm_IdPlant",
                table: "WaterControlForm",
                column: "IdPlant");

            migrationBuilder.CreateIndex(
                name: "IX_WaterControlForm_NationalIdentificationNumber",
                table: "WaterControlForm",
                column: "NationalIdentificationNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogsForm");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DamageReport");

            migrationBuilder.DropTable(
                name: "FormatPTAPForm");

            migrationBuilder.DropTable(
                name: "JarFormatForm");

            migrationBuilder.DropTable(
                name: "SampleForm");

            migrationBuilder.DropTable(
                name: "WaterControlForm");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Plant");
        }
    }
}
