using CoachingManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoachingManagement.Controllers
{
    public class CourseController : Controller
    {
        private ICoachingRepository _coachingRepository;

        public CourseController(ICoachingRepository coachingRepository)
        {
            _coachingRepository = coachingRepository;

        }


        [HttpGet]
        public IActionResult CreateCourse()
        {
            ViewBag.Teacher = new SelectList(_coachingRepository.GetAllTeachers(), "TeacherId", "TeacherName");
            return View();
        }
        [HttpPost]
        public IActionResult CreateCourse(Course course)
        {
            _coachingRepository.CreateCourse(course);
            return RedirectToAction("CourseDetails", new { id = course.CourseId });
        }
        public IActionResult CourseDetails(int id )
        {
            var model = _coachingRepository.GetCourse(id);
            ViewBag.TeacherNames = _coachingRepository.GetTeacherName().FirstOrDefault(o => o.TeacherId == model.teacherId);

            return View(model);
        }
        public IActionResult CourseList()
        {
            var model = _coachingRepository.GetAllCourses();
            return View(model);
        }
    }
}
