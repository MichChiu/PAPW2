using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PAPW2_PROJECT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        // GET: api/<NoticiasController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<NoticiasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NoticiasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NoticiasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NoticiasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
