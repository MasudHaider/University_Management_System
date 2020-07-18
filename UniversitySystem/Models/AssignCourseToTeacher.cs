using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public class AssignCourseToTeacher
    {
        public int Id { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public int TeacherId { get; set; }

        public float CourseAssignedCredit { get; set; }
        public float TeachersRemainingCredit { get; set; }

        public virtual Course Course { get; set; }
        public int CourseId { get; set; }
    }
}