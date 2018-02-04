﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TotalFusionApi.Models;
using Raven.Client.Documents;


namespace TotalFusionApi.Controllers
{
    [Route("api/[controller]")]
    public class MenuItemsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<MenuItem> Get()
        {
            IDocumentStore store = DocumentStoreHolder.Store;

            var session = store.OpenSession();
            var results = session.Advanced.LoadStartingWith<MenuItem>("products/");

            return results;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public MenuItem Get(int id)
        {
            IDocumentStore store = DocumentStoreHolder.Store;

            var session = store.OpenSession();
            var result = session.Load<MenuItem>($"products/{id}");
            
            return result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
