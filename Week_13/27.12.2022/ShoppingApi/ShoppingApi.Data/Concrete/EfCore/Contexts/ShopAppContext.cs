using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppinApi.Data.Config;
using ShoppinApi.Data.Extensions;
using ShoppinApi.Entity.Concrete;
using ShoppinApi.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinApi.Data.Concrete.EfCore.Contexts
{
    public class ShopAppContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardItem> CardItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public ShopAppContext(DbContextOptions<ShopAppContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig());
            modelBuilder.Entity<OrderItem>()
                .Property("Price")
                .HasColumnType("money");
            base.OnModelCreating(modelBuilder);
        }
    }
}
