using EducationApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Config
{
    public class TeacherCategoryConfig : IEntityTypeConfiguration<TeacherCategory>
    {
        public void Configure(EntityTypeBuilder<TeacherCategory> builder)
        {
            builder.HasKey(tc => new { tc.TeacherId, tc.CategoryId });

            builder.ToTable("TeacherCategories");

            builder.HasData(
                new TeacherCategory { TeacherId = 1, CategoryId = 18 },

                new TeacherCategory { TeacherId = 2, CategoryId = 1 },

                new TeacherCategory { TeacherId = 3, CategoryId = 14 },
                new TeacherCategory { TeacherId = 3, CategoryId = 15 },

                new TeacherCategory { TeacherId = 4, CategoryId = 16 },

                new TeacherCategory { TeacherId = 5, CategoryId = 2 },

                new TeacherCategory { TeacherId = 6, CategoryId = 8 },

                new TeacherCategory { TeacherId = 7, CategoryId = 11 },
                new TeacherCategory { TeacherId = 7, CategoryId = 17 }



        );

        }

    }
}
