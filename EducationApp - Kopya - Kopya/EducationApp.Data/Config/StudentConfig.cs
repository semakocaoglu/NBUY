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
        public class StudentConfig : IEntityTypeConfiguration<Student>
        {
            public void Configure(EntityTypeBuilder<Student> builder)
            {
                builder.HasKey(s => s.Id);
                builder.Property(s => s.Id).ValueGeneratedOnAdd();

                builder.Property(s => s.FirstName)
                        .IsRequired()
                        .HasMaxLength(50);

            builder.Property(s => s.UserId)
                        .IsRequired();

                builder.Property(s => s.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(s => s.Age)
                    .IsRequired();

                builder.Property(s => s.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                builder.Property(s => s.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(250);

                builder.Property(s => s.Url)
                    .IsRequired()
                    .HasMaxLength(250);

                builder.Property(s => s.City)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(s => s.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(s => s.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                builder.Property(s => s.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                builder.Property(s => s.LessonPlace)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.ToTable("Students");

                // builder.HasData(
                //     new Student { Id = 1, FirstName = "Gamze", LastName = "Yıldız", Age = 20, Gender = "Kadın", ImageUrl = "1.png", Url = "gamze-yildiz", City = "İstanbul", Email = "gamzeyildiz@gmail.com", Phone = "05256552535", Description = "Merhaba, ben Gamze Yılmaz. Üniversite öğrencisiyim. Gitar çalmayı çok seviyorum.", LessonPlace = "Yüz Yüze" },

                //     new Student { Id = 2, FirstName = "Ahmet", LastName = "Akyılmaz", Age = 25, Gender = "Erkek", ImageUrl = "2.png", Url = "ahmet-akyilmaz", City = "İzmir", Email = "ahmetakyilmaz@gmail.com", Phone = "05368667989", Description = "Tenis öğrenmek istiyorum.", LessonPlace = "Yüz Yüze" },

                //     new Student { Id = 3, FirstName = "Ayşe", LastName = "Candan", Age = 16, Gender = "Kadın", ImageUrl = "3.png", Url = "ayse-candan", City = "Ankara", Email = "aysecandan@gmail.com", Phone = "05256552535", Description = "Merhaba, ben Ayşe Candan. Lise öğrencisiyim. Matematik derslerime yardımcı bir öğretmen arıyorum", LessonPlace = "Online" },

                //     new Student { Id = 4, FirstName = "Merve", LastName = "Akman", Age = 18, Gender = "Kadın", ImageUrl = "4.png", Url = "merve-akman", City = "Bursa", Email = "merveakman@gmail.com", Phone = "05321498998", Description = "Merhaba, ben Merve Akman. Fizik derslerinde bana yardımcı olabilecek bir öğretmen arıyorum", LessonPlace = "Online" },


                //      new Student { Id = 5, FirstName = "Ali", LastName = "Kara", Age = 22, Gender = "Erkek", ImageUrl = "5.png", Url = "ali-kara", City = "İstanbul", Email = "alikara@gmail.com", Phone = "05359886547", Description = "Merhaba, ben Ali Kara. İngilizce derslerinde bana yardımcı olabilecek bir öğretmen arıyorum.", LessonPlace = "Online" },

                //      new Student { Id = 6, FirstName = "Ayşe", LastName = "Sağlam", Age = 35, Gender = "Kadın", ImageUrl = "6.png", Url = "ayse-saglam", City = "İzmir", Email = "aysesaglam@gmail.com", Phone = "05256558998", Description = "Merhaba, ben Ayşe Sağlam. Çeşitli dans dersleri almak istiyorum. Aynı zamanda müzik alanına da çok ilgiliyim, bu sebepten piyano dersleri almak için de bir hoca arıyorum.", LessonPlace = "Yüz yüze" },

                //      new Student { Id = 7, FirstName = "Ahmet", LastName = "Ak", Age = 17, Gender = "Erkek", ImageUrl = "7.png", Url = "ahmet-ak", City = "Adana", Email = "ahmetak@gmail.com", Phone = "05359886547", Description = "Merhaba, ben Ahmet Ak. Matematik ve Fizik alanlarında bana sınava hazırlık sürecinde yardımcı olacak hocalardan ders almak istiyorum.", LessonPlace = "Online" },


                //      new Student { Id = 8, FirstName = "Beyza", LastName = "Güven", Age = 20, Gender = "Kadın", ImageUrl = "8.png", Url = "beyza-guven", City = "İstanbul", Email = "beyzaguven@gmail.com", Phone = "05359886547", Description = "Merhaba, ben Beyza Güven. Mühendislik öğrencisiyim ve AutoCad eğitimi almak istiyorum. Bana bu konuda yardımcı olabilecek eğitmenlerle iletişime geçmek istiyorum.", LessonPlace = "Online" }








                //      );




            }


        }
    }
