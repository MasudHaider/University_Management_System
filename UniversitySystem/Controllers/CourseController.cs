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

        [HttpGet]
        public ActionResult AssignCourseToTeacher()
        {
            var department = new Department();

            var courseAssignViewModel = new CourseAssignToTeacherViewModel
            {
                Departments = department.GetDepartments()
            };

            return View(courseAssignViewModel);
        }

        public JsonResult GetTeachersByDepartment(int? id)
        {
            var teacher = new Teacher();

            //IEnumerable<SelectListItem> teachersByDepartment = teacher.GetTeachersByDepartment(id);
            var courseAssignViewModel = new CourseAssignToTeacherViewModel
            {
                Teachers = teacher.GetTeachersByDepartment(id)
            };

            return Json(courseAssignViewModel.Teachers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCoursesByDepartment(int? id)
        {
            var course = new Course();

            var courseAssignViewModel = new CourseAssignToTeacherViewModel
            {
                CourseCodes = course.GetCoursesByDepartment(id)
            };

            return Json(courseAssignViewModel.CourseCodes, JsonRequestBehavior.AllowGet);
        }
    }
}