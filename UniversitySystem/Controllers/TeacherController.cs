﻿using System.Web.Mvc;
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
                Designations = Enum<Designations>.GetListItems(),
                Departments = department.GetDepartments()
            };

            return View(teacherViewModel);
        }

        /*[HttpPost]
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
                DepartmentId = teacherViewModel.SelectedTeacherDepartmentId,
                DesignationId = (Designations) teacherViewModel.SelectedDesignationId,
                Department = _context.Departments.Find(teacherViewModel.SelectedTeacherDepartmentId)
            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return true;
        }*/

        public JsonResult CheckTeacherEmailAvailability(string teacherEmail)
        {
            var teacher = new Teacher();

            var teacherEmailAvailability = teacher.CheckTeacherEmailAvailability(teacherEmail);

            return Json(teacherEmailAvailability, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckTeacherContactAvailability(string teacherContact)
        {
            var teacher = new Teacher();

            var teacherContactAvailability = teacher.CheckTeacherContactAvailability(teacherContact);

            return Json(teacherContactAvailability, JsonRequestBehavior.AllowGet);
        }
    }
}