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
    public class OrderController : Controller
    {
        OrderBusiness business = new OrderBusiness();

        [HttpGet]
        public IEnumerable<Order> GetList()
        {
            return business.GetList();
        }

        [HttpGet("{id}")]
        public Order GetById(int id)
        {
            return business.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public Order Create(Order order)
        {
            return business.Create(order);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit(Order order)
        {
            business.Edit(order);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            business.Delete(id);
        }
    }
}
