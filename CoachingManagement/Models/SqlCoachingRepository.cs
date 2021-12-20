using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoachingManagement.Models
{
    public class SqlCoachingRepository : ICoachingRepository

    {
        private readonly AppDbContext DbContext;

        public SqlCoachingRepository(AppDbContext _DbContext)
        {
            DbContext = _DbContext;
        }

       

        public Course CreateCourse(Course course)
        {
            DbContext.Course.Add(course);
            DbContext.SaveChanges();
            return course;
        }

        public Student CreateStudent(Student student)
        {
            DbContext.student.Add(student);
            DbContext.SaveChanges();
            return student;
        }

        public Teacher CreateTeacher(Teacher teacher)
        {
            DbContext.Teacher.Add(teacher);
            DbContext.SaveChanges();
            return teacher;
        }


        public List<Course> GetAllCourses()
        {
            var Courses= DbContext.Course.ToList();
            return Courses;
        }

        public List<Student> GetAllStudents()
        {
            var Students = DbContext.student.ToList();
            return Students;
        }

        public List<Teacher> GetAllTeachers()
        {
            var Teachers=DbContext.Teacher.ToList();
            return Teachers;
        }

        public Course GetCourse(int id)
        {
            var Course=DbContext.Course.FirstOrDefault(o => o.CourseId == id);
            return Course;
        }

        public List<Course> GetCourseName()
        {
            var CourseName = DbContext.Course.Include(m=>m.student).ToList();
            return CourseName;
        }
        public List<Teacher> GetTeacherName()
        {
            var TeacherName = DbContext.Teacher.Include(m => m.course).ToList();
            return TeacherName;
        }
        public Student GetStudent(int id)
        {
            var student = DbContext.student.FirstOrDefault(o => o.StudentId == id);
            return student;
        }

        public Teacher GetTeacher(int id)
        {
           var teacher = DbContext.Teacher.FirstOrDefault(o => o.TeacherId == id);
            return teacher;
        }
        public string CourseName(Student student)
        {
            var Courses = DbContext.Course.Include(m => m.student).ToList();
            var CourseName = Courses.FirstOrDefault(o => o.CourseId == student.CourseId);
            var Name = CourseName.CourseName;
            return Name;
        }
        public string TeacherName(Course course)
        {
            var Teachers = DbContext.Teacher.Include(m => m.course).ToList();
            var TeacherNames = Teachers.FirstOrDefault(o => o.TeacherId == course.teacherId);
            var Name = TeacherNames.TeacherName;
            return Name;
        }

        public void DeleteStudent(Student student)
        {
            DbContext.student.Remove(student);
            DbContext.SaveChanges();
        }

        public Student UpdateStudent(Student student)
        {
            var newstudent = DbContext.student.Attach(student);
            newstudent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            DbContext.SaveChanges();
            return student;
        }
    }
}
