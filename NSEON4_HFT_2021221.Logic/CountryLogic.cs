﻿using NSEON4_HFT_2021221.Models;
using NSEON4_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Logic
{
    public class CountryLogic : ICountryLogic
    {
        ICountryRepository countryRepo;
        public CountryLogic(ICountryRepository countryRepo)
        {
            this.countryRepo = countryRepo;
        }

        public void Create(Country country)
        {
            if (country.Name == "")
            {
                throw new ArgumentException("Invalid country name");
            }
            countryRepo.Create(country);
        }

        public Country Read(int id)
        {
            return countryRepo.Read(id);
        }

        public IEnumerable<Country> ReadAll()
        {
            return countryRepo.ReadAll();
        }

        public void Delete(int id)
        {
            countryRepo.Delete(id);
        }

        public void Update(Country country)
        {
            countryRepo.Update(country);
        }

        public IEnumerable<KeyValuePair<string, int>> CountryWithMostHeadquarters()
        {
            return (from x in countryRepo.ReadAll().ToList()
                    group x by x into g
                    let cnt = g.Count()
                    orderby cnt descending
                    select new KeyValuePair<string, int>(g.Key.Name, g.Key.Headquarters.Count())).Take(1);
        }

        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> CountriesAndBrandsThatManufactureThere()
        {
            return from x in countryRepo.ReadAll().ToList()
                   group x by x into g
                   let headquarters = g.Key.Headquarters.Select(h => h)
                   let brands = (headquarters.Select(b => b.Brand)).Select(b => b.Name)
                   select new KeyValuePair<string, IEnumerable<string>>(g.Key.Name, brands.OrderBy(b => b));
        }
    }
}
