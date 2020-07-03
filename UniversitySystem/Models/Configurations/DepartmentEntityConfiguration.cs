using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models.Configurations
{
    public class DepartmentEntityConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentEntityConfiguration()
        {
            Property(d => d.DepartmentCode)
                .IsRequired()
                .HasMaxLength(50);

            Property(d => d.DepartmentName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}