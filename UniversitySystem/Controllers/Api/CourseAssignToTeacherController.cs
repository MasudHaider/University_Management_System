using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UniversitySystem.Models;
using UniversitySystem.ViewModels;

namespace UniversitySystem.Controllers.Api
{
    public class CourseAssignToTeacherController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CourseAssignToTeacherController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult AssignCourseToTeacher(AssignCourseToTeacherViewModel assignCourseToTeacher)
        {
            if (assignCourseToTeacher == null)
                return NotFound();

            //Fetched the course from DB whose ID is brought by viewmodel from view
            var courseInDb = _context.Courses.Single(c => c.Id == assignCourseToTeacher.AssignedCourseId);
            courseInDb.TeacherId = assignCourseToTeacher.CourseAssignedTeacher;

            //Fetched the teacher from DB whose ID is brought by viewmodel from view
            var teacherInDb = _context.Teachers.Single(t => t.Id == assignCourseToTeacher.CourseAssignedTeacher);
            teacherInDb.RemainingCredits = assignCourseToTeacher.TeachersRemainingCredit;

            teacherInDb.Courses.Add(courseInDb);
            _context.SaveChanges();
            ModelState.Clear();

            return Json(assignCourseToTeacher.AssignedCourseId);
        }
    }
}