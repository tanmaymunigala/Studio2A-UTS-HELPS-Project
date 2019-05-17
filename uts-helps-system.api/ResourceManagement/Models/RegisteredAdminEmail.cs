using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uts_helps_system.api.ResourceManagement.Models
{
    public class RegisteredAdminEmail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistredAdminEmailId { get; set; }
        public string RegisteredAdminEmailAddress { get; set; }
        public bool EmailHasBeenRegistered { get; set; }
    }
}