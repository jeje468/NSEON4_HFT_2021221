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
    public class PhoneController : ControllerBase
    {

        IPhoneLogic pl;
        IHubContext<SignalRHub> hub;

        public PhoneController(IPhoneLogic pl, IHubContext<SignalRHub> hub)
        {
            this.pl = pl;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("PhoneCreated", value);
        }

        // PUT /phone
        [HttpPut]
        public void Put([FromBody] Phone value)
        {
            pl.Update(value);
            this.hub.Clients.All.SendAsync("PhoneUpdated", value);
        }

        // DELETE /phone/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var phoneToDelete = this.pl.Read(id);
            pl.Delete(id);
            this.hub.Clients.All.SendAsync("PhoneDeleted", phoneToDelete);

        }
    }
}
