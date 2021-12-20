using CoachingManagement.Models;
using CoachingManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoachingManagement.Controllers
{
    public class StudentController : Controller
    {
        private IWebHostEnvironment _hostingenvironment;
        private ICoachingRepository _coachingRepository;

        public StudentController(ICoachingRepository coachingRepository,IWebHostEnvironment hostingenvironment)
        {
            _hostingenvironment = hostingenvironment;
            _coachingRepository = coachingRepository;
        }
        [HttpGet]
        public IActionResult CreateStudent()
        {

            ViewBag.CoursesList = new SelectList(_coachingRepository.GetAllCourses(),"CourseId","CourseName");
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(StudentViewModel model)
        {

            if (ModelState.IsValid)
            {
                string UniqueFileName = ProcessuploadFile(model);
                
                Student student = new Student
                {
                    StudentName = model.StudentName,
                    FatherName = model.FatherName,
                    Age = model.Age,
                    Gender = model.Gender,
                    CourseId = model.courseId,
                    PhotoPath = UniqueFileName

                };
                _coachingRepository.CreateStudent(student);
                return RedirectToAction("StudentDetail", new { id = student.StudentId });
            }
            return View();
        }
        public IActionResult StudentDetail(int id)
        {
            var model=_coachingRepository.GetStudent(id);
            ViewBag.CourseNames = _coachingRepository.GetCourseName().SingleOrDefault(o=>o.CourseId==model.CourseId);
            
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var Student=_coachingRepository.GetStudent(id);
            _coachingRepository.DeleteStudent(Student);
            return RedirectToAction("index", "home");


        }

        [HttpPost]
        public IActionResult Edit(EditStudentViewModel model)
        {
           
            
            if (ModelState.IsValid)
            {
                Student Student = _coachingRepository.GetStudent(model.StudentId);

                Student.StudentName = model.StudentName;
                Student.FatherName = model.FatherName;
                Student.Age = model.Age;
                Student.Gender = model.Gender;
                Student.CourseId = model.courseId;


                if (model.Photo != null)
                {
                    Student.PhotoPath = ProcessuploadFile(model);
                }
                else
                {
                    Student.PhotoPath = model.PhotoPath;
                }

                _coachingRepository.UpdateStudent(Student);
            }
            

            return RedirectToAction("StudentDetail", "student");

        }

        private string ProcessuploadFile(StudentViewModel model)
        {
            string UniqueFileName = null;
            if (model.Photo != null)
            {
                string UploadsFolder = Path.Combine(_hostingenvironment.WebRootPath, "images");
                UniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filepath = Path.Combine(UploadsFolder, UniqueFileName);
                model.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
            }

            return UniqueFileName;
        }

        [HttpGet]
        
        public IActionResult Edit(int id )
        {
            var student = _coachingRepository.GetStudent(id);
            var editstudentviewmodel = new EditStudentViewModel
            {
                
                StudentName = student.StudentName,
                FatherName = student.FatherName,
                Age = student.Age,
                Gender = student.Gender,
                PhotoPath = student.PhotoPath,
                StudentId=student.StudentId,
                courseId=student.CourseId

            };
            ViewBag.CoursesList = new SelectList(_coachingRepository.GetAllCourses(), "CourseId", "CourseName");

            return View(editstudentviewmodel);
        }
    }
}
