using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoachingManagement.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Duration { get; set; }

        
        public int teacherId { get; set; }
        public Teacher teacher { get; set; }
        public ICollection<Student> student { get; set; }
    }
}
