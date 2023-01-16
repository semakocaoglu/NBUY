using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationApp.Entity.Concrete;

namespace EducationApp.Data.Config
{
    public class TeacherStudentConfig : IEntityTypeConfiguration<TeacherStudent>
    {
        public void Configure(EntityTypeBuilder<TeacherStudent> builder)
        {
            builder.HasKey(ts => new { ts.TeacherId, ts.StudentId });

            builder.ToTable("TeacherStudents");
            builder.HasData(
                new TeacherStudent { TeacherId = 4, StudentId = 1 },
                new TeacherStudent { TeacherId = 3, StudentId = 2 },
                new TeacherStudent { TeacherId = 2, StudentId = 3 },
                new TeacherStudent { TeacherId = 5, StudentId = 4 },
                new TeacherStudent { TeacherId = 1, StudentId = 5 },

                new TeacherStudent { TeacherId = 6, StudentId = 6 },

                new TeacherStudent { TeacherId = 5, StudentId = 7 },
                new TeacherStudent { TeacherId = 2, StudentId = 7 },

                new TeacherStudent { TeacherId = 7, StudentId = 8 }



                );
        }
    }

}
