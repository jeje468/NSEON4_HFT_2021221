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
    public class HeadquarterController : ControllerBase
    {

        IHeadquarterLogic hl;

        public HeadquarterController(IHeadquarterLogic hl)
        {
            this.hl = hl;
        }

        // GET: /headquarter
        [HttpGet]
        public IEnumerable<Headquarter> Get()
        {
            return hl.ReadAll();
        }

        // GET /headquarter/5
        [HttpGet("{id}")]
        public Headquarter Get(int id)
        {
            return hl.Read(id);
        }

        // POST /headquarter
        [HttpPost]
        public void Post([FromBody] Headquarter value)
        {
            hl.Create(value);
        }

        // PUT /headquarter
        [HttpPut("{id}")]
        public void Put([FromBody] Headquarter value)
        {
            hl.Update(value);
        }

        // DELETE /headquarter/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            hl.Delete(id);
        }
    }
}
