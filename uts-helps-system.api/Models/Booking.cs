using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using uts_helps_system.api.Security.Models;
using uts_helps_system.api.Enums;

namespace uts_helps_system.api.Models
{
    public class Booking {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int WorkshopId { get; set; }
        public DateTime BookingDate {get; set; }


        
    }
}