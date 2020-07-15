using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UniversitySystem.Models;
using UniversitySystem.ViewModels;

namespace UniversitySystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispose)
        {
            _context.Dispose();
        }

        [HttpGet]
        public ActionResult SaveCourse()
        {
            var department = new Department();
            var course = new Course();

            var courseViewModel = new CourseViewModel
            {
                Departments = department.GetDepartments(),
                Semesters = Enum<Semester>.GetListItems()
            };

            return View(courseViewModel);
        }

        public JsonResult CheckCourseCodeAvailability(string courseCode)
        {
            var course = new Course();

            var courseCodeAvailability = course.CheckCourseCodeAvailability(courseCode);

            return Json(courseCodeAvailability, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckCourseNameAvailability(string courseName)
        {
            var course = new Course();

            var courseNameAvailability = course.CheckCourseNameAvailability(courseName);

            return Json(courseNameAvailability, JsonRequestBehavior.AllowGet);
        }

        /*[HttpPost]
        public bool SaveCourse(CourseViewModel courseViewModel)
        {
            if (courseViewModel == null)
                return false;

            var course = new Course
            {
                CourseCode = courseViewModel.CourseCode,
                CourseName = courseViewModel.CourseName,
                CourseCredit = courseViewModel.CourseCredit,
                CourseDescription = courseViewModel.CourseDescription,
                DepartmentId = courseViewModel.SelectedDepartmentId,
                SemesterId = (Semester) courseViewModel.SelectedSemesterId,
                Department = _context.Departments.Find(courseViewModel.SelectedDepartmentId)
            };

            _context.Courses.Add(course);
            _context.SaveChanges();

            return true;
        }*/

        /*public ActionResult GetDepartmentDropdownItems()
        {
            var department = new Department();

            return Json(department.GetDepartments(), JsonRequestBehavior.AllowGet);
        }*/

        /*public ActionResult GetSemesterDropdownItems()
        {
            var course = new Course();

            return Json(course.GetSemesterListItems(), JsonRequestBehavior.AllowGet);
        }*/
    }
}