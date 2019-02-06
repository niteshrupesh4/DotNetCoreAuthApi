using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DEMOContext db;
        public ValuesController(DEMOContext dbcontext)
        {
            db = dbcontext;
        }
    
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return db.Employee.ToList();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return db.Employee.Where(x => x.Id == id).SingleOrDefault();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
