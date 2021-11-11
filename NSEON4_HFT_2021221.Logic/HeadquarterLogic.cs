using NSEON4_HFT_2021221.Models;
using NSEON4_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Logic
{
    public class HeadquarterLogic : IHeadquarterLogic
    {
        IHeadquarterRepository headquarterRepo;
        public HeadquarterLogic(IHeadquarterRepository headquarterRepo)
        {
            this.headquarterRepo = headquarterRepo;
        }

        public void Create(Headquarter headquarter)
        {
            if (headquarter.City == "")
            {
                throw new ArgumentException("Invalid headquarter name");
            }
            headquarterRepo.Create(headquarter);
        }

        public Headquarter Read(int id)
        {
            return headquarterRepo.Read(id);
        }

        public IEnumerable<Headquarter> ReadAll()
        {
            return headquarterRepo.ReadAll();
        }

        public void Delete(int id)
        {
            headquarterRepo.Delete(id);
        }

        public void Update(Headquarter headquarter)
        {
            headquarterRepo.Update(headquarter);
        }
    }
}
