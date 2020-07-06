using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Models;
using UniversitySystem.ViewModels;

namespace UniversitySystem.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispose)
        {
            _context.Dispose();
        }

        public ActionResult SaveTeacher()
        {
            var department = new Department();
            var designation = new Designation();

            var teacherViewModel = new TeacherViewModel
            {
                Designations = designation.GetDesignationListItems(),
                Departments = department.GetDepartments()
            };

            return View(teacherViewModel);
        }
    }
}