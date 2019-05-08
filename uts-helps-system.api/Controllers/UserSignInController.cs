using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using uts_helps_system.api.Models;
using uts_helps_system.api.Data;
using uts_helps_system.api.Security;

namespace uts_helps_system.api.Controllers
{
    [Route("api/UserSignInController/")]
    [ApiController]
    public class UserSignInController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenManager _tokenManager;
        public UserSignInController(ApplicationDbContext context) {
            _context = context;
            _tokenManager = new TokenManager(_context);
        }

        [Route("SignInUser/{userEmail}/{password}")]
        public string SignInUser(string userEmail, string password) {
            var user = _context.UserValues.Where(x => x.UserEmail == userEmail).First<User>();
            if(user != null){
                if(HashingAlgorithms.VerifyPassword(user.UserPass, password)) {
                   return _tokenManager.AssignToken(user.UserId);
                }
                return null;
            }
            return null;
        }
    }
}