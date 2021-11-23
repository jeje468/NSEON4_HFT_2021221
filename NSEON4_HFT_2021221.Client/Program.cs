﻿using NSEON4_HFT_2021221.Models;
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

            //rest.Post<Brand>(new Brand() { Name = "Google" }, "brand");

            //var brands = rest.Get<Brand>("brand");
            //var phones = rest.Get<Phone>("phone");
            //var headquarters = rest.Get<Headquarter>("headquarter");
            //var countries = rest.Get<Country>("country");

            //var q1 = rest.Get<KeyValuePair<string, int>>("stat/numberofphonesbybrands");

            //var q2 = rest.Get<KeyValuePair<string, string>>("stat/bestcamerabyeachbrand");

            //var q3 = rest.Get<KeyValuePair<string, int>>("stat/brandwiththemostexpensivephone");

            //var q4 = rest.Get<KeyValuePair<string, int>>("stat/countrywithmostheadquarters");

            //var q5 = rest.Get<KeyValuePair<string, IEnumerable<string>>>("stat/countriesandbrandsthatmanufacturethere");

            int num;

            Console.WriteLine("Welcome to the mobile phone database! Please select one of the options below!");
            do
            {
                Console.WriteLine(
                    "\n0. Finish\n" +
                    "1. Display brands/phones/countries/headquarters\n" +
                    "2. Diplay extra info\n" +
                    "3. Create new brand/phone/country/headquarter\n"
                    );

                num = int.Parse(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        Display();                        
                        break;                    
                    case 2:
                        DisplayExtraInfo();
                        break;;
                    case 3:
                        Create();
                        break;
                    default:
                        break;
                }
            }
            while(num != 0)
                

            ;

            void Display()
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
            void DisplayExtraInfo()
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
            void Create()
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
        }

        
    }
}
