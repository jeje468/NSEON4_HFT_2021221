using NSEON4_HFT_2021221.Models;
using System.Linq;

namespace NSEON4_HFT_2021221.Repository
{
    interface IHeadquarterRepository
    {
        void Create(Headquarter headquarter);
        void Delete(int id);
        Headquarter Read(int id);
        IQueryable<Headquarter> ReadAll();
        void Update(Headquarter headquarter);
    }
}