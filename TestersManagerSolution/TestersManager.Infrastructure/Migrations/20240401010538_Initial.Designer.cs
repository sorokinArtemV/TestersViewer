﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestersManager.Infrastructure.DbContext;

#nullable disable

namespace TestersManager.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240401010538_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("TestersManager.Core.Domain.Entities.DevStream", b =>
                {
                    b.Property<Guid>("DevStreamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DevStreamName")
                        .HasColumnType("TEXT");

                    b.HasKey("DevStreamId");

                    b.ToTable("DevStreams", (string)null);

                    b.HasData(
                        new
                        {
                            DevStreamId = new Guid("248a6fe4-ac09-452c-a205-a6cc4b7e9e56"),
                            DevStreamName = "Crew"
                        },
                        new
                        {
                            DevStreamId = new Guid("1a76b36b-4b06-4a69-a368-7ade27ab739e"),
                            DevStreamName = "New Year"
                        },
                        new
                        {
                            DevStreamId = new Guid("97be8c70-e9aa-41d8-9bc6-f8832c1b485a"),
                            DevStreamName = "Core"
                        },
                        new
                        {
                            DevStreamId = new Guid("02df3b54-16f9-44c7-9272-c57873f8a2ca"),
                            DevStreamName = "Tech"
                        },
                        new
                        {
                            DevStreamId = new Guid("78fd1d57-28e2-4cd8-82a3-5dfdba2a212a"),
                            DevStreamName = "Artillery"
                        });
                });

            modelBuilder.Entity("TestersManager.Core.Domain.Entities.Tester", b =>
                {
                    b.Property<Guid>("TesterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DevStreamId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<int?>("MonthsOfWorkExperience")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1)
                        .HasColumnName("WorksFor");

                    b.Property<string>("Position")
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("Skills")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("TesterName")
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.HasKey("TesterId");

                    b.HasIndex("DevStreamId");

                    b.ToTable("Testers", (string)null);

                    b.HasData(
                        new
                        {
                            TesterId = new Guid("e83987f1-e884-446c-901f-978fc909babf"),
                            BirthDate = new DateTime(1994, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DevStreamId = new Guid("248a6fe4-ac09-452c-a205-a6cc4b7e9e56"),
                            Email = "rlightman0@uol.com.br",
                            Gender = "Female",
                            MonthsOfWorkExperience = 3,
                            Position = "Middle QA",
                            Skills = "JavaScript",
                            TesterName = "Tanya Lightman"
                        },
                        new
                        {
                            TesterId = new Guid("73452c7a-4206-499c-98fa-277407c2c23d"),
                            BirthDate = new DateTime(1989, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DevStreamId = new Guid("1a76b36b-4b06-4a69-a368-7ade27ab739e"),
                            Email = "tmccard1@webster.com",
                            Gender = "Female",
                            MonthsOfWorkExperience = 30,
                            Position = "Senior QA",
                            Skills = "Python",
                            TesterName = "Tarrah McCard"
                        },
                        new
                        {
                            TesterId = new Guid("6ff4bbba-55e4-48b9-aed6-ad352d082e05"),
                            BirthDate = new DateTime(1998, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DevStreamId = new Guid("97be8c70-e9aa-41d8-9bc6-f8832c1b485a"),
                            Email = "afruish2@multiply.com",
                            Gender = "Male",
                            MonthsOfWorkExperience = 36,
                            Position = "G-ops",
                            Skills = "Frs",
                            TesterName = "Alex Fruish"
                        },
                        new
                        {
                            TesterId = new Guid("286e7c8d-759e-445a-9700-c82c15ee72c5"),
                            BirthDate = new DateTime(1999, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DevStreamId = new Guid("02df3b54-16f9-44c7-9272-c57873f8a2ca"),
                            Email = "bdanev3@posterous.com",
                            Gender = "Female",
                            MonthsOfWorkExperience = 60,
                            Position = "Senior QA",
                            Skills = "Frs",
                            TesterName = "Marie Danev"
                        },
                        new
                        {
                            TesterId = new Guid("518f9fea-bf73-497d-a76f-eec40204dafa"),
                            BirthDate = new DateTime(1995, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DevStreamId = new Guid("78fd1d57-28e2-4cd8-82a3-5dfdba2a212a"),
                            Email = "easch5@upenn.edu",
                            Gender = "Female",
                            MonthsOfWorkExperience = 52,
                            Position = "G-ops",
                            Skills = "JavaScript",
                            TesterName = "Eleonore Asch"
                        },
                        new
                        {
                            TesterId = new Guid("957b658d-ed53-484b-9f9a-6d741657decd"),
                            BirthDate = new DateTime(1989, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DevStreamId = new Guid("1a76b36b-4b06-4a69-a368-7ade27ab739e"),
                            Email = "amaty4@scribd.com",
                            Gender = "Male",
                            MonthsOfWorkExperience = 9,
                            Position = "Middle QA",
                            Skills = "CW",
                            TesterName = "Arman Maty"
                        },
                        new
                        {
                            TesterId = new Guid("3e2b5484-3a41-4f40-8126-babbfb4b4cd2"),
                            BirthDate = new DateTime(1999, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DevStreamId = new Guid("1a76b36b-4b06-4a69-a368-7ade27ab739e"),
                            Email = "apadbery6@cloudflare.com",
                            Gender = "Male",
                            MonthsOfWorkExperience = 20,
                            Position = "Junior QA",
                            Skills = "Python",
                            TesterName = "Alexander Padbery"
                        },
                        new
                        {
                            TesterId = new Guid("9b379a26-9220-4bf1-bb70-193e2ada3313"),
                            BirthDate = new DateTime(1986, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DevStreamId = new Guid("97be8c70-e9aa-41d8-9bc6-f8832c1b485a"),
                            Email = "sadame7@npr.org",
                            Gender = "Female",
                            MonthsOfWorkExperience = 14,
                            Position = "Junior QA",
                            Skills = "Python",
                            TesterName = "Shana Adame"
                        },
                        new
                        {
                            TesterId = new Guid("c3250d4a-cd91-4b73-a535-ac0e5bede0fa"),
                            BirthDate = new DateTime(1989, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DevStreamId = new Guid("02df3b54-16f9-44c7-9272-c57873f8a2ca"),
                            Email = "cmumford8@histats.com",
                            Gender = "Female",
                            MonthsOfWorkExperience = 1,
                            Position = "Intern",
                            Skills = "Blitz",
                            TesterName = "Cherish Mumford"
                        },
                        new
                        {
                            TesterId = new Guid("3c19db1f-cdf0-486f-8d85-18a481c29d76"),
                            BirthDate = new DateTime(1991, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DevStreamId = new Guid("78fd1d57-28e2-4cd8-82a3-5dfdba2a212a"),
                            Email = "jdetheridge9@msn.com",
                            Gender = "Male",
                            MonthsOfWorkExperience = 9,
                            Position = "Middle QA",
                            Skills = "JavaScript",
                            TesterName = "Jason Detheridge"
                        });
                });

            modelBuilder.Entity("TestersManager.Core.Domain.IdentityEntities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("TestersManager.Core.Domain.IdentityEntities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("TesterName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("TestersManager.Core.Domain.IdentityEntities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("TestersManager.Core.Domain.IdentityEntities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("TestersManager.Core.Domain.IdentityEntities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("TestersManager.Core.Domain.IdentityEntities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestersManager.Core.Domain.IdentityEntities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("TestersManager.Core.Domain.IdentityEntities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestersManager.Core.Domain.Entities.Tester", b =>
                {
                    b.HasOne("TestersManager.Core.Domain.Entities.DevStream", "DevStream")
                        .WithMany()
                        .HasForeignKey("DevStreamId");

                    b.Navigation("DevStream");
                });
#pragma warning restore 612, 618
        }
    }
}