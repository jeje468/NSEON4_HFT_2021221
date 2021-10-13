using NSEON4_HFT_2021221.Models;
using System.Collections.Generic;

namespace NSEON4_HFT_2021221.Logic
{
    public interface IHeadquarterLogic
    {
        void Create(Headquarter headquarter);
        void Delete(int id);
        Headquarter Read(int id);
        IEnumerable<Headquarter> ReadAll();
        void Update(Headquarter headquarter);
    }
}