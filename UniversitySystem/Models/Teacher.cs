using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string TeacherName { get; set; }

        public string TeacherAddress { get; set; }

        public string TeacherEmail { get; set; }

        public string TeacherContactNumber { get; set; }

        public virtual Designation Designation { get; set; }
        public DesignationList DesignationId { get; set; }

        public virtual Department Department { get; set; }
        public int DepartmentId { get; set; }

        public float TeacherCredits { get; set; }
    }

    
}