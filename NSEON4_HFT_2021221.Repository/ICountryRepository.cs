using NSEON4_HFT_2021221.Models;
using System.Linq;

namespace NSEON4_HFT_2021221.Repository
{
    public interface ICountryRepository
    {
        void Create(Country country);
        void Delete(int id);
        Country Read(int id);
        IQueryable<Country> ReadAll();
        void Update(Country country);
    }
}