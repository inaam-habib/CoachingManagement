using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoachingManagement.Models
{
   public interface ICoachingRepository
    {

        public Student UpdateStudent(Student student);
        public string CourseName(Student student);
        public List<Teacher> GetTeacherName();
        public Student CreateStudent(Student student);

        public Teacher CreateTeacher(Teacher teacher);

        public Course CreateCourse(Course course);

        public Student GetStudent(int id);
        public Teacher GetTeacher(int id);
        public Course GetCourse(int id);
        public List<Course> GetAllCourses();
        public List<Teacher> GetAllTeachers();
        public List<Student> GetAllStudents();
        public List<Course> GetCourseName();
        public string TeacherName(Course course);
        public void DeleteStudent(Student student);


    }
}
