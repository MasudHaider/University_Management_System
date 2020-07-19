using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models.Configurations
{
    public class TeacherEntityConfiguration : EntityTypeConfiguration<Teacher>
    {
        public TeacherEntityConfiguration()
        {
            Property(t => t.TeacherName)
                .IsRequired()
                .HasMaxLength(50);
            Property(t => t.TeacherAddress)
                .IsRequired()
                .HasMaxLength(100);
            Property(t => t.TeacherEmail)
                .IsRequired()
                .HasMaxLength(50);
            Property(t => t.TeacherContactNumber)
                .IsRequired()
                .HasMaxLength(15);
            Property(t => t.DesignationId)
                .IsRequired();
            Property(t => t.TeacherCredits)
                .IsRequired()
                .HasColumnType("float");
            Property(t => t.RemainingCredits)
                .IsRequired()
                .HasColumnType("float");
            HasRequired(t => t.Department)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DepartmentId)
                .WillCascadeOnDelete(false);
            /*HasMany(t => t.Courses)
                .WithRequired(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId)
                .WillCascadeOnDelete(false);*/
        }
    }
}