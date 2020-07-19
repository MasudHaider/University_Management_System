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

            var courseAssignViewModel = new AssignCourseToTeacherViewModel
            {
                Departments = department.GetDepartments()
            };

            return View(courseAssignViewModel);
        }

        [HttpPost]
        public ActionResult AssignCourseToTeacher(AssignCourseToTeacherViewModel assignCourse)
        {
            if (assignCourse == null)
                return Content("Invalid");

            return Content("ok");
        }



        public JsonResult GetTeachersByDepartment(int? id)
        {
            var teacher = new Teacher();

            //IEnumerable<SelectListItem> teachersByDepartment = teacher.GetTeachersByDepartment(id);
            var courseAssignViewModel = new AssignCourseToTeacherViewModel
            {
                Teachers = teacher.GetTeachersByDepartment(id)
            };

            return Json(courseAssignViewModel.Teachers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCoursesByDepartment(int? id)
        {
            var course = new Course();

            var courseAssignViewModel = new AssignCourseToTeacherViewModel
            {
                CourseCodes = course.GetCoursesByDepartment(id)
            };

            return Json(courseAssignViewModel.CourseCodes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeacherCreditDetails(int id)
        {
            var teacher = new Teacher();
            var creditDetails = teacher.GetTeacherCreditDetails(id);
            return Json(creditDetails, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseDetails(int id)
        {
            var course = new Course();

            var courseDetails = course.GetCourseDetails(id);

            return Json(courseDetails, JsonRequestBehavior.AllowGet);
        }
    }
}