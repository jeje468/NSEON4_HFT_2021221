using NSEON4_HFT_2021221.Models;
using System;
using System.Collections.Generic;

namespace NSEON4_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:62814");

            int num;

            Console.WriteLine("Welcome to the mobile phone database! Please select one of the options below!");
            do
            {
                Console.WriteLine(
                    "\n0. Finish\n" +
                    "1. Display brands/phones/countries/headquarters\n" +
                    "2. Diplay extra info\n" +
                    "3. Create new brand/phone/country/headquarter\n" +
                    "4. Delete brand/phone/country/headquarter\n" +
                    "5. Read one brand/phone/country/headquarter\n" +
                    "6. Update a brand/phone/country/headquarter\n"
                    );

                num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        Display(rest);
                        break;
                    case 2:
                        DisplayExtraInfo(rest);
                        break; ;
                    case 3:
                        Create(rest);
                        break;
                    case 4:
                        Delete(rest);
                        break;
                    case 5:
                        Read(rest);
                        break;
                    case 6:
                        Update(rest);
                        break;
                    default:
                        break;
                }
            }
            while (num != 0);     
        }


        static void Display(RestService rest)
        {
            Console.WriteLine(
                "What do you wish to display?\n" +
                "1. Brands\n" +
                "2. Phones\n" +
                "3. Countries\n" +
                "4. Headquarters\n");

            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 1:
                    var brands = rest.Get<Brand>("brand");
                    Recorder<Brand> brandRecorder = new Recorder<Brand>(brands);
                    brandRecorder.Write();
                    break;
                case 2:
                    var phones = rest.Get<Phone>("phone");
                    Recorder<Phone> phoneRecorder = new Recorder<Phone>(phones);
                    phoneRecorder.Write();
                    break;
                case 3:
                    var countries = rest.Get<Country>("country");
                    Recorder<Country> countryRecorder = new Recorder<Country>(countries);
                    countryRecorder.Write();
                    break;
                case 4:
                    var headquarters = rest.Get<Headquarter>("headquarter");
                    Recorder<Headquarter> headquarterRecorder = new Recorder<Headquarter>(headquarters);
                    headquarterRecorder.Write();
                    break;
                default:
                    break;
            }
        }
        static void DisplayExtraInfo(RestService rest)
        {
            Console.WriteLine(
                "1. The number of phones manufactured by each brand\n" +
                "2. The best camera by each brand\n" +
                "3. The brand with the most expensive phone\n" +
                "4. The country with the most headquarters\n" +
                "5. The countries and brands that manufacture there\n");

            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 1:
                    var q1 = rest.Get<KeyValuePair<string, int>>("stat/numberofphonesbybrands");
                    foreach (var item in q1)
                    {
                        Console.WriteLine("Brand: " + item.Key + "\t Number: " + item.Value.ToString());
                    }
                    break;
                case 2:
                    var q2 = rest.Get<KeyValuePair<string, string>>("stat/bestcamerabyeachbrand");
                    foreach (var item in q2)
                    {
                        Console.WriteLine("Brand: " + item.Key + "\t Phone: " + item.Value);
                    }
                    break;
                case 3:
                    var q3 = rest.Get<KeyValuePair<string, int>>("stat/brandwiththemostexpensivephone");
                    foreach (var item in q3)
                    {
                        Console.WriteLine("Brand: " + item.Key + "\t Phone: " + item.Value.ToString());
                    }
                    break;
                case 4:
                    var q4 = rest.Get<KeyValuePair<string, int>>("stat/countrywithmostheadquarters");
                    foreach (var item in q4)
                    {
                        Console.WriteLine("Country: " + item.Key + "\t Number: " + item.Value.ToString());
                    }
                    break;
                case 5:
                    var q5 = rest.Get<KeyValuePair<string, IEnumerable<string>>>("stat/countriesandbrandsthatmanufacturethere");
                    foreach (var item in q5)
                    {
                        Console.WriteLine("Country: " + item.Key);
                        foreach (var brand in item.Value)
                        {
                            Console.WriteLine("-" + brand);
                        }
                        Console.WriteLine();
                    }
                    break;
                default:
                    break;
            }
        }
        static void Create(RestService rest)
        {
            Console.WriteLine(
                "What do you wish to create?\n" +
                "1. Brand\n" +
                "2. Phone\n" +
                "3. Country\n" +
                "4. Headquarter\n");

            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 1:
                    var brands = rest.Get<Brand>("brand");
                    Brand newBrand = new Recorder<Brand>(brands).Create();
                    rest.Post<Brand>(newBrand, "brand");                    
                    break;
                case 2:
                    var phones = rest.Get<Phone>("phone");
                    Phone newPhone = new Recorder<Phone>(phones).Create();
                    rest.Post<Phone>(newPhone, "phone");
                    break;
                case 3:
                    var countries = rest.Get<Country>("country");
                    Country newCountry = new Recorder<Country>(countries).Create();
                    rest.Post<Country>(newCountry, "country");
                    break;
                case 4:
                    var headquarters = rest.Get<Headquarter>("headquarter");
                    Headquarter newHeadquarter = new Recorder<Headquarter>(headquarters).Create();
                    rest.Post<Headquarter>(newHeadquarter, "headquarter");
                    break;
                default:
                    break;
            }
        }
        static void Delete(RestService rest)
        {
            Console.WriteLine(
                "What do you wish to Delete?\n" +
                "1. Brand\n" +
                "2. Phone\n" +
                "3. Country\n" +
                "4. Headquarter\n");

            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Which Id number?");

            int id = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 1:
                    var brands = rest.Get<Brand>("brand");
                    rest.Delete(id, "brand");
                    break;
                case 2:
                    var phones = rest.Get<Phone>("phone");
                    rest.Delete(id, "phone");
                    break;
                case 3:
                    var countries = rest.Get<Country>("country");
                    rest.Delete(id, "country");
                    break;
                case 4:
                    var headquarters = rest.Get<Headquarter>("headquarter");
                    rest.Delete(id, "headquarter");
                    break;
                default:
                    break;
            }
        }
        static void Read(RestService rest)
        {
            Console.WriteLine(
               "What do you wish to Read?\n" +
               "1. Brand\n" +
               "2. Phone\n" +
               "3. Country\n" +
               "4. Headquarter\n");

            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Which Id number?");

            int id = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 1:
                    var brands = rest.Get<Brand>("brand");
                    List<Brand> b = new List<Brand>();
                    b.Add(rest.Get<Brand>(id, "brand"));
                    Recorder<Brand> brandRecorder = new Recorder<Brand>(b);
                    brandRecorder.Write();
                    break;
                case 2:
                    var phones = rest.Get<Phone>("phone");
                    List<Phone> p = new List<Phone>();
                    p.Add(rest.Get<Phone>(id, "phone"));
                    Recorder<Phone> phoneRecorder = new Recorder<Phone>(p);
                    phoneRecorder.Write();
                    break;
                case 3:
                    var countries = rest.Get<Country>("country");
                    List<Country> c = new List<Country>();
                    c.Add(rest.Get<Country>(id, "country"));
                    Recorder<Country> countryRecorder = new Recorder<Country>(c);
                    countryRecorder.Write(); 
                    break;
                case 4:
                    var headquarters = rest.Get<Headquarter>("headquarter");
                    List<Headquarter> h = new List<Headquarter>();
                    h.Add(rest.Get<Headquarter>(id, "headquarter"));
                    Recorder<Headquarter> headquarterRecorder = new Recorder<Headquarter>(h);
                    headquarterRecorder.Write(); break;
                default:
                    break;
            }
        }
        static void Update(RestService rest)
        {
            Console.WriteLine(
               "What do you wish to create?\n" +
               "1. Brand\n" +
               "2. Phone\n" +
               "3. Country\n" +
               "4. Headquarter\n");

            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 1:
                    var brands = rest.Get<Brand>("brand");
                    Console.WriteLine("Id: ");
                    int brandId = int.Parse(Console.ReadLine());
                    Brand newBrand = new Recorder<Brand>(brands).Create();
                    newBrand.Id = brandId;
                    rest.Put<Brand>(newBrand, "brand");
                    break;
                case 2:
                    var phones = rest.Get<Phone>("phone");
                    Console.WriteLine("Id: ");
                    int phoneId = int.Parse(Console.ReadLine());
                    Phone newPhone = new Recorder<Phone>(phones).Create();
                    newPhone.Id = phoneId;
                    rest.Put<Phone>(newPhone, "phone");
                    break;
                case 3:
                    var countries = rest.Get<Country>("country");
                    Console.WriteLine("Id: ");
                    int countryId = int.Parse(Console.ReadLine());
                    Country newCountry = new Recorder<Country>(countries).Create();
                    newCountry.Id = countryId;
                    rest.Put<Country>(newCountry, "country");
                    break;
                case 4:
                    var headquarters = rest.Get<Headquarter>("headquarter");
                    Console.WriteLine("Id: ");
                    int headquarterId = int.Parse(Console.ReadLine());
                    Headquarter newHeadquarter = new Recorder<Headquarter>(headquarters).Create();
                    newHeadquarter.Id = headquarterId;
                    rest.Put<Headquarter>(newHeadquarter, "headquarter");
                    break;
                default:
                    break;
            }
        }


    }
}
