using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using UniversitySystem.Models;
using UniversitySystem.ViewModels;

namespace UniversitySystem.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private readonly ApplicationDbContext _context;

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
                SemesterId = (Semester)courseViewModel.SelectedSemesterId,
                Department = _context.Departments.Find(courseViewModel.SelectedDepartmentId)
            };

            _context.Courses.Add(course);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        /*[HttpPost]
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

            return Json(assignCourseToTeacher.AssignedCourseId);
        }*/

    }
}
