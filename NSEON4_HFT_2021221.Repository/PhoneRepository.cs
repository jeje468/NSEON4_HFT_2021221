using NSEON4_HFT_2021221.Data;
using NSEON4_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Repository
{
    public class PhoneRepository : IPhoneRepository
    {
        PhoneDbContext db;

        public PhoneRepository(PhoneDbContext db)
        {
            this.db = db;
        }

        public void Create(Phone phone)
        {
            db.Phones.Add(phone);
            db.SaveChanges();
        }

        public Phone Read(int id)
        {
            return db.Phones.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Phone> ReadAll()
        {
            return db.Phones;
        }

        public void Delete(int id)
        {
            var phoneToDelete = Read(id);
            db.Phones.Remove(phoneToDelete);
            db.SaveChanges();
        }

        public void Update(Phone phone)
        {
            var phoneToUpdate = Read(phone.Id);
            phoneToUpdate.Price = phone.Price;
            phoneToUpdate.Name = phone.Name;
            phoneToUpdate.BrandId = phone.BrandId;
            phoneToUpdate.CameraPixels = phone.CameraPixels;
            db.SaveChanges();
        }
    }
}
