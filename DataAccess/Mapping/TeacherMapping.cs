using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class TeacherMapping : EntityTypeConfiguration<Teacher>
    {
        //TeacherMapping classında biz Teacher classında tanımlamış olduğumuz propertlerin SQL ' server'da özelliklerinin ayarlanmasını sağladığımız yerdir. Yani bir kolonon Identity olması , Maksimium 50 karakter girilmesi gibi özellikler mapping classı içerisinde ayarlanır.
        public TeacherMapping()
        {
            this.HasKey(t => t.ID);
            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(t => t.FirstName).HasMaxLength(25).HasColumnType("nvarchar");

            this.HasRequired(t => t.School)
                .WithMany(s => s.Teachers)
                .HasForeignKey(t => t.SchoolID);
        }
    }
}
