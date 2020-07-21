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
        // int properties will store selected dropdown value
        //SelectListItems are for dropdown items
        public int CourseAssignedDepartment { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }

        public int CourseAssignedTeacher { get; set; }
        public IEnumerable<SelectListItem> Teachers { get; set; }

        public int AssignedCourseId { get; set; }
        public IEnumerable<SelectListItem> CourseCodes { get; set; }

        public float TeachersRemainingCredit { get; set; }
    }
}