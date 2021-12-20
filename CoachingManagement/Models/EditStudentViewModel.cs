using CoachingManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoachingManagement.Models
{
    public class EditStudentViewModel:StudentViewModel
    {
        [Required]
        
        public string PhotoPath { get; set; }
        public int StudentId { get; set; }
    }
}
