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
    [Route("api/[controller]")]
    public class CartItemController : Controller
    {
        CartItemBusiness business = new CartItemBusiness();

        [HttpGet]
        public List<CartItem> GetList()
        {
            return business.GetList();
        }

        [HttpGet("{id}")]
        public CartItem Find(int id)
        {
            return business.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public CartItem Create(CartItem cartItem)
        {
            return business.Create(cartItem);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit(CartItem cartItem)
        {
            business.Edit(cartItem);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            business.Delete(id);
        }
    }
}
