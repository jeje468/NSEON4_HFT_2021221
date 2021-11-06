using NSEON4_HFT_2021221.Data;
using NSEON4_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Repository
{
    public class CountryRepository : ICountryRepository
    {
        PhoneDbContext db;

        public CountryRepository(PhoneDbContext db)
        {
            this.db = db;
        }

        public void Create(Country country)
        {
            db.Countries.Add(country);
            db.SaveChanges();
        }

        public Country Read(int id)
        {
            return db.Countries.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Country> ReadAll()
        {
            return db.Countries;
        }

        public void Delete(int id)
        {
            var countryToDelete = Read(id);
            db.Countries.Remove(countryToDelete);
            db.SaveChanges();
        }

        public void Update(Country country)
        {
            var countryToUpdate = Read(country.Id);
            countryToUpdate.Continent = country.Continent;
            countryToUpdate.Name = country.Name;
            db.SaveChanges();
        }
    }
}
