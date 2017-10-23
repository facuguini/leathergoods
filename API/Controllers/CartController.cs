using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Framework;
using Business;
using System.Net.Http;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        CartBusiness business = new CartBusiness();

        [HttpGet]
        public IEnumerable<Cart> GetList()
        {
            return business.GetList();
        }

        [HttpGet("{id}")]
        public Cart GetById(int id)
        {
            return business.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public Cart Create(Cart cart)
        {
            return business.Create(cart);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit([FromBody]Cart cart)
        {
            business.Edit(cart);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            business.Delete(id);
        }
    }
}
