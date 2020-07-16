using System.Linq;
using System.Web.Mvc;
using UniversitySystem.Models;
using UniversitySystem.ViewModels;

namespace UniversitySystem.Controllers
{
    public class AssignCourseToTeacherController : Controller
    {
        private ApplicationDbContext _context;

        public AssignCourseToTeacherController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispose)
        {
            _context.Dispose();
        }

        [HttpGet]
        public ActionResult AssignCourseToTeacher()
        {
            var department = new Department();

            var courseAssignViewModel = new CourseAssignToTeacherViewModel
            {
                Departments = department.GetDepartments(),
            };

            return View(courseAssignViewModel);
        }
    }
}