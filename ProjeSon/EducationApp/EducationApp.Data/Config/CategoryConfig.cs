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
                new Category { Id = 1, Name = "Sınava Hazırlık", Description = "", Url = "sinava-hazirlik", UpCatId = 0 , PopularCategory=false , ImageUrl="1.png" },
                new Category { Id = 2, Name = "Fizik", Description = "", Url = "fizik", UpCatId = 1, PopularCategory = false, ImageUrl = "10.jpg" },
                new Category { Id = 3, Name = "Kimya", Description = "", Url = "kimya", UpCatId = 1, PopularCategory = false, ImageUrl = "4.jpg" },
                new Category { Id = 4, Name = "İlkokul Dersleri", Description = "", Url = "ilkokul-dersleri", UpCatId = 0, PopularCategory = false, ImageUrl = "13.jpg" },
                new Category { Id = 5, Name = "Yabancı Dil", Description = "", Url = "yabanci-dil", UpCatId = 0, PopularCategory = false, ImageUrl = "6.jpg" },
                 new Category { Id = 6, Name = "Almanca", Description = "", Url = "almanca", UpCatId = 5, PopularCategory = false, ImageUrl = "7.jpg" },
                  new Category { Id = 7, Name = "Sanat", Description = "", Url = "sanat", UpCatId = 0, PopularCategory = false, ImageUrl = "2.jpg" },
                   new Category { Id = 8, Name = "Dans", Description = "", Url = "dans", UpCatId = 7, PopularCategory = false, ImageUrl = "5.jpg" },
                    new Category { Id = 9, Name = "Piyano", Description = "", Url = "piyano", UpCatId = 7, PopularCategory = true, ImageUrl = "12.jpg" },
                     new Category { Id = 10, Name = "Bilgisayar", Description = "", Url = "bilgisayar", UpCatId = 0, PopularCategory = false, ImageUrl = "11.jpg" },
                      new Category { Id = 11, Name = "AutoCad", Description = "", Url = "autocad", UpCatId = 10, PopularCategory = false, ImageUrl = "3.jpg" },
                       new Category { Id = 12, Name = "JavaScript", Description = "", Url = "javascript", UpCatId = 10, PopularCategory = true, ImageUrl = "9.jpg" },
                        new Category { Id = 13, Name = "Spor", Description = "", Url = "spor", UpCatId = 0, PopularCategory = false, ImageUrl = "14.jpg" },
                         new Category { Id = 14, Name = "Yüzme", Description = "", Url = "yüzme", UpCatId = 13, PopularCategory = true, ImageUrl = "15.jpg" },
                          new Category { Id = 15, Name = "Tenis", Description = "", Url = "tenis", UpCatId = 13, PopularCategory = true, ImageUrl = "16.jpg" },
                          new Category { Id = 16, Name = "Gitar", Description = "", Url = "gitar", UpCatId = 7, PopularCategory = false, ImageUrl = "8.jpg" },
                          new Category { Id = 17, Name = "Photoshop", Description = "", Url = "photoshop", UpCatId = 10, PopularCategory = false, ImageUrl = "3.jpg" },
                          new Category { Id = 18, Name = "İnglizce", Description = "", Url = "ingilizce", UpCatId = 5 , PopularCategory = true, ImageUrl = "17.jpg" },
                          new Category { Id = 19, Name = "Matematik", Description = "", Url = "matematik", UpCatId = 1, PopularCategory = true, ImageUrl = "1.jpg" },
                          new Category { Id = 20, Name = "Hayat Bilgisi", Description = "", Url = "hayat-bilgisi", UpCatId = 4, PopularCategory = false, ImageUrl = "3.jpg" },
                          new Category { Id = 21, Name = "Sosyal Bİlgiler", Description = "", Url = "sosyal-bilgiler", UpCatId = 4, PopularCategory = false, ImageUrl = "3.jpg" }



                          );



        }
    }


}

