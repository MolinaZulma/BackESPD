using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackESPD.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
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
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPlant = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogsForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLogsForm_AspNetUsers_IdUser",
                        column: x => x.IdUser,
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
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPlant = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormatPTAPForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormatPTAPForm_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPlant = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JarFormatForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JarFormatForm_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPlant = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SampleForm_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdPlant = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterControlForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterControlForm_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                    { "c2843618-4d3c-4f54-bdbd-c716135a330e", null, "User", "USER" },
                    { "d3530889-f8a1-4ff6-adf9-697a37e66c1e", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalIdentificationNumber", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3a53b719-bc11-4d34-b158-7650fcae5394", 0, "b83b2abd-f48c-469f-840e-1efd35db7d18", "mar@gmail.com", false, "mar", false, new DateTimeOffset(new DateTime(2123, 11, 19, 4, 4, 1, 822, DateTimeKind.Unspecified).AddTicks(7283), new TimeSpan(0, 0, 0, 0, 0)), "1017182914", "MAR@GMAIL.COM", "MAR@GMAIL.COM", "AQAAAAIAAYagAAAAEH9vZuVOq5ZjQI3T89HA+SVb3OPLvKjBLquGxc7MHKvs3Hnsp9IfdQHW92eua83ASw==", "11111111", false, "65b31175-7f5d-4363-bbdb-4bf51de01679", false, "mar@gmail.com" },
                    { "87e241e3-cd79-4816-8211-9308e9aa262f", 0, "fb9ed3e3-6de3-445a-bea7-003941e66637", "esteban@gmail.com", false, "esteban", false, new DateTimeOffset(new DateTime(2123, 11, 19, 4, 4, 1, 822, DateTimeKind.Unspecified).AddTicks(7323), new TimeSpan(0, 0, 0, 0, 0)), "1017123503", "ESTEBAN@GMAIL.COM", "ESTEBAN@GMAIL.COM", "AQAAAAIAAYagAAAAEOAd74Hyx7vDfh1r5wDrQquzugqPeLu25ZaMdupRnaXfMLqjoLHVCfipMPooVFP1DA==", "11111111", false, "0e6e70eb-021d-4188-bf47-d552b90dfe1f", false, "esteban@gmail.com" },
                    { "8aca8312-84b6-410e-8e48-fb79fa8d4cd6", 0, "73ede30a-7e50-49ea-abda-bc36854aa200", "nieves@gmail.com", false, "nieves", false, new DateTimeOffset(new DateTime(2123, 11, 19, 4, 4, 1, 822, DateTimeKind.Unspecified).AddTicks(7340), new TimeSpan(0, 0, 0, 0, 0)), "1017123111", "NIEVES@GMAIL.COM", "NIEVES@GMAIL.COM", "AQAAAAIAAYagAAAAEFmDtl1bK549sCn6ZrPfbyKJGj8nvU54AiThQBXz8N3yf6XpoB49NhSCURHGZcJMAw==", "11111111", false, "3f13ece7-2a32-498d-bb15-0751cbf50c90", false, "nieves@gmail.com" },
                    { "a42921d9-ae8e-49c3-ab07-9038b41e58ed", 0, "dc79bd80-77c5-405b-a92b-799b78d74089", "sara@gmail.com", false, "sara", false, new DateTimeOffset(new DateTime(2123, 11, 19, 4, 4, 1, 822, DateTimeKind.Unspecified).AddTicks(7333), new TimeSpan(0, 0, 0, 0, 0)), "1017123700", "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAEFHILKE3GEQ7gdJBwjVvhpCKmrXHbzh5pxuexeZ2QJIhRjZ7maws5vXh7ylW4ukvtw==", "11111111", false, "9629340c-35ad-405f-b5b9-8f379dbabd5e", false, "sara@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d3530889-f8a1-4ff6-adf9-697a37e66c1e", "3a53b719-bc11-4d34-b158-7650fcae5394" },
                    { "c2843618-4d3c-4f54-bdbd-c716135a330e", "87e241e3-cd79-4816-8211-9308e9aa262f" },
                    { "d3530889-f8a1-4ff6-adf9-697a37e66c1e", "8aca8312-84b6-410e-8e48-fb79fa8d4cd6" },
                    { "d3530889-f8a1-4ff6-adf9-697a37e66c1e", "a42921d9-ae8e-49c3-ab07-9038b41e58ed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogsForm_IdPlant",
                table: "ActivityLogsForm",
                column: "IdPlant",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogsForm_IdUser",
                table: "ActivityLogsForm",
                column: "IdUser");

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
                column: "IdPlant",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormatPTAPForm_IdUser",
                table: "FormatPTAPForm",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_JarFormatForm_IdPlant",
                table: "JarFormatForm",
                column: "IdPlant",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JarFormatForm_IdUser",
                table: "JarFormatForm",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_SampleForm_IdPlant",
                table: "SampleForm",
                column: "IdPlant",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SampleForm_IdUser",
                table: "SampleForm",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_WaterControlForm_IdPlant",
                table: "WaterControlForm",
                column: "IdPlant",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaterControlForm_IdUser",
                table: "WaterControlForm",
                column: "IdUser");
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
