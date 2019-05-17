using System;
using uts_helps_system.api.Models;
using uts_helps_system.api.Enums;
using uts_helps_system.api.Data;
using uts_helps_system.api.ResourceManagement.Models;
using System.Linq;

namespace uts_helps_system.api.ResourceManagement
{
    public class AdminRegistrationManager
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager _userManager;
        public AdminRegistrationManager(ApplicationDbContext context, UserManager userManager) {
            _context = context;
            _userManager = userManager;
        }

        public bool RegisterAdmin(string emailAddress) {
            try {
                return RegisterAdminEmail(emailAddress);
            } catch(Exception) {
                var user = _userManager.GetUserFromEmailAddress(emailAddress);
                _userManager.RollbackUserRegistration(user);
                return false;
            }
        }

        private bool RegisterAdminEmail(string emailAddress) {
            var emailDetails = GetApprovedAdminEmail(emailAddress);
            var user = _userManager.GetUserFromEmailAddress(emailAddress);
            if(emailDetails != null) {
                emailDetails.EmailHasBeenRegistered = true;
                user.UserAccountType = UserAccountType.Admin;
                _context.SaveChanges();
                return true;
            }
            _context.UserValues.Remove(user);
            _context.SaveChanges();
            return false;
        }

        public bool AddNewAdminEmail(string adminEmail) {
            if(GetApprovedAdminEmail(adminEmail) != null) {
                return false;
            }
            var adminEmailModel = new RegisteredAdminEmail() {
                RegisteredAdminEmailAddress = adminEmail,
                EmailHasBeenRegistered = false
            };
            _context.RegisteredAdminEmailValues.Add(adminEmailModel);
            return true;
        }

        private RegisteredAdminEmail GetApprovedAdminEmail(string emailAddress) {
            return _context.RegisteredAdminEmailValues.Where(x => x.RegisteredAdminEmailAddress.Equals(emailAddress)).FirstOrDefault<RegisteredAdminEmail>();
        }
    }
}