using System;
using System.Collections;
using System.Collections.Generic;
using uts_helps_system.api.Enums;
using uts_helps_system.api.Security.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using uts_helps_system.api.ResourceManagement.Models;

namespace uts_helps_system.api.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPrefFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserFaculty { get; set; }
        public string UserHomePhone { get; set; }
        public string UserMobile { get; set; }
        public string UserBestContactNumber { get; set; }
        public DateTime UserDob { get; set; }
        public UserGenderType UserGenderType { get; set; }
        public UserAccountType UserAccountType { get; set; }
        public bool UserHasLoggedIn { get; set; }
        public string UserPass { get; set; }
        public string UserName { get; set; }
        public List<UserTokenEntry> UserTokens { get; set; }
        public UserAccountStatus UserAccountStatus { get; set; }
    }
}