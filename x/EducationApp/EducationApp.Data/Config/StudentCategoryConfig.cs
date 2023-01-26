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
    public class StudentCategoryConfig :IEntityTypeConfiguration<StudentCategory>
    {
        public void Configure(EntityTypeBuilder<StudentCategory> builder)
        {
            builder.HasKey(sc => new { sc.StudentId, sc.CategoryId });

            builder.ToTable("StudentCategories");

            builder.HasData(
                new StudentCategory { StudentId = 1, CategoryId = 16 },
                new StudentCategory { StudentId = 2, CategoryId = 15 },
                new StudentCategory { StudentId = 3, CategoryId = 19 },
                new StudentCategory { StudentId = 4, CategoryId = 2 },
                new StudentCategory { StudentId = 5, CategoryId = 18 },

                new StudentCategory { StudentId = 6, CategoryId = 8 },
                new StudentCategory { StudentId = 6, CategoryId = 9 },

                new StudentCategory { StudentId = 7, CategoryId = 19 },
                new StudentCategory { StudentId = 7, CategoryId = 2 },

                new StudentCategory { StudentId = 8, CategoryId = 11 }


                );
        }

    }
}
