using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using uts_helps_system.api.Models;
using uts_helps_system.api.Data;
using uts_helps_system.api.Security;
using uts_helps_system.api.ResourceManagement;

namespace uts_helps_system.api.Controllers
{
    [Route("api/UserSignInController/")]
    [ApiController]
    public class UserSignInController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenManager _tokenManager;

        private readonly UserManager _userManager; 
        public UserSignInController(ApplicationDbContext context) {
            _context = context;
            _tokenManager = new TokenManager(_context);
            _userManager = new UserManager(_context);
        }

        [Route("SignInUser/{userEmail}/{password}")]
        public string SignInUser(string userEmail, string password) {
            var user = _context.UserValues.Where(x => x.UserEmail == userEmail).First<User>();
            if(user != null){
                var userAccountStatus = _userManager.GetUserConfirmationStatus(user);
                if(HashingAlgorithms.VerifyPassword(user.UserPass, password)) {
                    if(userAccountStatus != null) {
                        if(userAccountStatus.UserAccountConfirmed) {
                            return _tokenManager.AssignToken(user.UserId);
                        }
                        return "UnconfirmedEmail"; // If the user account has not been confirmed this string will be returned to indicate that an uncofirmed email has attempted to sign in
                    }
                }
                return null;
            }
            return null;
        }
    }
}