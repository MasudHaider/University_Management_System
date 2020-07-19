using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models.Configurations
{
    public class AssignCourseToTeacherEntityConfiguration : EntityTypeConfiguration<AssignCourseToTeacher>
    {
        public AssignCourseToTeacherEntityConfiguration()
        {
            Property(ac => ac.CourseAssignedCredit)
                .IsRequired()
                .HasColumnType("float");
            Property(ac => ac.TeachersRemainingCredit)
                .IsRequired()
                .HasColumnType("float");
        }
    }
}