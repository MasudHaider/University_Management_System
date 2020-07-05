using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers.Api
{
    public class DepartmentsController : ApiController
    {
        private ApplicationDbContext _context;

        public DepartmentsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/departments
        [HttpGet]
        public IHttpActionResult GetDepartments()
        {
            var departments = _context.Departments.ToList();

            if (departments.Count > 0)
                return Ok(departments);

            return NotFound();
        }

        [HttpPost]
        //POST /api/departments
        public HttpResponseMessage CreateDepartment(Department department)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var destination = this.Url.Link("Default", new {Controller = "Department", Action = "Index"});
            _context.Departments.Add(department);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, new {Success = true, RedirectUrl = destination});                                     
        }
    }
}
