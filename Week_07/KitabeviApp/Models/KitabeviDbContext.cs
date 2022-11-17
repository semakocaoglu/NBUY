using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KitabeviApp.Models
{
    public class KitabeviDbContext:DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Kitabevi.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Kategori>()
               .HasData(
                   new Kategori() { Id = 1, Ad = "Çocuk", Aciklama = "Çocuk Kitapları" },
                   new Kategori() { Id = 2, Ad = "Edebiyat", Aciklama = "Roman, Hikaye, Şiir Kitapları" },
                   new Kategori() { Id = 3, Ad = "Bilgisayar", Aciklama = "Bilgisayar Kitapları" },
                   new Kategori() { Id = 4, Ad = "Akademik", Aciklama = "Akademik Kitaplar" }
               );

            modelBuilder.Entity<Yazar>()
                .HasData(
                    new Yazar() { Id = 1, Ad = "Matt Heig", DogumYili = 1980, Cinsiyet = 'E' },
                    new Yazar() { Id = 2, Ad = "Feyyaz Yiğit", DogumYili = 1990, Cinsiyet = 'E' },
                    new Yazar() { Id = 3, Ad = "Gizem Doğan", DogumYili = 1960, Cinsiyet = 'K' },
                    new Yazar() { Id = 4, Ad = "Jack London", DogumYili = 1930, Cinsiyet = 'E' },
                    new Yazar() { Id = 5, Ad = "Margaret Atwood", DogumYili = 1980, Cinsiyet = 'K' },
                    new Yazar() { Id = 6, Ad = "Cem Akaş", DogumYili = 1980, Cinsiyet = 'E' },
                    new Yazar() { Id = 7, Ad = "Zafer Demirkol", DogumYili = 1980, Cinsiyet = 'E' },
                    new Yazar() { Id = 8, Ad = "İlber Ortaylı", DogumYili = 1980, Cinsiyet = 'E' },
                    new Yazar() { Id = 9, Ad = "Seda Yiğit", DogumYili = 1980, Cinsiyet = 'K' },
                    new Yazar() { Id = 10, Ad = "George Orwell", DogumYili = 1980, Cinsiyet = 'E' }
                );
                
            
        }
    }

}