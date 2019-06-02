﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using uts_helps_system.api.Data;

namespace UTS_HELPS_System.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190602092427_Workshops-InitialSetup")]
    partial class WorkshopsInitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("uts_helps_system.api.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("UserAccountType");

                    b.Property<string>("UserBestContactNumber");

                    b.Property<DateTime>("UserDob");

                    b.Property<string>("UserEmail");

                    b.Property<string>("UserFaculty");

                    b.Property<int>("UserGenderType");

                    b.Property<bool>("UserHasLoggedIn");

                    b.Property<string>("UserHomePhone");

                    b.Property<string>("UserLastName");

                    b.Property<string>("UserMobile");

                    b.Property<string>("UserName");

                    b.Property<string>("UserPass");

                    b.Property<string>("UserPrefFirstName");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("uts_helps_system.api.Models.Workshop", b =>
                {
                    b.Property<int>("WorkshopId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("WorkshopDateTime");

                    b.Property<string>("WorkshopDesc");

                    b.Property<string>("WorkshopName");

                    b.HasKey("WorkshopId");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("uts_helps_system.api.ResourceManagement.Models.RegisteredAdminEmail", b =>
                {
                    b.Property<int>("RegistredAdminEmailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EmailHasBeenRegistered");

                    b.Property<string>("RegisteredAdminEmailAddress");

                    b.HasKey("RegistredAdminEmailId");

                    b.ToTable("RegisteredAdminEmails");
                });

            modelBuilder.Entity("uts_helps_system.api.ResourceManagement.Models.UserAccountStatus", b =>
                {
                    b.Property<int>("UserAccountStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("UserAccountConfirmed");

                    b.Property<Guid>("UserConfirmationToken");

                    b.Property<int>("UserId");

                    b.HasKey("UserAccountStatusId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserAccountStatuses");
                });

            modelBuilder.Entity("uts_helps_system.api.Security.Models.UserTokenEntry", b =>
                {
                    b.Property<int>("UserTokenEntryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("TokenId");

                    b.Property<int>("UserId");

                    b.HasKey("UserTokenEntryId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTokenEntries");
                });

            modelBuilder.Entity("uts_helps_system.api.Models.Admin", b =>
                {
                    b.HasBaseType("uts_helps_system.api.Models.User");

                    b.ToTable("Admins");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("uts_helps_system.api.Models.Student", b =>
                {
                    b.HasBaseType("uts_helps_system.api.Models.User");

                    b.Property<string>("StudentCountry");

                    b.Property<string>("StudentCourseType");

                    b.Property<int>("StudentDegreeType");

                    b.Property<int>("StudentDegreeYearType");

                    b.Property<string>("StudentLanguage");

                    b.Property<string>("StudentOtherEducationalBackground");

                    b.Property<bool>("StudentPermissionToUseData");

                    b.Property<int>("StudentStatusType");

                    b.ToTable("Students");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("uts_helps_system.api.ResourceManagement.Models.UserAccountStatus", b =>
                {
                    b.HasOne("uts_helps_system.api.Models.User")
                        .WithOne("UserAccountStatus")
                        .HasForeignKey("uts_helps_system.api.ResourceManagement.Models.UserAccountStatus", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("uts_helps_system.api.Security.Models.UserTokenEntry", b =>
                {
                    b.HasOne("uts_helps_system.api.Models.User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
