using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Proje05_MVC_EfCore.CodeFirst.Models
{
    public class MyDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<City> Citys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Override edildi.
        {
            optionsBuilder.UseSqlite("Data Source=First.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Override edildi.(ve migration yapılmalı)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category(){Id=1, Name="Phone", Desc="Phones"},
                    new Category(){Id=2, Name="Computer", Desc="Computers"},
                    new Category(){Id=3, Name="Electronic", Desc="Electronics"}

                );
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product(){Id=1, Name="Iphone 13", Desc="Güzel bir telefon", Price=19000, CategoryId=1},
                    new Product(){Id=2, Name="Dell Xside", Desc="Güzel bir bilgisayar", Price=15000, CategoryId=2},
                    new Product(){Id=3, Name="Samsung A71", Desc="KAmerası çok güzel", Price=17000, CategoryId=1},
                    new Product(){Id=4, Name="Piranha X13", Desc="Her yerde ses", Price=17000, CategoryId=3}



                );
                 modelBuilder.Entity<City>()
                .HasData(
                    new City(){id=34, Name="İstanbul"},
                    new City(){id=35, Name="İzmir"},
                    new City(){id=18, Name="Çanakkale"}



                ); // dotnet ef migrations add AddedData , dotnet ef database update(bunlar eklendikten sonra sonra)

        }
        
    }

   
}










 //entity ve dbcontext oluşturuduktan sonra terminalden kodlar girilir"  
    //1. dotnet tool install --global dotnet-ef --version 6.0.11
    //2.dotnet ef migrations add InitialDb
    //3.dotnet ef database update
    //4.dotnet ef migrations add AddedCity(City ekledikten sonra terminale)
    //5.dotnet ef database update
    //6.dotnet ef migrations add InitialDb,dotnet ef database update(db silip tekrar)
