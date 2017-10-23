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
    public class ProductController : Controller
    {
        ProductBusiness business = new ProductBusiness();

        [HttpGet]
        public IEnumerable<Product> GetList()
        {
            return business.GetList();
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return business.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public Product Create(Product product)
        {
            return business.Create(product);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit(Product product)
        {
            business.Edit(product);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            business.Delete(id);
        }
    }
}
