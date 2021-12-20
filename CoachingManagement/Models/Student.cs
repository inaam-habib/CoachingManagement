using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoachingManagement.Models
{
    public class Student
    {

        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public gender Gender { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }
        public string PhotoPath { get; set; }
    }
}
