using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace UniversitySystem.Models
{
    public class Department
    {
        private readonly ApplicationDbContext _context;

        public Department()
        {
            _context = new ApplicationDbContext();
        }

        public int Id { get; set; }

        public string DepartmentCode { get; set; }

        public string DepartmentName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        //public int? CourseId { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
        //public int? TeacherId { get; set; }


        //Get all the departments
        public IEnumerable<SelectListItem> GetDepartments()
        {
            List<SelectListItem> departments = _context.Departments.AsNoTracking()
                .OrderBy(d => d.DepartmentCode)
                .Select(d =>
                    new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.DepartmentCode
                    }).ToList();

            var departmentTip = new SelectListItem
            {
                Value = null,
                Text = "--Select Department--"
            };

            departments.Insert(0, departmentTip);

            return new SelectList(departments, "Value", "Text");
        }

        public bool CheckDepartmentCodeAvailability(string deptCode)
        {
            return _context.Departments.Any(d => d.DepartmentCode == deptCode);
        }

        public bool CheckDepartmentNameAvailability(string deptName)
        {
            return _context.Departments.Any(d => d.DepartmentCode == deptName);
        }
    }
}