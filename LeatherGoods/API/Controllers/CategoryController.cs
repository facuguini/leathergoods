using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        // GET api/Category
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value" + id;
        }

        // POST api/category
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
