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
    [Route("api/UserSignOutController/")]
    [ApiController]
    public class UserSignOutController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenManager _tokenManager;
        public UserSignOutController(ApplicationDbContext context) {
            _context = context;
            _tokenManager = new TokenManager(_context);
        }

        [Route("SignOutUser/{tokenId}")]
        public bool SignOutUser(string tokenId) {
            var user = _tokenManager.GetUserModelFromToken(tokenId);
            if(user != null) {
                if(!user.UserHasLoggedIn) {
                    user.UserHasLoggedIn = true;
                }
            }
            return _tokenManager.DestroyToken(tokenId);
        }
    }
}