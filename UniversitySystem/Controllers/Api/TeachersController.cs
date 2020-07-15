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
    public class TeachersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public TeachersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Teachers/
        [HttpGet]
        public IHttpActionResult GetTeachers()
        {
            var teachers = _context.Teachers.ToList();

            if (teachers.Count > 0)
                return Ok(teachers);

            return NotFound();
        }

        //GET /api/Teachers/id
        [HttpGet]
        public IHttpActionResult GetTeacher(int teacherId)
        {
            var teacher = _context.Teachers.SingleOrDefault(t => t.Id == teacherId);

            if (teacher == null)
                return NotFound();

            return Ok(teacher);
        }

        //POST /api/Teachers/
        [HttpPost]
        public HttpResponseMessage CreateTeacher(TeacherViewModel teacherViewModel)
        {
            if (teacherViewModel == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var teacher = new Teacher
            {
                TeacherName = teacherViewModel.TeacherName,
                TeacherAddress = teacherViewModel.TeacherAddress,
                TeacherEmail = teacherViewModel.TeacherEmail,
                TeacherContactNumber = teacherViewModel.TeacherContactNumber,
                DesignationId = (Designations) teacherViewModel.SelectedDesignationId,
                DepartmentId = teacherViewModel.SelectedTeacherDepartmentId,
                Department = _context.Departments.Find(teacherViewModel.SelectedTeacherDepartmentId),
                TeacherCredits = teacherViewModel.TeacherCredits
            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
