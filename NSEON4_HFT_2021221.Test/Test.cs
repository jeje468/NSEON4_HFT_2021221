using Moq;
using NSEON4_HFT_2021221.Logic;
using NSEON4_HFT_2021221.Models;
using NSEON4_HFT_2021221.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Test
{
    [TestFixture]
    public class Test
    {
        PhoneLogic pl;
        BrandLogic bl;
        HeadquarterLogic hl;
        CountryLogic cl;

        [SetUp]
        public void Init()
        {
            var mockPhoneRepository = new Mock<IPhoneRepository>();
            var mockBrandRepository = new Mock<IBrandRepository>();
            var mockHeadquarterRepository = new Mock<IHeadquarterRepository>();
            var mockCountryRepository = new Mock<ICountryRepository>();

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

            Phone galaxy = new Phone() { Id = 1, Name = "Galaxy S21", BrandId = samsung.Id, Price = 1000, CameraPixels = 12, Brand = samsung };
            Phone op9 = new Phone() { Id = 2, Name = "OnePlus 9", BrandId = oneplus.Id, Price = 900, CameraPixels = 50, Brand = oneplus };
            Phone iphone = new Phone() { Id = 3, Name = "IPhone 12", BrandId = apple.Id, Price = 1200, CameraPixels = 12, Brand = apple };
            Phone op9Pro = new Phone() { Id = 4, Name = "OnePlus 9 Pro", BrandId = oneplus.Id, Price = 1100, CameraPixels = 50, Brand = oneplus };
            Phone note = new Phone() { Id = 5, Name = "Galaxy Note", BrandId = samsung.Id, Price = 1200, CameraPixels = 12, Brand = samsung };
            Phone mate = new Phone() { Id = 6, Name = "Mate 40 Pro", BrandId = huawei.Id, Price = 1000, CameraPixels = 50, Brand = huawei };
            Phone redmi = new Phone() { Id = 7, Name = "Redmi Note 10 Pro", BrandId = xiaomi.Id, Price = 700, CameraPixels = 64, Brand = xiaomi };
            Phone p40 = new Phone() { Id = 8, Name = "P40 Lite", BrandId = huawei.Id, Price = 400, CameraPixels = 48, Brand = huawei };
            Phone poco = new Phone() { Id = 9, Name = "Poco F2", BrandId = xiaomi.Id, Price = 600, CameraPixels = 64, Brand = xiaomi };
            Phone nord = new Phone() { Id = 10, Name = "OnePlus Nord2", BrandId = oneplus.Id, Price = 300, CameraPixels = 50, Brand = oneplus };
            Phone xperia10 = new Phone() { Id = 11, Name = "Xperia 10", BrandId = sony.Id, Price = 500, CameraPixels = 13, Brand = sony };
            Phone galaxyA = new Phone() { Id = 12, Name = "Galaxy A52", BrandId = samsung.Id, Price = 400, CameraPixels = 64, Brand = samsung };
            Phone iphonePro = new Phone() { Id = 13, Name = "IPhone 13 Pro", BrandId = apple.Id, Price = 2000, CameraPixels = 12, Brand = apple };
            Phone iphoneSE = new Phone() { Id = 14, Name = "IPhone SE", BrandId = apple.Id, Price = 1000, CameraPixels = 12, Brand = apple };
            Phone mi11 = new Phone() { Id = 15, Name = "Xiaomi Mi 11", BrandId = xiaomi.Id, Price = 900, CameraPixels = 108, Brand = xiaomi };

            Headquarter sam = new Headquarter() { Id = 1, BrandId = samsung.Id, City = "Soeul", CountryId = southKorea.Id };
            Headquarter op = new Headquarter() { Id = 2, BrandId = oneplus.Id, City = "Shenzhen", CountryId = china.Id };
            Headquarter ap = new Headquarter() { Id = 3, BrandId = apple.Id, City = "California", CountryId = usa.Id };
            Headquarter xi = new Headquarter() { Id = 4, BrandId = xiaomi.Id, City = "Beijing", CountryId = china.Id };
            Headquarter hu = new Headquarter() { Id = 5, BrandId = huawei.Id, City = "Shenzhen", CountryId = china.Id };
            Headquarter so = new Headquarter() { Id = 6, BrandId = sony.Id, City = "Tokyo", CountryId = japan.Id };

            var phones = new List<Phone>();
            phones.Add(galaxy);
            phones.Add(op9);
            phones.Add(iphone);
            phones.Add(op9Pro);
            phones.Add(note);
            phones.Add(mate);
            phones.Add(redmi);
            phones.Add(p40);
            phones.Add(poco);
            phones.Add(nord);
            phones.Add(xperia10);
            phones.Add(galaxyA);
            phones.Add(iphonePro);
            phones.Add(iphoneSE);
            phones.Add(mi11);

            samsung.Phones.Add(galaxy);
            samsung.Phones.Add(note);
            samsung.Phones.Add(galaxyA);

            oneplus.Phones.Add(op9);
            oneplus.Phones.Add(op9Pro);
            oneplus.Phones.Add(nord);

            apple.Phones.Add(iphone);
            apple.Phones.Add(iphonePro);
            apple.Phones.Add(iphoneSE);

            xiaomi.Phones.Add(redmi);
            xiaomi.Phones.Add(poco);
            xiaomi.Phones.Add(mi11);

            huawei.Phones.Add(mate);
            huawei.Phones.Add(p40);

            sony.Phones.Add(xperia10);

            var brands = new List<Brand>();
            brands.Add(samsung);
            brands.Add(oneplus);
            brands.Add(apple);
            brands.Add(xiaomi);
            brands.Add(huawei);
            brands.Add(sony);

            mockPhoneRepository.Setup((t) => t.ReadAll()).Returns(phones.AsQueryable());
            mockBrandRepository.Setup((t) => t.ReadAll()).Returns(brands.AsQueryable());
            pl = new PhoneLogic(mockPhoneRepository.Object);
            bl = new BrandLogic(mockBrandRepository.Object);

        }

        [Test]
        public void PhoneCreateThrowsException()
        {            
            Assert.That(() => 
            pl.Create(new Phone() { Name =""}), Throws.Exception);
        }

        [Test]
        public void NumberOfPhonesByBrand()
        {
            var result = pl.NumberOfPhonesByBrands();

            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Samsung", 3),
                new KeyValuePair<string, int>("OnePlus", 3),
                new KeyValuePair<string, int>("Apple", 3),
                new KeyValuePair<string, int>("Huawei", 2),
                new KeyValuePair<string, int>("Xiaomi", 3),
                new KeyValuePair<string, int>("Sony", 1)
            };

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
