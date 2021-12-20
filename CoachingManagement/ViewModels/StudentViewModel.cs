using CoachingManagement.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoachingManagement.ViewModels
{
    public class StudentViewModel
    {
       

        [Required]
        public string StudentName { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public gender Gender { get; set; }
        public int courseId { get; set; }
        public Course course { get; set; }
        public IFormFile Photo { get; set; }
    }
}
