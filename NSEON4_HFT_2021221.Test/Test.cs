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

            var phones = new List<Phone>()
            {
                new Phone() { Id = 1, Name = "Galaxy S21", BrandId = samsung.Id, Price = 1000, CameraPixels = 12 , Brand = samsung},
                new Phone() { Id = 2, Name = "OnePlus 9", BrandId = oneplus.Id, Price = 900, CameraPixels = 50, Brand = oneplus },
                new Phone() { Id = 3, Name = "IPhone 12", BrandId = apple.Id, Price = 1200, CameraPixels = 12, Brand = apple },
                new Phone() { Id = 4, Name = "Galaxy Note", BrandId = samsung.Id, Price = 1200, CameraPixels = 12, Brand = samsung },
                new Phone() { Id = 5, Name = "Redmi Note 10 Pro", BrandId = xiaomi.Id, Price = 700, CameraPixels = 64, Brand = xiaomi }
            }.AsQueryable();

            var brands = new List<Brand>();
            brands.Add(samsung);
            brands.Add(oneplus);
            brands.Add(apple);
            brands.Add(xiaomi);

            mockPhoneRepository.Setup((t) => t.ReadAll()).Returns(phones);
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
                new KeyValuePair<string, int>("Samsung", 2),
                new KeyValuePair<string, int>("OnePlus", 1),
                new KeyValuePair<string, int>("Apple", 1),
                new KeyValuePair<string, int>("Xiaomi", 1)
            };

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
