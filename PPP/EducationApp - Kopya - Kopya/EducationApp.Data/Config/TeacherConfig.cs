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
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.FirstName)
                        .IsRequired()
                        .HasMaxLength(50);

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

            builder.Property(s => s.EducationStatus)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(s => s.Experience)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(s => s.Price)
                .IsRequired()
                .HasMaxLength(50);


            builder.ToTable("Teacher");

            // builder.HasData(
            //     new Teacher { Id = 1, FirstName = "Büşra", LastName = "Gündüz", Age = 35, Gender = "Kadın", ImageUrl = "9.png", Url = "busra-gunduz", City = "İstanbul", Email = "busragunduz@gmail.com", Phone = "05256554545", Description = "Hello! 4 yıllık kurum ve özel ders deneyimim sonucunda net bir şekilde söyleyebilirim ki öğretme işini çok severek yapıyorum.Çocuklarda ingilizce, genel ingilizce ve iş ingilizcesi başta olmak üzere birçok özel ders deneyimim oldu. Öğrencilerimden beklentim düzenli ve istekli çalışmaları. Kişiye özel dil öğrenme metodları ile öğrenmek istediğiniz dil konusunda size severek yardımcı olabilirim. Sınava hazırlık ve çeviri çalışmalarınız için de benimle iletişime geçebilirsiniz. ", LessonPlace = "Online", EducationStatus = "İstanbul Üniversitesi, İngilizce Dili ve Edebiyatı", Experience = "4 yıl", Price = 200 },

            //     new Teacher { Id = 2, FirstName = "Mehmet", LastName = "Yıldırım", Age = 42, Gender = "Erkek", ImageUrl = "10.png", Url = "mehmet-yildirim", City = "Ankara", Email = "mehmetyildirim@gmail.com", Phone = "05256554545", Description = "Çoğunlukla LGS ye hazırlanan öğrencilere Eğitim Koçluğu yaparak matematik dersleri veriyorum.4 yılı üniversitede öğrencilik döneminde olmak üzere toplam 25 yıl matematik dersi anlatma tecrübem vardır.1 adet dershane ve özel okullar için 8. sınıf sınavlara yönelik matematik kitabı yazdım. ", LessonPlace = "Online", EducationStatus = "Ankara Üniversitesi, Matematik", Experience = "8 yıl", Price = 250 },

            //     new Teacher { Id = 3, FirstName = "Ayşegül", LastName = "Güzel", Age = 27, Gender = "Kadın", ImageUrl = "11.png", Url = "aysegul-guzel", City = "İzmir", Email = "aysegulguzel@gmail.com", Phone = "05256554545", Description = "Boş vakitlerimde ( haftanın her günü öğleden sonra) özel tenis ve yüzme dersleri veriyorum. ", LessonPlace = "Yüz yüze", EducationStatus = "Zonguldak Bülent Ecevit Üniversitesi, Beden Eğitimi Ve Spor Öğretmenliği", Experience = "4 yıl", Price = 300 },

            //     new Teacher { Id = 4, FirstName = "Efe", LastName = "Yılmaz", Age = 38, Gender = "Erkek", ImageUrl = "12.png", Url = "efe-yilmaz", City = "İstanbul", Email = "efeyilmaz@gmail.com", Phone = "05256554545", Description = "Merhaba, Elektro gitar, klasik gitar, caz armonisi, klasik armoni, değişken do tekniğinde kulak eğitimini Türkçe ve İngilizce, tüm dünyada kabul görmüş kaynaklar eşliğinde, makul fiyatlara alabilirsiniz. ", LessonPlace = "Yüz yüze", EducationStatus = "Odtü", Experience = "12 yıl", Price = 250 },

            //     new Teacher { Id = 5, FirstName = "Arzu", LastName = "Özcan", Age = 30, Gender = "Kadın", ImageUrl = "13.png", Url = "arzu-ozcan", City = "Adana", Email = "arzuozcan@gmail.com", Phone = "05256554545", Description = "Önce Anadolu öğretmen lisesi ardından sakarya üniversitesi eğitim fakültesinde lisans eğitimimi tamamladım.2014 yılında mezun olduktan sonra hatrı sayılır Final kurumlarında uzun bir süre öğretmenlik yaptım.Çeşitli çocuk gelişimi ve kişisel gelişim belgelerim mevcut.Şu andada bu kurumda aktif öğretmen olarak çalışmaktayım.Derslerimde iddialı ve alanımda kendime fazlasıyla güvenmekteyim. ", LessonPlace = "Online", EducationStatus = "Sakarya Üniversitesi , Fizik", Experience = "10 yıl", Price = 300 },


            //     new Teacher { Id = 6, FirstName = "Müge", LastName = "Seçer", Age = 36, Gender = "Kadın", ImageUrl = "14.png", Url = "muge-secer", City = "İzmir", Email = "mugesecer@gmail.com", Phone = "05256554545", Description = "Klasik batı müziği keman bölümü okuyorum. Aynı zamanda piyano çalıyorum. 8 yıl bale ve modern dans eğitimi aldım. ", LessonPlace = "Online", EducationStatus = "İtü Devlet Konservatuar", Experience = "15 yıl", Price = 300 },


            //     new Teacher { Id = 7, FirstName = "Duygu", LastName = "Kara", Age = 35, Gender = "Kadın", ImageUrl = "15.png", Url = "duygu-kara", City = "İstanbul", Email = "duygukara@gmail.com", Phone = "05256554545", Description = "2014 yılında Mimarlık bölümünü 3. olarak 3.06 ortalama ile bitirdim. Üniversite de okuduğum dönem boyunca üst sınıfların projelerini çizer ve modelleme işleri yapardım. Şuan İstanbul da özel bir şirkette çalışmaktayım. Yaklaşık 8 yıldır Mimarlık ve ya İç Mimarlık öğrencilerine özel ders vermekteyim. Autocad, Sketchup modelleme ve Photoshop programları uzmanlık alanımdır. Çalıştığım öğrencilerle Autocad tasarım ve proje çizimlerin dışında modelleme işleri ve jüri sunum için gerekli Photoshop işlerini de birlikte yürütmekteyiz. Ayrıca öğrencilerin ihtiyaçları doğrultusunda ders dışında her zaman telefondan irtibat halinde kalmaktayım.Çoğunlukla online olarak, öğrencinin tercihine göre google meets , zoom ve ya skype üzerinden ders verilmektedir. ", LessonPlace = "Online", EducationStatus = "İtü, Mimarlık", Experience = "15 yıl", Price = 300 }


            //     );
        }
    }
}
