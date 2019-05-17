using System;
using System.Linq;
using uts_helps_system.api.Models;
using uts_helps_system.api.ResourceManagement.Models;
using uts_helps_system.api.Enums;
using Microsoft.EntityFrameworkCore;

namespace uts_helps_system.api.Data
{
    public static class DatabaseIntializer
    {
        public static void Initialize(ApplicationDbContext context) {
            
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.UserValues.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[] {
                new Student{
                    UserAccountType = UserAccountType.Student,
                    UserBestContactNumber = "09047152678",
                    UserDob = new DateTime(1999, 5, 26),
                    UserEmail = "kirino.kousaka@gmail.com",
                    UserFaculty = "Software Engineering",
                    UserGenderType = UserGenderType.Female,
                    UserHasLoggedIn = false,
                    UserHomePhone = "+810127189874",
                    UserMobile = "09047152678",
                    UserPass = "518d40970ee6490b0ebe41c0bcee3569",
                    UserPrefFirstName = "Kirino",
                    UserLastName = "Kousaka",
                    UserName = "Kirino Kousaka",
                    StudentCountry = "Japan",
                    StudentCourseType = "CO9067",
                    StudentDegreeType = StudentDegreeType.Undergraduate,
                    StudentDegreeYearType = StudentDegreeYearType.ThirdYear,
                    StudentLanguage = "Japanese",
                    StudentPermissionToUseData = true,
                    StudentStatusType = StudentStatusType.International,
                    StudentOtherEducationalBackground = "None"
                },
                new Admin {
                    UserAccountType = UserAccountType.Admin,
                    UserBestContactNumber = "09037981124",
                    UserDob = new DateTime(1998, 8, 14),
                    UserEmail = "sora.kasugano@gmail.com",
                    UserFaculty = "Software Engineering",
                    UserGenderType = UserGenderType.Female,
                    UserHasLoggedIn = false,
                    UserHomePhone = "+810128670798",
                    UserMobile = "09037981124",
                    UserPass = "2736a0eb19c2525920f8ff4af5086c0a",
                    UserPrefFirstName = "Sora",
                    UserLastName = "Kasugano",
                    UserName = "Sora Kasugano",
                }
            };

            foreach(User user in users) {
                context.UserValues.Add(user);
            }

            context.SaveChanges();

            var registeredEmails = new RegisteredAdminEmail[] {
                new RegisteredAdminEmail {
                    RegisteredAdminEmailAddress = "sora.kasugano@gmail.com",
                    EmailHasBeenRegistered = true
                },
                new RegisteredAdminEmail {
                    RegisteredAdminEmailAddress = "abella2405@gmail.com",
                    EmailHasBeenRegistered = false
                }
            };

            foreach(var registeredEmail in registeredEmails) {
                context.RegisteredAdminEmailValues.Add(registeredEmail);
            }

            var userAccountStatuses = new UserAccountStatus[] {
                new UserAccountStatus {
                    UserAccountConfirmed = true,
                    UserConfirmationToken = Guid.NewGuid(),
                    UserId = GetUserIdFromEmail("kirino.kousaka@gmail.com", users)
                },
                new UserAccountStatus {
                    UserAccountConfirmed = true,
                    UserConfirmationToken = Guid.NewGuid(),
                    UserId = GetUserIdFromEmail("sora.kasugano@gmail.com", users)
                }
            };

            foreach(var accountStatus in userAccountStatuses) {
                context.UserAccountStatusValues.Add(accountStatus);
            }

            context.SaveChanges();
        }

        public static int GetUserIdFromEmail(string userEmail, User[] userArray) {
            return userArray.Where(x => x.UserEmail.Equals(userEmail)).FirstOrDefault<User>().UserId;
        }
    }
}