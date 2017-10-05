using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Business;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        CategoryBusiness business = new CategoryBusiness();
        // GET api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return business.GetList();
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return business.GetById(id);
        }

        // POST api/category/create
        [HttpPost]
        [Route("create")]
        public void Post([FromBody]Category category)
        {
            business.Create(category);
        }

        // PUT api/category/edit/5
        [HttpPut]
        [Route("edit")]
        public void Put([FromBody]Category category)
        {
            business.Update(category);
        }

        // DELETE api/category/delete/5
        [HttpDelete("{id}")]
        [Route("delete")]
        public void Delete(int id)
        {
            business.Delete(id);
        }
    }
}
