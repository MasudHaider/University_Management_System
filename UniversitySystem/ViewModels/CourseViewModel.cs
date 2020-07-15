using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Models;

namespace UniversitySystem.ViewModels
{
    public class CourseViewModel
    {
        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public float CourseCredit { get; set; }

        public string CourseDescription { get; set; }

        public int SelectedDepartmentId { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }

        public int SelectedSemesterId { get; set; }
        public IEnumerable<SelectListItem> Semesters { get; set; }
    }
}