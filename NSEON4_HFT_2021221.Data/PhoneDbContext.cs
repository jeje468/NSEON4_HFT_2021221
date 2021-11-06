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
        public virtual DbSet<Country> Countries { get; set; }

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

            modelBuilder.Entity<Headquarter>(entity =>
            {
                entity
                .HasOne(Headquarter => Headquarter.Country)
                .WithMany(country => country.Headquarters)
                .HasForeignKey(Headquarter => Headquarter.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            Brand samsung = new Brand() { Id = 1, Name = "Samsung" };
            Brand oneplus = new Brand() { Id = 2, Name = "OnePlus" };
            Brand apple = new Brand() { Id = 3, Name = "Apple" };
            Brand xiaomi = new Brand() { Id = 4, Name = "Xiaomi" };
            Brand huawei = new Brand() { Id = 5, Name = "Huawei" };
            Brand sony = new Brand() { Id = 6, Name = "Sony" };

            Country china = new Country() { Id = 1, Name = "China", Continent = "Asia" };
            Country usa = new Country() { Id = 2, Name = "USA", Continent = "North America" };
            Country southKorea = new Country() { Id = 3, Name = "South Korea", Continent = "Asia" };
            Country japan = new Country() { Id = 4, Name = "Japan", Continent = "Asia" };

            Phone galaxy = new Phone() { Id = 1, Name = "Galaxy S21", BrandId = samsung.Id, Price = 1000, CameraPixels = 12 };
            Phone op9 = new Phone() { Id = 2, Name = "OnePlus 9", BrandId = oneplus.Id, Price = 900, CameraPixels = 50 };
            Phone iphone = new Phone() { Id = 3, Name = "IPhone 12", BrandId = apple.Id, Price = 1200, CameraPixels = 12 };
            Phone op9Pro = new Phone() { Id = 4, Name = "OnePlus 9 Pro", BrandId = oneplus.Id, Price = 1100, CameraPixels = 50 };
            Phone note = new Phone() { Id = 5, Name = "Galaxy Note", BrandId = samsung.Id, Price = 1200, CameraPixels = 12 };
            Phone mate = new Phone() { Id = 6, Name = "Mate 40 Pro", BrandId = huawei.Id, Price = 1000, CameraPixels = 50 };
            Phone redmi = new Phone() { Id = 7, Name = "Redmi Note 10 Pro", BrandId = xiaomi.Id, Price = 700, CameraPixels = 64 };
            Phone p40 = new Phone() { Id = 8, Name = "P40 Lite", BrandId = huawei.Id, Price = 400, CameraPixels = 48 };
            Phone poco = new Phone() { Id = 9, Name = "Poco F2", BrandId = xiaomi.Id, Price = 600, CameraPixels = 64 };
            Phone nord = new Phone() { Id = 10, Name = "OnePlus Nord2", BrandId = oneplus.Id, Price = 300, CameraPixels = 50 };
            Phone xperia10 = new Phone() { Id = 11, Name = "Xperia 10", BrandId = sony.Id, Price = 500, CameraPixels = 13 };
            Phone galaxyA = new Phone() { Id = 12, Name = "Galaxy A52", BrandId = samsung.Id, Price = 400, CameraPixels = 64 };
            Phone iphonePro = new Phone() { Id = 13, Name = "IPhone 13 Pro", BrandId = apple.Id, Price = 2000, CameraPixels = 12};
            Phone iphoneSE = new Phone() { Id = 14, Name = "IPhone SE", BrandId = apple.Id, Price = 1000, CameraPixels = 12};
            Phone mi11 = new Phone() { Id = 15, Name = "Xiaomi Mi 11", BrandId = xiaomi.Id, Price = 900, CameraPixels = 108 };




            Headquarter sam = new Headquarter() { Id = 1, BrandId = samsung.Id, City = "Soeul" , CountryId = southKorea.Id};
            Headquarter op = new Headquarter() { Id = 2, BrandId = oneplus.Id, City = "Shenzhen" , CountryId = china.Id};
            Headquarter ap = new Headquarter() { Id = 3, BrandId = apple.Id, City = "California", CountryId = usa.Id};
            Headquarter xi = new Headquarter() { Id = 4, BrandId = xiaomi.Id, City = "Beijing", CountryId = china.Id };
            Headquarter hu = new Headquarter() { Id = 5, BrandId = huawei.Id, City = "Shenzhen", CountryId = china.Id };
            Headquarter so = new Headquarter() { Id = 6, BrandId = sony.Id, City = "Tokyo", CountryId = japan.Id };

            modelBuilder.Entity<Brand>().HasData(samsung, oneplus, apple, xiaomi, huawei, sony);
            modelBuilder.Entity<Phone>().HasData(galaxy, op9, iphone, op9Pro, note, mate, redmi, p40, poco, nord, xperia10, galaxyA, iphonePro, iphoneSE, mi11);
            modelBuilder.Entity<Headquarter>().HasData(sam, op, ap, xi, hu, so);
            modelBuilder.Entity<Country>().HasData(china, usa, southKorea, japan);
        }
    }
}
