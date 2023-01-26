using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EducationApp.Entity.Concrete;
using EducationApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region RolBilgileri
            List<Role> roles = new List<Role>
            {
                new Role
                {
                    Name="Admin",
                    Description="Admin rolü",
                    NormalizedName="ADMIN"
                },
                new Role
                {
                    Name="User",
                    Description="User rolü",
                    NormalizedName="USER"
                },

            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion

            #region KullanıcıBilgileri
            List<User> users = new List<User>
            {
                new User
                {
                    UserName="admin",
                    NormalizedUserName="ADMIN",
                    Email="admin@gmail.com",
                    NormalizedEmail="ADMIN@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="5555555555"
                },
                new User
                {
                    UserName="gamzeyildiz",
                    NormalizedUserName="GAMZEYILDIZ",
                    Email="gamzeyildiz@gmail.com",
                    NormalizedEmail="GAMZEYLDIZ@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05256552535"
                },
                new User
                {
                    UserName="ahmetakyilmaz",
                    NormalizedUserName="AHMETAKYILMAZ",
                    Email="ahmetakyilmaz@gmail.com",
                    NormalizedEmail="AHMETAKYILMAZ@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05368667989"
                },

                new User
                {
                    UserName="aysecandan",
                    NormalizedUserName="AYSECANDAN",
                    Email="aysecandan@gmail.com",
                    NormalizedEmail="AYSECANDAN@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05256552535"
                },

                new User
                {
                    UserName="merveakman",
                    NormalizedUserName="MERVEAKMAN",
                    Email="merveakman@gmail.com",
                    NormalizedEmail="MERVEAKMAN@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05321498998"
                },
                new User
                {
                    UserName="alikara",
                    NormalizedUserName="ALIKARA",
                    Email="alikara@gmail.com",
                    NormalizedEmail="ALIKARA@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05359886547"
                },
                   new User
                {
                    UserName="aysesaglam",
                    NormalizedUserName="AYSESAGLAM",
                    Email="aysesaglam@gmail.com",
                    NormalizedEmail="AYSESAGLAM@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05256558998"
                },
                new User
                {
                    UserName="ahmetak",
                    NormalizedUserName="AHMETAK",
                    Email="ahmetak@gmail.com",
                    NormalizedEmail="AHMETAK@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05359886547"
                },
                new User
                {
                    UserName="beyzaguven",
                    NormalizedUserName="BEYZAGUVEN",
                    Email="beyzaguven@gmail.com",
                    NormalizedEmail="BEYZAGUVEN@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05359886547"
                },
                new User
                {
                    UserName="busragunduz",
                    NormalizedUserName="BUSRAGUNDUZ",
                    Email="busragunduz@gmail.com",
                    NormalizedEmail="BUSRAGUNDUZ@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05256554545"
                },

                 new User
                {
                    UserName="mehmetyildirim",
                    NormalizedUserName="MEHMETYILDIRIM",
                    Email="mehmetyildirim@gmail.com",
                    NormalizedEmail="MEHMETYILDIRIM@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05256554545"
                },

                    new User
                {
                    UserName="aysegulguzel",
                    NormalizedUserName="AYSEGULGUZEL",
                    Email="aysegulguzel@gmail.com",
                    NormalizedEmail="AYSEGULGUZEL@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05256554545"
                },

              new User
                {
                    UserName="efeyilmaz",
                    NormalizedUserName="EFEYILMAZ",
                    Email="efeyilmaz@gmail.com",
                    NormalizedEmail="EFEYILMAZ@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05256554545"
                },
               new User
                {
                    UserName="arzuozcan",
                    NormalizedUserName="ARZUOZCAN",
                    Email="arzuozcan@gmail.com",
                    NormalizedEmail="ARZUOZCAN@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05256554545"
                },

                new User
                {
                    UserName="mugesecer",
                    NormalizedUserName="MUGESECER",
                    Email="mugesecer@gmail.com",
                    NormalizedEmail="MUGESECER@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05256554545"
                },

                new User
                {
                    UserName="duygukara",
                    NormalizedUserName="DUYGUKARA",
                    Email="duygukara@gmail.com",
                    NormalizedEmail="DUYGUKARA@GMAIL.COM",
                    EmailConfirmed=true,
                    PhoneNumber="05256554545"
                }

        };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Parolaİşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Qwe123.");
            users[3].PasswordHash = passwordHasher.HashPassword(users[3], "Qwe123.");
            users[4].PasswordHash = passwordHasher.HashPassword(users[4], "Qwe123.");
            users[5].PasswordHash = passwordHasher.HashPassword(users[5], "Qwe123.");
            users[6].PasswordHash = passwordHasher.HashPassword(users[6], "Qwe123.");
            users[7].PasswordHash = passwordHasher.HashPassword(users[7], "Qwe123.");
            users[8].PasswordHash = passwordHasher.HashPassword(users[8], "Qwe123.");
            users[9].PasswordHash = passwordHasher.HashPassword(users[9], "Qwe123.");
            users[10].PasswordHash = passwordHasher.HashPassword(users[10], "Qwe123.");
            users[11].PasswordHash = passwordHasher.HashPassword(users[11], "Qwe123.");
            users[12].PasswordHash = passwordHasher.HashPassword(users[12], "Qwe123.");
            users[13].PasswordHash = passwordHasher.HashPassword(users[13], "Qwe123.");
            users[14].PasswordHash = passwordHasher.HashPassword(users[14], "Qwe123.");
            users[15].PasswordHash = passwordHasher.HashPassword(users[15], "Qwe123.");
            #endregion

            #region KullanıcıRolAtamaİşlemleri
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId=users[0].Id,
                    RoleId=roles.First(r=>r.Name=="Admin").Id
                },
                new IdentityUserRole<string>
                {
                    UserId=users[1].Id,
                    RoleId=roles.First(r=>r.Name=="User").Id
                }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion

            #region StudentEkleme
            List<Student> students = new List<Student>
                {
                    new Student { Id = 1, UserId = users[1].Id, FirstName = "Gamze", LastName = "Yıldız", Age = 20, Gender = "Kadın", ImageUrl = "1.png", Url = "gamze-yildiz", City = "İstanbul", Description = "Merhaba, ben Gamze Yılmaz. Üniversite öğrencisiyim. Gitar çalmayı çok seviyorum.", LessonPlace = "Yüz Yüze" },

                    new Student { Id = 2, UserId = users[2].Id, FirstName = "Ahmet", LastName = "Akyılmaz", Age = 25, Gender = "Erkek", ImageUrl = "2.png", Url = "ahmet-akyilmaz", City = "İzmir", Description = "Tenis öğrenmek istiyorum.", LessonPlace = "Yüz Yüze" },

                     new Student { Id = 3, UserId = users[3].Id, FirstName = "Ayşe", LastName = "Candan", Age = 16, Gender = "Kadın", ImageUrl = "1.png", Url = "ayse-candan", City = "Ankara", Description = "Merhaba, ben Ayşe Candan. Lise öğrencisiyim. Matematik derslerime yardımcı bir öğretmen arıyorum", LessonPlace = "Online" },

                     new Student { Id = 4, UserId = users[4].Id, FirstName = "Merve", LastName = "Akman", Age = 18, Gender = "Kadın", ImageUrl = "1.png", Url = "merve-akman",  City = "Bursa", Description = "Merhaba, ben Merve Akman. Fizik derslerinde bana yardımcı olabilecek bir öğretmen arıyorum", LessonPlace = "Online" },


                      new Student { Id = 5, UserId = users[5].Id, FirstName = "Ali", LastName = "Kara", Age = 22, Gender = "Erkek", ImageUrl = "2.png", Url = "ali-kara", City = "İstanbul", Description = "Merhaba, ben Ali Kara. İngilizce derslerinde bana yardımcı olabilecek bir öğretmen arıyorum.", LessonPlace = "Online" },

                      new Student { Id = 6, UserId = users[6].Id, FirstName = "Ayşe", LastName = "Sağlam", Age = 35, Gender = "Kadın", ImageUrl = "1.png", Url = "ayse-saglam", City = "İzmir", Description = "Merhaba, ben Ayşe Sağlam. Çeşitli dans dersleri almak istiyorum. Aynı zamanda müzik alanına da çok ilgiliyim, bu sebepten piyano dersleri almak için de bir hoca arıyorum.", LessonPlace = "Yüz yüze" },

                      new Student { Id = 7,  UserId = users[7].Id, FirstName = "Ahmet", LastName = "Ak", Age = 17, Gender = "Erkek", ImageUrl = "2.png", Url = "ahmet-ak", City = "Adana", Description = "Merhaba, ben Ahmet Ak. Matematik ve Fizik alanlarında bana sınava hazırlık sürecinde yardımcı olacak hocalardan ders almak istiyorum.", LessonPlace = "Online" },


                      new Student { Id = 8, UserId = users[8].Id, FirstName = "Beyza", LastName = "Güven", Age = 20, Gender = "Kadın", ImageUrl = "1.png", Url = "beyza-guven", City = "İstanbul", Description = "Merhaba, ben Beyza Güven. Mühendislik öğrencisiyim ve AutoCad eğitimi almak istiyorum. Bana bu konuda yardımcı olabilecek eğitmenlerle iletişime geçmek istiyorum.", LessonPlace = "Online" }
            };
            modelBuilder.Entity<Student>().HasData(students);
            #endregion

            #region TeacherEkleme
            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher { Id = 1, UserId = users[9].Id, FirstName = "Büşra", LastName = "Gündüz", Age = 35, Gender = "Kadın", ImageUrl = "1.png", Url = "busra-gunduz", City = "İstanbul", Description = "Hello! 4 yıllık kurum ve özel ders deneyimim sonucunda net bir şekilde söyleyebilirim ki öğretme işini çok severek yapıyorum.Çocuklarda ingilizce, genel ingilizce ve iş ingilizcesi başta olmak üzere birçok özel ders deneyimim oldu. Öğrencilerimden beklentim düzenli ve istekli çalışmaları. Kişiye özel dil öğrenme metodları ile öğrenmek istediğiniz dil konusunda size severek yardımcı olabilirim. Sınava hazırlık ve çeviri çalışmalarınız için de benimle iletişime geçebilirsiniz. ", LessonPlace = "Online", EducationStatus = "İstanbul Üniversitesi, İngilizce Dili ve Edebiyatı", Experience = "1-3 yıl", Price = 200 },

                new Teacher { Id = 2, UserId = users[10].Id, FirstName = "Mehmet", LastName = "Yıldırım", Age = 42, Gender = "Erkek", ImageUrl = "2.png", Url = "mehmet-yildirim", City = "Ankara", Description = "Çoğunlukla LGS ye hazırlanan öğrencilere Eğitim Koçluğu yaparak matematik dersleri veriyorum.4 yılı üniversitede öğrencilik döneminde olmak üzere toplam 25 yıl matematik dersi anlatma tecrübem vardır.1 adet dershane ve özel okullar için 8. sınıf sınavlara yönelik matematik kitabı yazdım. ", LessonPlace = "Online", EducationStatus = "Ankara Üniversitesi, Matematik", Experience = "10+ yıl", Price = 250 },

                new Teacher { Id = 3, UserId = users[11].Id, FirstName = "Ayşegül", LastName = "Güzel", Age = 27, Gender = "Kadın", ImageUrl = "1.png", Url = "aysegul-guzel", City = "İzmir", Description = "Boş vakitlerimde ( haftanın her günü öğleden sonra) özel tenis ve yüzme dersleri veriyorum. ", LessonPlace = "Yüz yüze", EducationStatus = "Zonguldak Bülent Ecevit Üniversitesi, Beden Eğitimi Ve Spor Öğretmenliği", Experience = "3-5 yıl", Price = 300 },

                new Teacher { Id = 4, UserId = users[12].Id, FirstName = "Efe", LastName = "Yılmaz", Age = 38, Gender = "Erkek", ImageUrl = "2.png", Url = "efe-yilmaz", City = "İstanbul",  Description = "Merhaba, Elektro gitar, klasik gitar, caz armonisi, klasik armoni, değişken do tekniğinde kulak eğitimini Türkçe ve İngilizce, tüm dünyada kabul görmüş kaynaklar eşliğinde, makul fiyatlara alabilirsiniz. ", LessonPlace = "Yüz yüze", EducationStatus = "Odtü", Experience = "5-10 yıl", Price = 250 },

                new Teacher { Id = 5, UserId = users[13].Id, FirstName = "Arzu", LastName = "Özcan", Age = 30, Gender = "Kadın", ImageUrl = "1.png", Url = "arzu-ozcan", City = "Adana",  Description = "Önce Anadolu öğretmen lisesi ardından sakarya üniversitesi eğitim fakültesinde lisans eğitimimi tamamladım.2014 yılında mezun olduktan sonra hatrı sayılır Final kurumlarında uzun bir süre öğretmenlik yaptım.Çeşitli çocuk gelişimi ve kişisel gelişim belgelerim mevcut.Şu andada bu kurumda aktif öğretmen olarak çalışmaktayım.Derslerimde iddialı ve alanımda kendime fazlasıyla güvenmekteyim. ", LessonPlace = "Online", EducationStatus = "Sakarya Üniversitesi , Fizik", Experience = "3-5 yıl", Price = 300 },


                new Teacher { Id = 6, UserId = users[14].Id, FirstName = "Müge", LastName = "Seçer", Age = 36, Gender = "Kadın", ImageUrl = "1.png", Url = "muge-secer", City = "İzmir", Description = "Klasik batı müziği keman bölümü okuyorum. Aynı zamanda piyano çalıyorum. 8 yıl bale ve modern dans eğitimi aldım. ", LessonPlace = "Online", EducationStatus = "İtü Devlet Konservatuar", Experience = "10+ yıl", Price = 300 },


                new Teacher { Id = 7, UserId = users[15].Id, FirstName = "Duygu", LastName = "Kara", Age = 35, Gender = "Kadın", ImageUrl = "1.png", Url = "duygu-kara", City = "İstanbul", Description = "2014 yılında Mimarlık bölümünü 3. olarak 3.06 ortalama ile bitirdim. Üniversite de okuduğum dönem boyunca üst sınıfların projelerini çizer ve modelleme işleri yapardım. Şuan İstanbul da özel bir şirkette çalışmaktayım. Yaklaşık 8 yıldır Mimarlık ve ya İç Mimarlık öğrencilerine özel ders vermekteyim. Autocad, Sketchup modelleme ve Photoshop programları uzmanlık alanımdır. Çalıştığım öğrencilerle Autocad tasarım ve proje çizimlerin dışında modelleme işleri ve jüri sunum için gerekli Photoshop işlerini de birlikte yürütmekteyiz. Ayrıca öğrencilerin ihtiyaçları doğrultusunda ders dışında her zaman telefondan irtibat halinde kalmaktayım.Çoğunlukla online olarak, öğrencinin tercihine göre google meets , zoom ve ya skype üzerinden ders verilmektedir. ", LessonPlace = "Online", EducationStatus = "İtü, Mimarlık", Experience = "10+ yıl", Price = 300 }

            };
            modelBuilder.Entity<Teacher>().HasData(teachers);
            #endregion
        }
    }
}
