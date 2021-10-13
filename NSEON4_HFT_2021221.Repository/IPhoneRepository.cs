using NSEON4_HFT_2021221.Models;
using System.Linq;

namespace NSEON4_HFT_2021221.Repository
{
    interface IPhoneRepository
    {
        void Create(Phone phone);
        void Delete(int id);
        Phone Read(int id);
        IQueryable<Phone> ReadAll();
        void Update(Phone phone);
    }
}