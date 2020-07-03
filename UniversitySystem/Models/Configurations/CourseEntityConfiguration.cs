using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models.Configurations
{
    public class CourseEntityConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseEntityConfiguration()
        {
            Property(c => c.CourseCode)
                .IsRequired()
                .HasMaxLength(50);
            Property(c => c.CourseName)
                .IsRequired()
                .HasMaxLength(50);
            Property(c => c.CourseCredit)
                .HasColumnType("float")
                .IsRequired();
                
            Property(c => c.CourseDescription)
                .HasMaxLength(100);

            HasRequired(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .WillCascadeOnDelete(false);
            Property(c => c.SemesterId)
                .IsRequired();
        }
        
    }
}