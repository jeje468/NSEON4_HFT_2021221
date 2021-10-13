using NSEON4_HFT_2021221.Data;
using NSEON4_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Repository
{
    public class BrandRepository : IBrandRepository
    {
        PhoneDbContext db;

        public BrandRepository(PhoneDbContext db)
        {
            this.db = db;
        }

        public void Create(Brand brand)
        {
            db.Brands.Add(brand);
            db.SaveChanges();
        }

        public Brand Read(int id)
        {
            return db.Brands.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Brand> ReadAll()
        {
            return db.Brands;
        }

        public void Delete(int id)
        {
            var brandToDelete = Read(id);
            db.Brands.Remove(brandToDelete);
            db.SaveChanges();
        }

        public void Update(Brand brand)
        {
            var brandToUpdate = Read(brand.Id);
            brandToUpdate.Name = brand.Name;
            db.SaveChanges();
        }
    }
}
