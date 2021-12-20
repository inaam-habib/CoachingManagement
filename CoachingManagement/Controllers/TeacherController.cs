using CoachingManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoachingManagement.Controllers
{
    public class TeacherController : Controller
    {
        private ICoachingRepository _coachingRepository;

        public TeacherController(ICoachingRepository coachingRepository)
        {
            _coachingRepository = coachingRepository;

        }
        [HttpGet]
        public IActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTeacher(Teacher teacher)
        {
            _coachingRepository.CreateTeacher(teacher);
            return RedirectToAction("TeacherDetails", new { id = teacher.TeacherId });
        }
        public IActionResult TeacherDetails(int id )
        {
            var model=_coachingRepository.GetTeacher(id);
            return View(model);
        }
        public IActionResult TeacherList()
        {
          var model=  _coachingRepository.GetAllTeachers();
            return View(model);
        }

    }
}
