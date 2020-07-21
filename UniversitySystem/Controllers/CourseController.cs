using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Xml.Linq;
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

            //Fetched the course from DB whose ID is brought by viewmodel from view
            var courseInDb = _context.Courses.Single(c => c.Id == assignCourse.AssignedCourseId);
            courseInDb.TeacherId = assignCourse.CourseAssignedTeacher;

            //Fetched the teacher from DB whose ID is brought by viewmodel from view
            var teacherInDb = _context.Teachers.Single(t => t.Id == assignCourse.CourseAssignedTeacher);
            teacherInDb.RemainingCredits = assignCourse.TeachersRemainingCredit;
            teacherInDb.Courses.Add(courseInDb);
            _context.SaveChanges();

            return Json(assignCourse.AssignedCourseId);
        }


        public JsonResult GetTeachersByDepartment(int? id)
        {
            var teacher = new Teacher();

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