using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySystem.ViewModels
{
    public class TeacherViewModel
    {
        public string TeacherName { get; set; }

        public string TeacherAddress { get; set; }

        public string TeacherEmail { get; set; }

        public string TeacherContactNumber { get; set; }

        public int SelectedDesignationId { get; set; }
        public IEnumerable<SelectListItem> Designations { get; set; }

        public int SelectedTeacherDepartmentId { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }

        public float TeacherCredits { get; set; }
    }
}