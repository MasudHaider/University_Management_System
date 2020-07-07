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
            
            var teacherViewModel = new TeacherViewModel
            {
                Designations = Enum<DesignationList>.GetDesignationListItems(),
                Departments = department.GetDepartments()
            };

            return View(teacherViewModel);
        }

        [HttpPost]
        public bool SaveTeacher(TeacherViewModel teacherViewModel)
        {
            if (teacherViewModel == null)
                return false;

            var teacher = new Teacher
            {
                TeacherName = teacherViewModel.TeacherName,
                TeacherAddress = teacherViewModel.TeacherAddress,
                TeacherEmail = teacherViewModel.TeacherEmail,
                TeacherContactNumber = teacherViewModel.TeacherContactNumber,
                TeacherCredits = teacherViewModel.TeacherCredits,
                DepartmentId = teacherViewModel.SelectedDepartmentId,
                DesignationId = (DesignationList) teacherViewModel.SelectedDesignationId,
                Department = _context.Departments.Find(teacherViewModel.SelectedDepartmentId)
            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return true;
        }
    }
}