using NSEON4_HFT_2021221.Models;
using System.Collections.Generic;

namespace NSEON4_HFT_2021221.Logic
{
    public interface IPhoneLogic
    {
        void Create(Phone phone);
        void Delete(int id);
        Phone Read(int id);
        IEnumerable<Phone> ReadAll();
        void Update(Phone phone);
        IEnumerable<KeyValuePair<string, int>> NumberOfPhonesByBrands();
    }
}