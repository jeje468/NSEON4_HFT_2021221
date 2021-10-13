using NSEON4_HFT_2021221.Data;
using NSEON4_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Repository
{
    class HeadquarterRepository : IHeadquarterRepository
    {
        PhoneDbContext db;

        public HeadquarterRepository(PhoneDbContext db)
        {
            this.db = db;
        }

        public void Create(Headquarter headquarter)
        {
            db.Headquarters.Add(headquarter);
            db.SaveChanges();
        }

        public Headquarter Read(int id)
        {
            return db.Headquarters.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Headquarter> ReadAll()
        {
            return db.Headquarters;
        }

        public void Delete(int id)
        {
            var headquarterToDelete = Read(id);
            db.Headquarters.Remove(headquarterToDelete);
            db.SaveChanges();
        }

        public void Update(Headquarter headquarter)
        {
            var headquarterToUpdate = Read(headquarter.Id);
            headquarterToUpdate.City = headquarter.City;
            headquarterToUpdate.BrandId = headquarter.BrandId;
            db.SaveChanges();
        }
    }
}
