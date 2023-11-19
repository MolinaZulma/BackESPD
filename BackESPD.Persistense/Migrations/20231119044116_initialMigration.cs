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
                    { "819c9655-f11d-4da8-94b3-20f7588ae38b", null, "Administrator", "ADMINISTRATOR" },
                    { "ea97dd5a-634b-435c-94ca-184a69474aa0", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NationalIdentificationNumber", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "58e96ed3-d011-48ee-8515-29648530d978", 0, "d9928be4-6bec-4e24-a4b9-7418dc3ec587", "esteban@gmail.com", false, "esteban", false, new DateTimeOffset(new DateTime(2123, 11, 19, 4, 41, 16, 319, DateTimeKind.Unspecified).AddTicks(9603), new TimeSpan(0, 0, 0, 0, 0)), "1017123503", "ESTEBAN@GMAIL.COM", "ESTEBAN@GMAIL.COM", "AQAAAAIAAYagAAAAEP3RSp9QsydGsua4xdWh9WqEzSCO6kYTco4jvv+yIh0C/zEfusjnPkbmB+syVRezTw==", "11111111", false, "6c4efabc-45c4-42ef-b9db-740c378ef444", false, "esteban@gmail.com" },
                    { "baa27d2d-072c-44fd-b5b7-57fed1e51ba8", 0, "e9b9b0c2-2854-412b-9f02-ed81234cc0ad", "sara@gmail.com", false, "sara", false, new DateTimeOffset(new DateTime(2123, 11, 19, 4, 41, 16, 319, DateTimeKind.Unspecified).AddTicks(9610), new TimeSpan(0, 0, 0, 0, 0)), "1017123700", "SARA@GMAIL.COM", "SARA@GMAIL.COM", "AQAAAAIAAYagAAAAEIQz7XmsHb/YbtchjVZOPCb2GfURlzYQcYEWppSQKL7Ii76WDY83j9LBaQk8u1dPfw==", "11111111", false, "2a4e317f-6138-4478-9860-7982128bd42f", false, "sara@gmail.com" },
                    { "c047b370-9034-4a1a-9c0f-855af92c7a85", 0, "9c6e0226-a369-4ecd-b74e-0ed313c1086e", "nieves@gmail.com", false, "nieves", false, new DateTimeOffset(new DateTime(2123, 11, 19, 4, 41, 16, 319, DateTimeKind.Unspecified).AddTicks(9617), new TimeSpan(0, 0, 0, 0, 0)), "1017123111", "NIEVES@GMAIL.COM", "NIEVES@GMAIL.COM", "AQAAAAIAAYagAAAAEN95NfhK1zxKZHhtrZRX1bJa7ew2MjV6Rb/Yp4fxQHl4JNqW3JQt4ufEtt8O3uPrwg==", "11111111", false, "c61945e4-df68-47bc-a435-8c2dde42ac55", false, "nieves@gmail.com" },
                    { "cd1309ba-1ccc-43a0-ab49-c16c13802532", 0, "1e2ccdaf-f50e-4fa9-8596-33207590eb64", "mar@gmail.com", false, "mar", false, new DateTimeOffset(new DateTime(2123, 11, 19, 4, 41, 16, 319, DateTimeKind.Unspecified).AddTicks(9560), new TimeSpan(0, 0, 0, 0, 0)), "1017182914", "MAR@GMAIL.COM", "MAR@GMAIL.COM", "AQAAAAIAAYagAAAAEMXDWmLncqDqz94HSAi7YXr3cA09v6+Pu5nbQ39Vg/6laipQQ59RXr5yOHP9lOLFiA==", "11111111", false, "e7603ba0-f86c-455d-a37f-29d3d04f2ab0", false, "mar@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "ea97dd5a-634b-435c-94ca-184a69474aa0", "58e96ed3-d011-48ee-8515-29648530d978" },
                    { "819c9655-f11d-4da8-94b3-20f7588ae38b", "baa27d2d-072c-44fd-b5b7-57fed1e51ba8" },
                    { "819c9655-f11d-4da8-94b3-20f7588ae38b", "c047b370-9034-4a1a-9c0f-855af92c7a85" },
                    { "819c9655-f11d-4da8-94b3-20f7588ae38b", "cd1309ba-1ccc-43a0-ab49-c16c13802532" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogsForm_IdPlant",
                table: "ActivityLogsForm",
                column: "IdPlant",
                unique: true);

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
