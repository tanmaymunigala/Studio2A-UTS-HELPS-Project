using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using uts_helps_system.api.Models;
using uts_helps_system.api.Data;
using uts_helps_system.api.Security;
using uts_helps_system.api.Enums;

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

        [Route("GetStudentInfo/{tokenId}")]
        public Student GetStudentInfo(string tokenId) {
            var userModel = _tokenManager.GetUserModelFromToken(tokenId);
            if(userModel != null) {
                if(userModel.UserAccountType == UserAccountType.Student) {
                    return (Student)userModel;
                }
            }
            return null;
        }


    }
}