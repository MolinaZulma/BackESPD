﻿// <auto-generated />
using System;
using BackESPD.Persistense.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackESPD.Persistense.Migrations
{
    [DbContext(typeof(BackESPDDbContext))]
    partial class BackESPDDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackESPD.Domain.Entities.ActivityLogsForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPlant")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("TypeActivity")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("IdPlant");

                    b.HasIndex("NationalIdentificationNumber");

                    b.ToTable("ActivityLogsForm", (string)null);
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.DamageReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressDamage")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionDamage")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TrueInformation")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("TypeDamage")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NationalIdentificationNumber");

                    b.ToTable("DamageReport", (string)null);
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.FormatPTAPForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Alkaline")
                        .HasColumnType("float");

                    b.Property<double>("AlkalineChlorine")
                        .HasColumnType("float");

                    b.Property<double>("AlkalineFinalReading")
                        .HasColumnType("float");

                    b.Property<double>("AlkalineInitialReading")
                        .HasColumnType("float");

                    b.Property<double>("AlkalineTotal")
                        .HasColumnType("float");

                    b.Property<double>("AlkalinityPh")
                        .HasColumnType("float");

                    b.Property<double>("ChlorineGas")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPlant")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("ParticlesPerMillion")
                        .HasColumnType("float");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.Property<string>("TypeWater")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPlant");

                    b.HasIndex("NationalIdentificationNumber");

                    b.ToTable("FormatPTAPForm", (string)null);
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.JarFormatForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPlant")
                        .HasColumnType("int");

                    b.Property<int>("JarConcentration")
                        .HasColumnType("int");

                    b.Property<string>("JarOptime")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PhJar")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPlant");

                    b.HasIndex("NationalIdentificationNumber");

                    b.ToTable("JarFormatForm", (string)null);
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TypePlant")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Plant", (string)null);
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.SampleForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CreamWeightKilos")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPlant")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("MediumFlow")
                        .HasColumnType("float");

                    b.Property<string>("NationalIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Ph")
                        .HasColumnType("float");

                    b.Property<int>("SampleNumber")
                        .HasColumnType("int");

                    b.Property<double>("SiftingWeightKilos")
                        .HasColumnType("float");

                    b.Property<double>("TemperatureC")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdPlant");

                    b.HasIndex("NationalIdentificationNumber");

                    b.ToTable("SampleForm", (string)null);
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NationalIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "3af83945-452c-42fb-9e14-4228a3dd0190",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0c0ab76b-1155-429a-8fbb-b61866050123",
                            Email = "mar@gmail.com",
                            EmailConfirmed = false,
                            FullName = "mar",
                            LockoutEnabled = false,
                            LockoutEnd = new DateTimeOffset(new DateTime(2123, 11, 19, 23, 53, 17, 807, DateTimeKind.Unspecified).AddTicks(7875), new TimeSpan(0, 0, 0, 0, 0)),
                            NationalIdentificationNumber = "1017182914",
                            NormalizedEmail = "MAR@GMAIL.COM",
                            NormalizedUserName = "MAR@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEivLwr6V0/C0/53BsNum+e5mBvmUyiqtW/fprXc/dlw74JjlH4kxzSs2HeA0x2fxQ==",
                            PhoneNumber = "11111111",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "c919ef8b-088f-4a41-9561-36944a2091ac",
                            TwoFactorEnabled = false,
                            UserName = "mar@gmail.com"
                        },
                        new
                        {
                            Id = "f5fa97d6-f82c-44d1-bb9a-ef4ed16fa322",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "aab67048-b8f5-4e4a-a7d3-fa1b9040b7b3",
                            Email = "esteban@gmail.com",
                            EmailConfirmed = false,
                            FullName = "esteban",
                            LockoutEnabled = false,
                            LockoutEnd = new DateTimeOffset(new DateTime(2123, 11, 19, 23, 53, 17, 807, DateTimeKind.Unspecified).AddTicks(7906), new TimeSpan(0, 0, 0, 0, 0)),
                            NationalIdentificationNumber = "1017123503",
                            NormalizedEmail = "ESTEBAN@GMAIL.COM",
                            NormalizedUserName = "ESTEBAN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEEFZ5BJ7SB56Y/0l5a/74mv2j+KiATZlW37UHcCfJh5097mVmGa40e2nPrsJhm2o9A==",
                            PhoneNumber = "11111111",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6204a499-5f09-4031-b89a-06365688288a",
                            TwoFactorEnabled = false,
                            UserName = "esteban@gmail.com"
                        },
                        new
                        {
                            Id = "7469d90b-12bb-4b26-bb1f-2babbf0f6397",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3f1fcd89-9db6-4c45-b9ea-0cdc7ba1e955",
                            Email = "sara@gmail.com",
                            EmailConfirmed = false,
                            FullName = "sara",
                            LockoutEnabled = false,
                            LockoutEnd = new DateTimeOffset(new DateTime(2123, 11, 19, 23, 53, 17, 807, DateTimeKind.Unspecified).AddTicks(7917), new TimeSpan(0, 0, 0, 0, 0)),
                            NationalIdentificationNumber = "1017123700",
                            NormalizedEmail = "SARA@GMAIL.COM",
                            NormalizedUserName = "SARA@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEH/pXOdP5jFfQnom2ktfoBueDUvHPLaSzb65qjsRYgdRzxMiQVJfntQ0Untax9ERAg==",
                            PhoneNumber = "11111111",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5199e14f-647c-4aad-a596-5cd3766db7a4",
                            TwoFactorEnabled = false,
                            UserName = "sara@gmail.com"
                        },
                        new
                        {
                            Id = "7e10e438-35c2-42c6-92c8-d0439ef357cf",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2617d5ab-4d8c-4fa3-9cdb-5e55f5db2193",
                            Email = "nieves@gmail.com",
                            EmailConfirmed = false,
                            FullName = "nieves",
                            LockoutEnabled = false,
                            LockoutEnd = new DateTimeOffset(new DateTime(2123, 11, 19, 23, 53, 17, 807, DateTimeKind.Unspecified).AddTicks(7924), new TimeSpan(0, 0, 0, 0, 0)),
                            NationalIdentificationNumber = "1017123111",
                            NormalizedEmail = "NIEVES@GMAIL.COM",
                            NormalizedUserName = "NIEVES@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEAmo/jt12m0+YYkCCbS40/SQ5Qh+jGZzWyQD3TaJMGy/Wu0G4I/wETUWecoRNJC1zw==",
                            PhoneNumber = "11111111",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e715776d-944f-49c3-b163-72dac0602a52",
                            TwoFactorEnabled = false,
                            UserName = "nieves@gmail.com"
                        });
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.WaterControlForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AluminumSulfate")
                        .HasColumnType("float");

                    b.Property<double>("AmountWaterCaptured")
                        .HasColumnType("float");

                    b.Property<double>("AmountWaterSupplied")
                        .HasColumnType("float");

                    b.Property<double>("ChlorineGas")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPlant")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalIdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("ParticlesPerMillion")
                        .HasColumnType("float");

                    b.Property<double>("SodiumHypochlorite")
                        .HasColumnType("float");

                    b.Property<double>("TotalHours")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdPlant");

                    b.HasIndex("NationalIdentificationNumber");

                    b.ToTable("WaterControlForm", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = "85fb794d-72c2-45ad-bafd-cef83652b25f",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "72bc3dbe-0748-4003-a417-bc17428af8f8",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "3af83945-452c-42fb-9e14-4228a3dd0190",
                            RoleId = "85fb794d-72c2-45ad-bafd-cef83652b25f"
                        },
                        new
                        {
                            UserId = "f5fa97d6-f82c-44d1-bb9a-ef4ed16fa322",
                            RoleId = "72bc3dbe-0748-4003-a417-bc17428af8f8"
                        },
                        new
                        {
                            UserId = "7469d90b-12bb-4b26-bb1f-2babbf0f6397",
                            RoleId = "85fb794d-72c2-45ad-bafd-cef83652b25f"
                        },
                        new
                        {
                            UserId = "7e10e438-35c2-42c6-92c8-d0439ef357cf",
                            RoleId = "85fb794d-72c2-45ad-bafd-cef83652b25f"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.Roles", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("Roles");
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.ActivityLogsForm", b =>
                {
                    b.HasOne("BackESPD.Domain.Entities.Plant", "IdPlantNavigation")
                        .WithMany("ActivityLogsForm")
                        .HasForeignKey("IdPlant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackESPD.Domain.Entities.User", "IdUserNavigation")
                        .WithMany("ActivityLogsForm")
                        .HasForeignKey("NationalIdentificationNumber")
                        .HasPrincipalKey("NationalIdentificationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdPlantNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.DamageReport", b =>
                {
                    b.HasOne("BackESPD.Domain.Entities.User", "IdUserNavigation")
                        .WithMany("DamageReport")
                        .HasForeignKey("NationalIdentificationNumber")
                        .HasPrincipalKey("NationalIdentificationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.FormatPTAPForm", b =>
                {
                    b.HasOne("BackESPD.Domain.Entities.Plant", "IdPlantNavigation")
                        .WithMany("FormatPTAPForm")
                        .HasForeignKey("IdPlant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackESPD.Domain.Entities.User", "IdUserNavigation")
                        .WithMany("FormatPTAPForms")
                        .HasForeignKey("NationalIdentificationNumber")
                        .HasPrincipalKey("NationalIdentificationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdPlantNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.JarFormatForm", b =>
                {
                    b.HasOne("BackESPD.Domain.Entities.Plant", "IdPlantNavigation")
                        .WithMany("JarFormatForm")
                        .HasForeignKey("IdPlant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackESPD.Domain.Entities.User", "IdUserNavigation")
                        .WithMany("JarFormatForm")
                        .HasForeignKey("NationalIdentificationNumber")
                        .HasPrincipalKey("NationalIdentificationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdPlantNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.SampleForm", b =>
                {
                    b.HasOne("BackESPD.Domain.Entities.Plant", "IdPlantNavigation")
                        .WithMany("SampleForm")
                        .HasForeignKey("IdPlant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackESPD.Domain.Entities.User", "IdUserNavigation")
                        .WithMany("SampleForm")
                        .HasForeignKey("NationalIdentificationNumber")
                        .HasPrincipalKey("NationalIdentificationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdPlantNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.WaterControlForm", b =>
                {
                    b.HasOne("BackESPD.Domain.Entities.Plant", "IdPlantNavigation")
                        .WithMany("WaterControlForm")
                        .HasForeignKey("IdPlant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackESPD.Domain.Entities.User", "IdUserNavigation")
                        .WithMany("WaterControlForm")
                        .HasForeignKey("NationalIdentificationNumber")
                        .HasPrincipalKey("NationalIdentificationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdPlantNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BackESPD.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BackESPD.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackESPD.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BackESPD.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.Plant", b =>
                {
                    b.Navigation("ActivityLogsForm");

                    b.Navigation("FormatPTAPForm");

                    b.Navigation("JarFormatForm");

                    b.Navigation("SampleForm");

                    b.Navigation("WaterControlForm");
                });

            modelBuilder.Entity("BackESPD.Domain.Entities.User", b =>
                {
                    b.Navigation("ActivityLogsForm");

                    b.Navigation("DamageReport");

                    b.Navigation("FormatPTAPForms");

                    b.Navigation("JarFormatForm");

                    b.Navigation("SampleForm");

                    b.Navigation("WaterControlForm");
                });
#pragma warning restore 612, 618
        }
    }
}
