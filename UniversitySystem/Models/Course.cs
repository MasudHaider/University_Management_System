using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace UniversitySystem.Models
{
    public class Course
    {
        private readonly ApplicationDbContext _context;

        public Course()
        {
            _context = new ApplicationDbContext();
        }

        public int Id { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public float CourseCredit { get; set; }

        public string CourseDescription { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }

        public Semester SemesterId { get; set; }

        public ICollection<AssignCourseToTeacher> AssignCourseToTeachers { get; set; }

        //Methods
        public bool CheckCourseCodeAvailability(string courseCode)
        {
            return _context.Courses.Any(c => c.CourseCode == courseCode);
        }

        public bool CheckCourseNameAvailability(string courseName)
        {
            return _context.Courses.Any(c => c.CourseName == courseName);
        }

        public IEnumerable<SelectListItem> GetCoursesByDepartment(int? id)
        {
            List<SelectListItem> coursesByDepartment = _context.Courses.Where(t => t.DepartmentId == id)
                .OrderBy(t => t.CourseCode)
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.CourseCode
                }).ToList();

            return new SelectList(coursesByDepartment, "Value", "Text");
        }

        public IEnumerable GetCourseDetails(int id)
        {
            var courseDetails = _context.Courses.Where(c => c.Id == id)
                .Select(c => new {c.CourseName, c.CourseCredit});

            return courseDetails;
        }
    }

    public enum Semester
    {
        [Description("1st")]
        First = 1,
        [Description("2nd")]
        Second,
        [Description("3rd")]
        Third,
        [Description("4th")]
        Fourth,
        [Description("5th")]
        Fifth,
        [Description("6th")]
        Sixth,
        [Description("7th")]
        Seventh,
        [Description("8th")]
        Eighth
    }
}
