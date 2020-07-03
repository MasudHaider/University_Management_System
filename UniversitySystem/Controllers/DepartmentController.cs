using System.Web.Mvc;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispose)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {
            if (!ModelState.IsValid)
                return Content("Invalid model");

            return RedirectToAction("Index", "Department");
        }

        public JsonResult CheckDepartmentCodeAvailability(string deptCode)
        {
            var department = new Department();

            var deptCodeAvailability = department.CheckDepartmentCodeAvailability(deptCode);

            return Json(deptCodeAvailability, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckDepartmentNameAvailability(string deptName)
        {
            var department = new Department();

            var deptNameAvailability = department.CheckDepartmentNameAvailability(deptName);

            return Json(deptNameAvailability, JsonRequestBehavior.AllowGet);
        }
    }
}


