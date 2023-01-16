using EducationApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Description)
                .HasMaxLength(500);

            builder.Property(c => c.Url)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(c => c.UpCatId)
                .IsRequired();



            builder.ToTable("Categories");

            builder.HasData(
                new Category { Id = 1, Name = "Matematik", Description = "", Url = "matematik", UpCatId = 0 },
                new Category { Id = 2, Name = "Fizik", Description = "", Url = "fizik", UpCatId = 0 },
                new Category { Id = 3, Name = "Kimya", Description = "", Url = "kimya", UpCatId = 0 },
                new Category { Id = 4, Name = "İlkokul Dersleri", Description = "", Url = "ilkokul-dersleri", UpCatId = 0 },
                new Category { Id = 5, Name = "Yabancı Dil", Description = "", Url = "yabanci-dil", UpCatId = 0 },
                 new Category { Id = 6, Name = "Almanca", Description = "", Url = "almanca", UpCatId = 5 },
                  new Category { Id = 7, Name = "Sanat", Description = "", Url = "sanat", UpCatId = 0 },
                   new Category { Id = 8, Name = "Dans", Description = "", Url = "dans", UpCatId = 7 },
                    new Category { Id = 9, Name = "Piyano", Description = "", Url = "piyano", UpCatId = 7 },
                     new Category { Id = 10, Name = "Bilgisayar", Description = "", Url = "bilgisayar", UpCatId = 0 },
                      new Category { Id = 11, Name = "AutoCad", Description = "", Url = "autocad", UpCatId = 10 },
                       new Category { Id = 12, Name = "JavaScript", Description = "", Url = "javascript", UpCatId = 10 },
                        new Category { Id = 13, Name = "Spor", Description = "", Url = "spor", UpCatId = 0 },
                         new Category { Id = 14, Name = "Yüzme", Description = "", Url = "yüzme", UpCatId = 13 },
                          new Category { Id = 15, Name = "Tenis", Description = "", Url = "tenis", UpCatId = 13 },
                          new Category { Id = 16, Name = "Gitar", Description = "", Url = "gitar", UpCatId = 7 },
                          new Category { Id = 17, Name = "Photoshop", Description = "", Url = "photoshop", UpCatId = 10 },
                          new Category { Id = 18, Name = "İnglizce", Description = "", Url = "ingilizce", UpCatId = 5 });



        }
    }


}

