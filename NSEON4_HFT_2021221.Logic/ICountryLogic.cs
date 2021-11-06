using NSEON4_HFT_2021221.Models;
using System.Collections.Generic;

namespace NSEON4_HFT_2021221.Logic
{
    public interface ICountryLogic
    {
        void Create(Country country);
        void Delete(int id);
        Country Read(int id);
        IEnumerable<Country> ReadAll();
        void Update(Country country);
        IEnumerable<KeyValuePair<string, int>> CountryWithMostHeadquarters();
        IEnumerable<KeyValuePair<string, IEnumerable<string>>> CountriesAndBrandsThatManufactureThere();
    }
}