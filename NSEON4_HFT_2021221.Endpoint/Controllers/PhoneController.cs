using Microsoft.AspNetCore.Mvc;
using NSEON4_HFT_2021221.Logic;
using NSEON4_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NSEON4_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {

        IPhoneLogic pl;

        public PhoneController(IPhoneLogic pl)
        {
            this.pl = pl;
        }

        // GET: /phone
        [HttpGet]
        public IEnumerable<Phone> Get()
        {
            return pl.ReadAll();
        }

        // GET /phone/5
        [HttpGet("{id}")]
        public Phone Get(int id)
        {
            return pl.Read(id);
        }

        // POST /phone
        [HttpPost]
        public void Post([FromBody] Phone value)
        {
            pl.Create(value);
        }

        // PUT /phone
        [HttpPut("{id}")]
        public void Put([FromBody] Phone value)
        {
            pl.Update(value);
        }

        // DELETE /phone/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
    }
}
