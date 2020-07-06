using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UniversitySystem.Models.Configurations
{
    public class DesignationEntityConfiguration : EntityTypeConfiguration<Designation>
    {
        public DesignationEntityConfiguration()
        {
            Property(d => d.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}