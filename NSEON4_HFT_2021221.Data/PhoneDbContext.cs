using Microsoft.EntityFrameworkCore;
using NSEON4_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Data
{
    public class PhoneDbContext : DbContext
    {
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Headquarter> Headquarters { get; set; }

        public PhoneDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PhoneDB.mdf;Integrated Security=True";
                builder.UseLazyLoadingProxies().UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>(entity =>
            {
                entity
                .HasOne(phone => phone.Brand)
                .WithMany(brand => brand.Phones)
                .HasForeignKey(phone => phone.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Headquarter>(entity =>
            {
                entity
                .HasOne(Headquarter => Headquarter.Brand)
                .WithMany(brand => brand.Headquarters)
                .HasForeignKey(Headquarter => Headquarter.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            Brand samsung = new Brand() { Id = 1, Name = "Samsung" };
            Brand oneplus = new Brand() { Id = 2, Name = "OnePlus" };
            Brand apple = new Brand() { Id = 3, Name = "Apple" };

            Phone galaxy = new Phone() { Id = 1, Name = "Galaxy S21", BrandId = samsung.Id, Price = 1000 };
            Phone op9 = new Phone() { Id = 2, Name = "OnePlus 9 Pro", BrandId = oneplus.Id, Price = 900 };
            Phone iphone = new Phone() { Id = 3, Name = "IPhone 12", BrandId = apple.Id, Price = 1200 };

            Headquarter sam = new Headquarter() { Id = 1, BrandId = samsung.Id, City = "Soeul" };
            Headquarter op = new Headquarter() { Id = 2, BrandId = oneplus.Id, City = "Shenzhen" };
            Headquarter ap = new Headquarter() { Id = 3, BrandId = apple.Id, City = "California" };

            modelBuilder.Entity<Brand>().HasData(samsung, oneplus, apple);
            modelBuilder.Entity<Phone>().HasData(galaxy, op9, iphone);
            modelBuilder.Entity<Headquarter>().HasData(sam, op, ap);
        }
    }
}
