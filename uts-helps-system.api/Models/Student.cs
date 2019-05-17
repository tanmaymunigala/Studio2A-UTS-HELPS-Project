using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using uts_helps_system.api.Security.Models;
using uts_helps_system.api.Enums;

namespace uts_helps_system.api.Models
{
    public class Student : User {

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public int StudentId { get; set; }
        public StudentCourseType StudentCourseType { get; set; }
        public StudentDegreeType StudentDegreeType { get; set; }
        public StudentDegreeYearType StudentDegreeYearType { get; set; }
        public StudentStatusType StudentStatusType { get; set; }
        public string StudentLanguage { get; set; }
        public string StudentCountry { get; set; }
        public bool StudentPermissionToUseData { get; set; }
        public string StudentOtherEducationalBackground { get; set; }
    }
}