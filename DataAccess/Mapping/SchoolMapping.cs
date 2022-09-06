using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Mapping
{
    public class SchoolMapping :EntityTypeConfiguration<School>
    {
        public SchoolMapping()
        {
            this.HasKey(s => s.ID);
            this.Property(s => s.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(s => s.Name).HasMaxLength(100).HasColumnType("nvarchar").IsUnicode(true);

            this.HasMany(s => s.Teachers)
                .WithRequired(t => t.School)
                .HasForeignKey(t => t.SchoolID);
        }
    }
}
