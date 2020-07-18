using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversitySystem.Models;

namespace UniversitySystem.ViewModels
{
    public class AssignCourseToTeacherViewModel
    {
        public int CourseAssignedDepartment { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }

        public int CourseAssignedTeacher { get; set; }
        public IEnumerable<SelectListItem> Teachers { get; set; }

        public float CourseAssignedCredit { get; set; }
        public float TeachersRemainingCredit { get; set; }

        public int AssignedCourse { get; set; }
        public IEnumerable<SelectListItem> CourseCodes { get; set; }

        /*public string SelectedCourseName { get; set; }
        public string SelectedCourseCredit { get; set; }*/
    }
}