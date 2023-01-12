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
                }
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
                }
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Parolaİşlemleri
            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
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

                    // new Student { Id = 3, FirstName = "Ayşe", LastName = "Candan", Age = 16, Gender = "Kadın", ImageUrl = "3.png", Url = "ayse-candan", City = "Ankara", Email = "aysecandan@gmail.com", Phone = "05256552535", Description = "Merhaba, ben Ayşe Candan. Lise öğrencisiyim. Matematik derslerime yardımcı bir öğretmen arıyorum", LessonPlace = "Online" },

                    // new Student { Id = 4, FirstName = "Merve", LastName = "Akman", Age = 18, Gender = "Kadın", ImageUrl = "4.png", Url = "merve-akman", City = "Bursa", Email = "merveakman@gmail.com", Phone = "05321498998", Description = "Merhaba, ben Merve Akman. Fizik derslerinde bana yardımcı olabilecek bir öğretmen arıyorum", LessonPlace = "Online" },


                    //  new Student { Id = 5, FirstName = "Ali", LastName = "Kara", Age = 22, Gender = "Erkek", ImageUrl = "5.png", Url = "ali-kara", City = "İstanbul", Email = "alikara@gmail.com", Phone = "05359886547", Description = "Merhaba, ben Ali Kara. İngilizce derslerinde bana yardımcı olabilecek bir öğretmen arıyorum.", LessonPlace = "Online" },

                    //  new Student { Id = 6, FirstName = "Ayşe", LastName = "Sağlam", Age = 35, Gender = "Kadın", ImageUrl = "6.png", Url = "ayse-saglam", City = "İzmir", Email = "aysesaglam@gmail.com", Phone = "05256558998", Description = "Merhaba, ben Ayşe Sağlam. Çeşitli dans dersleri almak istiyorum. Aynı zamanda müzik alanına da çok ilgiliyim, bu sebepten piyano dersleri almak için de bir hoca arıyorum.", LessonPlace = "Yüz yüze" },

                    //  new Student { Id = 7, FirstName = "Ahmet", LastName = "Ak", Age = 17, Gender = "Erkek", ImageUrl = "7.png", Url = "ahmet-ak", City = "Adana", Email = "ahmetak@gmail.com", Phone = "05359886547", Description = "Merhaba, ben Ahmet Ak. Matematik ve Fizik alanlarında bana sınava hazırlık sürecinde yardımcı olacak hocalardan ders almak istiyorum.", LessonPlace = "Online" },


                    //  new Student { Id = 8, FirstName = "Beyza", LastName = "Güven", Age = 20, Gender = "Kadın", ImageUrl = "8.png", Url = "beyza-guven", City = "İstanbul", Email = "beyzaguven@gmail.com", Phone = "05359886547", Description = "Merhaba, ben Beyza Güven. Mühendislik öğrencisiyim ve AutoCad eğitimi almak istiyorum. Bana bu konuda yardımcı olabilecek eğitmenlerle iletişime geçmek istiyorum.", LessonPlace = "Online" }
            };
                modelBuilder.Entity<Student>().HasData(students);
            #endregion
        
        #region TeacherEkleme
            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher { Id = 1, FirstName = "Büşra", LastName = "Gündüz", Age = 35, Gender = "Kadın", ImageUrl = "9.png", Url = "busra-gunduz", City = "İstanbul", Email = "busragunduz@gmail.com", Phone = "05256554545", Description = "Hello! 4 yıllık kurum ve özel ders deneyimim sonucunda net bir şekilde söyleyebilirim ki öğretme işini çok severek yapıyorum.Çocuklarda ingilizce, genel ingilizce ve iş ingilizcesi başta olmak üzere birçok özel ders deneyimim oldu. Öğrencilerimden beklentim düzenli ve istekli çalışmaları. Kişiye özel dil öğrenme metodları ile öğrenmek istediğiniz dil konusunda size severek yardımcı olabilirim. Sınava hazırlık ve çeviri çalışmalarınız için de benimle iletişime geçebilirsiniz. ", LessonPlace = "Online", EducationStatus = "İstanbul Üniversitesi, İngilizce Dili ve Edebiyatı", Experience = "4 yıl", Price = 200 },

                new Teacher { Id = 2, FirstName = "Mehmet", LastName = "Yıldırım", Age = 42, Gender = "Erkek", ImageUrl = "10.png", Url = "mehmet-yildirim", City = "Ankara", Email = "mehmetyildirim@gmail.com", Phone = "05256554545", Description = "Çoğunlukla LGS ye hazırlanan öğrencilere Eğitim Koçluğu yaparak matematik dersleri veriyorum.4 yılı üniversitede öğrencilik döneminde olmak üzere toplam 25 yıl matematik dersi anlatma tecrübem vardır.1 adet dershane ve özel okullar için 8. sınıf sınavlara yönelik matematik kitabı yazdım. ", LessonPlace = "Online", EducationStatus = "Ankara Üniversitesi, Matematik", Experience = "8 yıl", Price = 250 },

                new Teacher { Id = 3, FirstName = "Ayşegül", LastName = "Güzel", Age = 27, Gender = "Kadın", ImageUrl = "11.png", Url = "aysegul-guzel", City = "İzmir", Email = "aysegulguzel@gmail.com", Phone = "05256554545", Description = "Boş vakitlerimde ( haftanın her günü öğleden sonra) özel tenis ve yüzme dersleri veriyorum. ", LessonPlace = "Yüz yüze", EducationStatus = "Zonguldak Bülent Ecevit Üniversitesi, Beden Eğitimi Ve Spor Öğretmenliği", Experience = "4 yıl", Price = 300 },

                new Teacher { Id = 4, FirstName = "Efe", LastName = "Yılmaz", Age = 38, Gender = "Erkek", ImageUrl = "12.png", Url = "efe-yilmaz", City = "İstanbul", Email = "efeyilmaz@gmail.com", Phone = "05256554545", Description = "Merhaba, Elektro gitar, klasik gitar, caz armonisi, klasik armoni, değişken do tekniğinde kulak eğitimini Türkçe ve İngilizce, tüm dünyada kabul görmüş kaynaklar eşliğinde, makul fiyatlara alabilirsiniz. ", LessonPlace = "Yüz yüze", EducationStatus = "Odtü", Experience = "12 yıl", Price = 250 },

                new Teacher { Id = 5, FirstName = "Arzu", LastName = "Özcan", Age = 30, Gender = "Kadın", ImageUrl = "13.png", Url = "arzu-ozcan", City = "Adana", Email = "arzuozcan@gmail.com", Phone = "05256554545", Description = "Önce Anadolu öğretmen lisesi ardından sakarya üniversitesi eğitim fakültesinde lisans eğitimimi tamamladım.2014 yılında mezun olduktan sonra hatrı sayılır Final kurumlarında uzun bir süre öğretmenlik yaptım.Çeşitli çocuk gelişimi ve kişisel gelişim belgelerim mevcut.Şu andada bu kurumda aktif öğretmen olarak çalışmaktayım.Derslerimde iddialı ve alanımda kendime fazlasıyla güvenmekteyim. ", LessonPlace = "Online", EducationStatus = "Sakarya Üniversitesi , Fizik", Experience = "10 yıl", Price = 300 },


                new Teacher { Id = 6, FirstName = "Müge", LastName = "Seçer", Age = 36, Gender = "Kadın", ImageUrl = "14.png", Url = "muge-secer", City = "İzmir", Email = "mugesecer@gmail.com", Phone = "05256554545", Description = "Klasik batı müziği keman bölümü okuyorum. Aynı zamanda piyano çalıyorum. 8 yıl bale ve modern dans eğitimi aldım. ", LessonPlace = "Online", EducationStatus = "İtü Devlet Konservatuar", Experience = "15 yıl", Price = 300 },


                new Teacher { Id = 7, FirstName = "Duygu", LastName = "Kara", Age = 35, Gender = "Kadın", ImageUrl = "15.png", Url = "duygu-kara", City = "İstanbul", Email = "duygukara@gmail.com", Phone = "05256554545", Description = "2014 yılında Mimarlık bölümünü 3. olarak 3.06 ortalama ile bitirdim. Üniversite de okuduğum dönem boyunca üst sınıfların projelerini çizer ve modelleme işleri yapardım. Şuan İstanbul da özel bir şirkette çalışmaktayım. Yaklaşık 8 yıldır Mimarlık ve ya İç Mimarlık öğrencilerine özel ders vermekteyim. Autocad, Sketchup modelleme ve Photoshop programları uzmanlık alanımdır. Çalıştığım öğrencilerle Autocad tasarım ve proje çizimlerin dışında modelleme işleri ve jüri sunum için gerekli Photoshop işlerini de birlikte yürütmekteyiz. Ayrıca öğrencilerin ihtiyaçları doğrultusunda ders dışında her zaman telefondan irtibat halinde kalmaktayım.Çoğunlukla online olarak, öğrencinin tercihine göre google meets , zoom ve ya skype üzerinden ders verilmektedir. ", LessonPlace = "Online", EducationStatus = "İtü, Mimarlık", Experience = "15 yıl", Price = 300 }

            };
            modelBuilder.Entity<Teacher>().HasData(teachers);
        #endregion
        }
    }
}
