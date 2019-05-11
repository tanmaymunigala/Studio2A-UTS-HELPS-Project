using System;
using uts_helps_system.api.Models;
using uts_helps_system.api.Data;
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
                _context.UserAccountStatusValues.Remove(userConfirmationStatus);
                _context.UserValues.Remove(user);
                _context.SaveChanges();
                return false;
            }
            return true;
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

        
    }
}