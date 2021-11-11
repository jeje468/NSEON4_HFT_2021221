using NSEON4_HFT_2021221.Models;
using NSEON4_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEON4_HFT_2021221.Logic
{
    public class PhoneLogic : IPhoneLogic
    {
        IPhoneRepository phoneRepo;
        public PhoneLogic(IPhoneRepository phoneRepo)
        {
            this.phoneRepo = phoneRepo;
        }

        public void Create(Phone phone)
        {
            if (phone.Name == "")
            {
                throw new ArgumentException("Invalid phone name");
            }
            phoneRepo.Create(phone);
        }

        public Phone Read(int id)
        {
            return phoneRepo.Read(id);
        }

        public IEnumerable<Phone> ReadAll()
        {
            return phoneRepo.ReadAll();
        }

        public void Delete(int id)
        {
            phoneRepo.Delete(id);
        }

        public void Update(Phone phone)
        {
            phoneRepo.Update(phone);
        }

        public IEnumerable<KeyValuePair<string, int>> NumberOfPhonesByBrands()
        {
            return from x in phoneRepo.ReadAll()
                   group x by x.Brand.Name into g
                   select new KeyValuePair<string, int>(g.Key, g.Count());
        }
    }
}
