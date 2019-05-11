using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uts_helps_system.api.Security.Models
{
    public class UserTokenEntry
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTokenEntryId { get; set; }
        public Guid TokenId { get; set; }
        public int UserId { get; set; }
    }
}