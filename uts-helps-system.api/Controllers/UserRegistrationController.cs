using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using uts_helps_system.api.Models;
using uts_helps_system.api.Data;
using uts_helps_system.api.Enums;
using uts_helps_system.api.Security;

namespace uts_helps_system.api.Controllers
{
    [Route("api/UserRegistrationController/")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenManager _tokenManager;
        public UserRegistrationController(ApplicationDbContext context) {
            _context = context;
            _tokenManager = new TokenManager(_context);
        }

        [Route("RegisterUser/{UserEmail}/{UserPrefFirstName}/{UserLastName}/{UserFaculty}/{UserHomePhone}/{UserMobile}/{UserBestContactNumber}/{UserDob}/{UserGenderType}/{UserAccountType}/{UserPass}")]
        public string RegisterUser(string userEmail, string userPrefFirstName, string userLastName, string userFaculty, string userHomePhone, string userMobile, string userBestContactNumber, string userDob, int userGenderType, int userAccountType, string userPass) {
            var existingUsers = _context.UserValues.Where(x => x.UserEmail == userEmail).FirstOrDefault<User>();
            if(existingUsers == null) {
                var userModel = new User {
                    UserEmail = userEmail,
                    UserPrefFirstName = userPrefFirstName,
                    UserLastName = userLastName,
                    UserFaculty = userFaculty,
                    UserHomePhone = userHomePhone,
                    UserMobile = userMobile,
                    UserBestContactNumber = userBestContactNumber,
                    UserDob = Convert.ToDateTime(userDob),
                    UserGenderType = (UserGenderType)userGenderType,
                    UserAccountType = (UserAccountType)userAccountType,
                    UserHasLoggedIn = false,
                    UserPass = HashingAlgorithms.ComputeMd5Hash(userPass),
                    UserName = $"{userPrefFirstName} {userLastName}"
                };
                _context.UserValues.Add(userModel);
                _context.SaveChanges();
                return _tokenManager.AssignToken(userModel.UserId);
            }
            return null; // Tried to register a duplicate user
        }
    }
}