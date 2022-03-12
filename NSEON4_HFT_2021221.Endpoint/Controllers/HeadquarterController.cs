using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NSEON4_HFT_2021221.Endpoint.Services;
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
        IHubContext<SignalRHub> hub;

        public HeadquarterController(IHeadquarterLogic hl, IHubContext<SignalRHub> hub)
        {
            this.hl = hl;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("HeadquarterCreated", value);
        }

        // PUT /headquarter
        [HttpPut]
        public void Put([FromBody] Headquarter value)
        {
            hl.Update(value);
            hub.Clients.All.SendAsync("HeadquarterUpdated", value);
        }

        // DELETE /headquarter/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var headquarterToDelete = this.hl.Read(id);
            hl.Delete(id);
            hub.Clients.All.SendAsync("HeadquarterDeleted", headquarterToDelete);
        }
    }
}
