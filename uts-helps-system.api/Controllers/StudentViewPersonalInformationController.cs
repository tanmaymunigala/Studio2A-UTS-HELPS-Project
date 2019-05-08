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
    [Route("api/StudentViewPersonalInformationController/")]
    [ApiController]
    public class StudentViewPersonalInformationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenManager _tokenManager;

        public StudentViewPersonalInformationController(ApplicationDbContext context) {
            _context = context;
            _tokenManager = new TokenManager(_context);
        }

        [HttpGet("GetStudentInfo/{tokenId}")]
        public User GetStudentInfo(string tokenId) {
            return _tokenManager.GetUserModelFromToken(tokenId);
        }


    }
}