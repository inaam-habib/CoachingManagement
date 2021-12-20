using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoachingManagement.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]

        public int Age { get; set; }
        public gender Gender { get; set; }
        public List<Course> course { get; set; }
    }
}
