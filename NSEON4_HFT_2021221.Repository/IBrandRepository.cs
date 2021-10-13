using NSEON4_HFT_2021221.Models;
using System.Linq;

namespace NSEON4_HFT_2021221.Repository
{
    interface IBrandRepository
    {
        void Create(Brand brand);
        void Delete(int id);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand brand);
    }
}