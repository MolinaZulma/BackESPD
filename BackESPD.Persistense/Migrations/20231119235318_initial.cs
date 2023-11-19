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
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72bc3dbe-0748-4003-a417-bc17428af8f8", null, "IdentityRole", "User", "USER" },
                    { "85fb794d-72c2-45ad-bafd-cef83652b25f", null, "IdentityRole", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalIdentificationNumber", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3af83945-452c-42fb-9e14-4228a3dd0190", 0, "0c0ab76b-1155-429a-8fbb-b61866050123", "mar@gmail.com", false, "mar", false, new DateTimeOffset(new DateTime(2123, 11, 19, 23, 53, 17, 807, DateTimeKind.Unspecified).AddTicks(7875), new TimeSpan(0, 0, 0, 0, 0)), "1017182914", "MAR@GMAIL.COM", "MAR@GMAIL.COM", "AQAAAAIAAYagAAAAEEivLwr6V0/C0/53BsNum+e5mBvmUyiqtW/fprXc/dlw74JjlH4kxzSs2HeA0x2fxQ==", "11111111", false, "c919ef8b-088f-4a41-9561-36944a2091ac", false, "mar@gmail.com" },
                    { "7469d90b-12bb-4b26-bb1f-2babbf0f6397", 0, "3f1fcd89-9db6-4c45-b9ea-0cdc7ba1e955", "sara@gmail.com", false, "sara", false, new DateTimeOffset(new DateTime(2123, 11, 19, 23, 53, 17, 807, DateTimeKind.Unspecified).AddTicks(7917), new TimeSpan(0, 0, 0, 0, 0)), "1017123700", "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAEH/pXOdP5jFfQnom2ktfoBueDUvHPLaSzb65qjsRYgdRzxMiQVJfntQ0Untax9ERAg==", "11111111", false, "5199e14f-647c-4aad-a596-5cd3766db7a4", false, "sara@gmail.com" },
                    { "7e10e438-35c2-42c6-92c8-d0439ef357cf", 0, "2617d5ab-4d8c-4fa3-9cdb-5e55f5db2193", "nieves@gmail.com", false, "nieves", false, new DateTimeOffset(new DateTime(2123, 11, 19, 23, 53, 17, 807, DateTimeKind.Unspecified).AddTicks(7924), new TimeSpan(0, 0, 0, 0, 0)), "1017123111", "NIEVES@GMAIL.COM", "NIEVES@GMAIL.COM", "AQAAAAIAAYagAAAAEAmo/jt12m0+YYkCCbS40/SQ5Qh+jGZzWyQD3TaJMGy/Wu0G4I/wETUWecoRNJC1zw==", "11111111", false, "e715776d-944f-49c3-b163-72dac0602a52", false, "nieves@gmail.com" },
                    { "f5fa97d6-f82c-44d1-bb9a-ef4ed16fa322", 0, "aab67048-b8f5-4e4a-a7d3-fa1b9040b7b3", "esteban@gmail.com", false, "esteban", false, new DateTimeOffset(new DateTime(2123, 11, 19, 23, 53, 17, 807, DateTimeKind.Unspecified).AddTicks(7906), new TimeSpan(0, 0, 0, 0, 0)), "1017123503", "ESTEBAN@GMAIL.COM", "ESTEBAN@GMAIL.COM", "AQAAAAIAAYagAAAAEEFZ5BJ7SB56Y/0l5a/74mv2j+KiATZlW37UHcCfJh5097mVmGa40e2nPrsJhm2o9A==", "11111111", false, "6204a499-5f09-4031-b89a-06365688288a", false, "esteban@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "85fb794d-72c2-45ad-bafd-cef83652b25f", "3af83945-452c-42fb-9e14-4228a3dd0190" },
                    { "85fb794d-72c2-45ad-bafd-cef83652b25f", "7469d90b-12bb-4b26-bb1f-2babbf0f6397" },
                    { "85fb794d-72c2-45ad-bafd-cef83652b25f", "7e10e438-35c2-42c6-92c8-d0439ef357cf" },
                    { "72bc3dbe-0748-4003-a417-bc17428af8f8", "f5fa97d6-f82c-44d1-bb9a-ef4ed16fa322" }
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
