using System;
using System.Linq;
using uts_helps_system.api.Models;
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
                new User{
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
                    UserName = "Kirino Kousaka"
                }
            };

            foreach(User user in users) {
                context.UserValues.Add(user);
            }

            context.SaveChanges();
        }
    }
}