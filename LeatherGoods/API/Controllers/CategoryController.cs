using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        List<Category> list = new List<Category>();
        // GET api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return list;
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return list.FirstOrDefault(x => x.Id == id);
        }

        // POST api/category/create
        [HttpPost]
        [Route("create")]
        public void Post([FromBody]Category category)
        {
            list.Add(category);
        }

        // PUT api/category/edit/5
        [HttpPut("{id}")]
        [Route("edit")]
        public void Put(int id, [FromBody]Category category)
        {
            var _category = list.FirstOrDefault(x => x.Id == id);
            _category = category;
        }

        // DELETE api/category/delete/5
        [HttpDelete("{id}")]
        [Route("delete")]
        public void Delete(int id)
        {
            list.Remove(list.FirstOrDefault(x => x.Id == id));
        }
    }
}
