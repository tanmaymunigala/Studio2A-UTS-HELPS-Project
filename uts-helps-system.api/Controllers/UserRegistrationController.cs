using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using uts_helps_system.api.Models;
using uts_helps_system.api.Data;
using uts_helps_system.api.Enums;
using uts_helps_system.api.Security;
using uts_helps_system.api.ResourceManagement;

namespace uts_helps_system.api.Controllers
{
    [Route("api/UserRegistrationController/")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenManager _tokenManager;
        private readonly UserManager _userManager;
        private readonly AdminRegistrationManager _adminRegistrationManager;
        public UserRegistrationController(ApplicationDbContext context) {
            _context = context;
            _tokenManager = new TokenManager(_context);
            _userManager = new UserManager(_context);
            _adminRegistrationManager = new AdminRegistrationManager(_context, _userManager);
        }

        [Route("RegisterUser/{UserEmail}/{UserPrefFirstName}/{UserLastName}/{UserFaculty}/{UserHomePhone}/{UserMobile}/{UserBestContactNumber}/{UserDob}/{UserGenderType}/{UserAccountType}/{UserPass}")]
        public bool RegisterUser(string userEmail, string userPrefFirstName, string userLastName, string userFaculty, string userHomePhone, string userMobile, string userBestContactNumber, string userDob, int userGenderType, int userAccountType, string userPass, int? studentCourseType = null, int? studentDegreeType = null, int? studentDegreeYearType = null, int? studentStatusType = null, string studentLanguage = null, string studentCountry = null, bool? studentPermissionToUseData = null, string studentOtherEducationalBackground = null) {
            var existingUsers = _context.UserValues.Where(x => x.UserEmail == userEmail).FirstOrDefault<User>();
            if(existingUsers == null) {
                User userModel = null;
                userModel = _userManager.GetUserModelByType(userEmail, userPrefFirstName, userLastName, userFaculty, userHomePhone, userMobile, userBestContactNumber, userDob, userGenderType, userAccountType, userPass, studentCourseType, studentDegreeType, studentDegreeYearType, studentStatusType, studentLanguage, studentCountry, studentPermissionToUseData, studentOtherEducationalBackground);
                if(userModel != null) {
                    _context.UserValues.Add(userModel);
                    _context.SaveChanges();
                    bool isSuccess = true;
                    if(userAccountType == (int)UserAccountType.Admin) {
                        isSuccess = _adminRegistrationManager.RegisterAdmin(userEmail);
                    }
                    if(isSuccess) {
                        return _userManager.SendConfirmationEmail(userEmail);
                    }
                }
            }
            return false; // Tried to register a duplicate user or registration process failed
        }

        [Route("AddAdminEmail/{adminEmail}/{tokenId}")]
        // The parameter adminEmail is the email of the NEW admin being addded! NOT the admin who is adding the new email!
        public bool AddAdminEmail(string adminEmail, string tokenId) {
            var user = _tokenManager.GetUserModelFromToken(tokenId);
            if(user != null) {
                if(user.UserAccountType == UserAccountType.Admin) {
                   return _adminRegistrationManager.AddNewAdminEmail(adminEmail);
                }
                return false; // Non admins can not add admins!
            }
            return false; // Token is invalid
        }

        [Route("ConfirmEmail/{userConfirmationToken}")]
        public string ConfirmEmail(string userConfirmationToken) {
            if(_userManager.ConfirmEmail(userConfirmationToken)) {
                var userId = _userManager.GetUserByConfirmationToken(userConfirmationToken).UserId;
                return _tokenManager.AssignToken(userId);
            }
            return null;
        }
    }
}