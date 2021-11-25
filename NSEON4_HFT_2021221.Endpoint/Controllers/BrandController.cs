﻿using Microsoft.AspNetCore.Mvc;
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
    public class BrandController : ControllerBase
    {

        IBrandLogic bl;

        public BrandController(IBrandLogic bl)
        {
            this.bl = bl;
        }

        // GET: /brand
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return bl.ReadAll();
        }

        // GET /brand/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            return bl.Read(id);
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Brand value)
        {
            bl.Create(value);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            bl.Update(value);
        }

        // DELETE /brand/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.Delete(id);
        }
    }
}
