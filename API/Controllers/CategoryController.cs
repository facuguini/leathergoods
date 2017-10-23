using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Framework;
using Business;

namespace API.Controllers
{
    [Route("v1/[controller]")]
    public class CategoryController : Controller
    {
        CategoryBusiness business = new CategoryBusiness();
        // GET api/Category
        [HttpGet]
        public IEnumerable<Category> GetList()
        {
            return business.GetList();
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public Category GetById(int id)
        {
            return business.GetById(id);
        }

        // POST api/category/create
        [HttpPost]
        [Route("create")]
        public void Create([FromBody]Category category)
        {
            business.Create(category);
        }

        // PUT api/category/edit/5
        [HttpPut]
        [Route("edit")]
        public void Edit([FromBody]Category category)
        {
            business.Update(category);
        }

        // DELETE api/category/delete/5
        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            business.Delete(id);
        }
    }
}
