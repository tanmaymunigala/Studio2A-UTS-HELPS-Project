using System;
using uts_helps_system.api.Models;
using uts_helps_system.api.Enums;
using uts_helps_system.api.Data;
using uts_helps_system.api.Security;
using uts_helps_system.api.ResourceManagement.Models;
using System.Linq;
using System.IO;

namespace uts_helps_system.api.ResourceManagement
{
    public class UserManager
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailTemplateManager _emailTemplateManager;

        public UserManager(ApplicationDbContext context) {
            _context = context;
            _emailTemplateManager = new EmailTemplateManager();
        }

        public bool SendConfirmationEmail(string userAddress) {
            var user = GetUserByEmail(userAddress);
            string address = $@"{CentralResourceManagement.ConfirmRegistrationUrl}{GenerateConfirmationToken(user.UserId)}";
            var userConfirmationStatus = _context.UserAccountStatusValues.Where(x => x.UserId == user.UserId).FirstOrDefault<UserAccountStatus>();
            if (!_emailTemplateManager.SendConfirmRegistrationEmail(userAddress, "Welcome, Please Confirm Your Email!", "Click here to confirm your email", address, $"Email Confirmation for {user.UserName}")) {
                RollbackUserRegistration(user);
                return false;
            }
            return true;
        }

        public User GetUserModelByType(string userEmail, string userPrefFirstName, string userLastName, string userFaculty, string userHomePhone, string userMobile, string userBestContactNumber, string userDob, int userGenderType, int userAccountType, string userPass, string studentCourseType = null, int? studentDegreeType = null, int? studentDegreeYearType = null, int? studentStatusType = null, string studentLanguage = null, string studentCountry = null, bool? studentPermissionToUseData = null, string studentOtherEducationalBackground = null) {
            try {
                var userTypeEnum = (UserAccountType)userAccountType;
                switch(userTypeEnum) {
                    case UserAccountType.Student: return GetStudentAccount(userEmail, userPrefFirstName, userLastName, userFaculty, userHomePhone, userMobile, userBestContactNumber, userDob, userGenderType, userAccountType, userPass, studentCourseType, (int)studentDegreeType, (int)studentDegreeYearType, (int)studentStatusType, studentLanguage, studentCountry, (bool)studentPermissionToUseData, studentOtherEducationalBackground);
                    case UserAccountType.Admin: return GetAdminAccount(userEmail, userPrefFirstName, userLastName, userFaculty, userHomePhone, userMobile, userBestContactNumber, userDob, userGenderType, userAccountType, userPass);
                    default: return null;
                }
            } catch(Exception) {
                return null;
            }
        }

        private Student GetStudentAccount(string userEmail, string userPrefFirstName, string userLastName, string userFaculty, string userHomePhone, string userMobile, string userBestContactNumber, string userDob, int userGenderType, int userAccountType, string userPass, string studentCourseType, int studentDegreeType, int studentDegreeYearType, int studentStatusType, string studentLanguage, string studentCountry, bool studentPermissionToUseData, string studentOtherEducationalBackground) {
            Student studentModel = new Student() {
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
                UserName = $"{userPrefFirstName} {userLastName}",
                StudentCourseType = studentCourseType,
                StudentDegreeType = (StudentDegreeType)studentDegreeType,
                StudentDegreeYearType = (StudentDegreeYearType)studentDegreeYearType,
                StudentStatusType = (StudentStatusType)studentStatusType,
                StudentLanguage = studentLanguage,
                StudentCountry = studentCountry,
                StudentPermissionToUseData = studentPermissionToUseData,
                StudentOtherEducationalBackground = studentOtherEducationalBackground
            };
            return studentModel;
        }

        private Admin GetAdminAccount(string userEmail, string userPrefFirstName, string userLastName, string userFaculty, string userHomePhone, string userMobile, string userBestContactNumber, string userDob, int userGenderType, int userAccountType, string userPass) {
            Admin adminModel = new Admin() {
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
            return adminModel;
        }

        public bool RollbackUserRegistration(User userModel) {
            if(userModel != null) {
                var userAccountStatus = _context.UserAccountStatusValues.Where(x => x.UserId == userModel.UserId).FirstOrDefault<UserAccountStatus>();
                if(userAccountStatus != null) {
                    _context.UserAccountStatusValues.Remove(userAccountStatus);
                }
                _context.UserValues.Remove(userModel);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public User GetUserByConfirmationToken(string userConfirmationToken) {
            var userConfirmationStatus = _context.UserAccountStatusValues.Where(x => x.UserConfirmationToken == new Guid(userConfirmationToken)).FirstOrDefault<UserAccountStatus>();
            return _context.UserValues.Where(x => x.UserId == userConfirmationStatus.UserId).FirstOrDefault<User>();
        }

        private User GetUserByEmail(string userEmail) {
            return _context.UserValues.Where(x => string.Equals(x.UserEmail, userEmail)).FirstOrDefault<User>();
        }

        private string GenerateConfirmationToken(int userId) {
            var userConfirmationToken = Guid.NewGuid();
            var accountStatusModel = new UserAccountStatus() {
                UserAccountConfirmed = false,
                UserConfirmationToken = userConfirmationToken,
                UserId = userId
            };
            _context.UserAccountStatusValues.Add(accountStatusModel);
            _context.SaveChanges();
            return userConfirmationToken.ToString();
        }

        public bool ConfirmEmail(string tokenId) {
            var accountStatus = _context.UserAccountStatusValues.Where(x => x.UserConfirmationToken == new Guid(tokenId)).FirstOrDefault<UserAccountStatus>();
            if(accountStatus != null) {
                if(!accountStatus.UserAccountConfirmed) {
                    accountStatus.UserAccountConfirmed = true;
                    return true;
                }
                return false;
            }
            return false;
        }

        public User GetUserFromEmailAddress(string emailAddress) {
            return GetUserByEmail(emailAddress);
        }
        
    }
}