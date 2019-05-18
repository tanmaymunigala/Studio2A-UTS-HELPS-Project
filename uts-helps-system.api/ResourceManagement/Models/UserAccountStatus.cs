using System;
using uts_helps_system.api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uts_helps_system.api.ResourceManagement.Models
{
    public class UserAccountStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAccountStatusId { get; set; }
        public bool UserAccountConfirmed { get; set; }
        public Guid UserConfirmationToken { get; set; }
        public int UserId { get; set; }
    }
}