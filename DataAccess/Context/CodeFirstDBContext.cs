using DataAccess.Mapping;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class CodeFirstDBContext : DbContext
    {
        public CodeFirstDBContext(): base("Server = CERENKALPC; Database=KD12CodeFirstAppTekrarDB;Uid=sa;Pwd=123")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CodeFirstDBContext>());
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TeacherMapping());
            modelBuilder.Configurations.Add(new SchoolMapping());
        }
    }
}
