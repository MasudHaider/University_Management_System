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
    public class CoursesController : ApiController
    {
        private ApplicationDbContext _context;

        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Courses/
        [HttpGet]
        public IHttpActionResult GetCourses()
        {
            var courses = _context.Courses.ToList();

            if (courses.Count > 0)
                return Ok(courses);

            return NotFound();
        }

        //POST /api/Courses/
        [HttpPost]
        public HttpResponseMessage CreateCourse(CourseViewModel courseViewModel)
        {
            if (courseViewModel == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var course = new Course
            {
                CourseCode = courseViewModel.CourseCode,
                CourseName = courseViewModel.CourseName,
                CourseCredit = courseViewModel.CourseCredit,
                CourseDescription = courseViewModel.CourseDescription,
                DepartmentId = courseViewModel.SelectedDepartmentId,
                SemesterId = courseViewModel.SelectedSemesterId,
                Department = _context.Departments.Find(courseViewModel.SelectedDepartmentId)
            };

            _context.Courses.Add(course);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
