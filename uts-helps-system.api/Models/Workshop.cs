using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using uts_helps_system.api.Security.Models;
using uts_helps_system.api.Enums;

namespace uts_helps_system.api.Models
{
    public class Workshop {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkshopId { get; set; }
        public string WorkshopName { get; set; }
        public string WorkshopDesc { get; set; }
        public DateTime WorkshopDateTime { get; set; }


        
    }
}