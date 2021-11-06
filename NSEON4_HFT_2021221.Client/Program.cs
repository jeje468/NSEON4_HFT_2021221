using NSEON4_HFT_2021221.Data;
using NSEON4_HFT_2021221.Logic;
using NSEON4_HFT_2021221.Repository;
using System;

namespace NSEON4_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneDbContext db = new PhoneDbContext();

            PhoneLogic phoneLogic = new PhoneLogic(new PhoneRepository(db));

            BrandLogic brandLogic = new BrandLogic(new BrandRepository(db));

            HeadquarterLogic headquarterLogic = new HeadquarterLogic(new HeadquarterRepository(db));

            CountryLogic countryLogic = new CountryLogic(new CountryRepository(db));

            var q = headquarterLogic.ReadAll();
            ;
        }
    }
}
