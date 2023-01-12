using EducationApp.Data.Config;
using EducationApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Concrete.EfCore.Contexts
{
    public class EducationAppContext :DbContext
    {
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentCategory> StudentCategories { get; set; }
        public DbSet<TeacherCategory> TeacherCategories { get; set; }
        public DbSet<TeacherStudent> TeacherStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .EnableSensitiveDataLogging()
            .UseSqlite("Data Source=EducationApp.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new StudentCategoryConfig());
            modelBuilder.ApplyConfiguration(new TeacherCategoryConfig());
            modelBuilder.ApplyConfiguration(new TeacherStudentConfig());

        }
    }
}

