using Microsoft.AspNetCore.Mvc;
using NSEON4_HFT_2021221.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NSEON4_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IPhoneLogic pl;
        IBrandLogic bl;
        ICountryLogic cl;

        public StatController(IPhoneLogic pl, IBrandLogic bl, ICountryLogic cl)
        {
            this.pl = pl;
            this.bl = bl;
            this.cl = cl;
        }

        // GET: stat/numberofphonesbybrands
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> NumberOfPhonesByBrands()
        {
            return pl.NumberOfPhonesByBrands();
        }

        // GET: stat/bestcamerabyeachbrand
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> BestCameraByEachBrand()
        {
            return bl.BestCameraByEachBrand();
        }

        //GET: stat/brandwiththemostexpensivephone
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> BrandWithTheMostExpensivePhone()
        {
            return bl.BrandWithTheMostExpensivePhone();
        }

        //GET: stat/countrywithmostheadquarters
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CountryWithMostHeadquarters()
        {
            return cl.CountryWithMostHeadquarters();
        }

        //GET: stat/countriesandbrandsthatmanufacturethere
        [HttpGet]
        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> CountriesAndBrandsThatManufactureThere()
        {
            return cl.CountriesAndBrandsThatManufactureThere();
        }
    }
}
