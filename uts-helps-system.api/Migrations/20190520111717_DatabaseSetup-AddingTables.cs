using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UTS_HELPS_System.API.Migrations
{
    public partial class DatabaseSetupAddingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.CreateTable(
                name: "RegisteredAdminEmails",
                columns: table => new
                {
                    RegistredAdminEmailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisteredAdminEmailAddress = table.Column<string>(nullable: true),
                    EmailHasBeenRegistered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredAdminEmails", x => x.RegistredAdminEmailId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserEmail = table.Column<string>(nullable: true),
                    UserPrefFirstName = table.Column<string>(nullable: true),
                    UserLastName = table.Column<string>(nullable: true),
                    UserFaculty = table.Column<string>(nullable: true),
                    UserHomePhone = table.Column<string>(nullable: true),
                    UserMobile = table.Column<string>(nullable: true),
                    UserBestContactNumber = table.Column<string>(nullable: true),
                    UserDob = table.Column<DateTime>(nullable: false),
                    UserGenderType = table.Column<int>(nullable: false),
                    UserAccountType = table.Column<int>(nullable: false),
                    UserHasLoggedIn = table.Column<bool>(nullable: false),
                    UserPass = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    StudentCourseType = table.Column<string>(nullable: true),
                    StudentDegreeType = table.Column<int>(nullable: true),
                    StudentDegreeYearType = table.Column<int>(nullable: true),
                    StudentStatusType = table.Column<int>(nullable: true),
                    StudentLanguage = table.Column<string>(nullable: true),
                    StudentCountry = table.Column<string>(nullable: true),
                    StudentPermissionToUseData = table.Column<bool>(nullable: true),
                    StudentOtherEducationalBackground = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccountStatuses",
                columns: table => new
                {
                    UserAccountStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserAccountConfirmed = table.Column<bool>(nullable: false),
                    UserConfirmationToken = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountStatuses", x => x.UserAccountStatusId);
                    table.ForeignKey(
                        name: "FK_UserAccountStatuses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokenEntries",
                columns: table => new
                {
                    UserTokenEntryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TokenId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokenEntries", x => x.UserTokenEntryId);
                    table.ForeignKey(
                        name: "FK_UserTokenEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountStatuses_UserId",
                table: "UserAccountStatuses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTokenEntries_UserId",
                table: "UserTokenEntries",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisteredAdminEmails");

            migrationBuilder.DropTable(
                name: "UserAccountStatuses");

            migrationBuilder.DropTable(
                name: "UserTokenEntries");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });
        }
    }
}
