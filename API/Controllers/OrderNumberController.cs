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
    public class OrderNumberController : Controller
    {
        OrderNumberBusiness business = new OrderNumberBusiness();

        [HttpGet]
        public IEnumerable<OrderNumber> GetList()
        {
            return business.GetList();
        }

        [HttpGet("{id}")]
        public OrderNumber GetById(int id)
        {
            return business.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public OrderNumber Create(OrderNumber orderNumber)
        {
            return business.Create(orderNumber);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit(OrderNumber orderNumber)
        {
            business.Edit(orderNumber);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            business.Delete(id);
        }
    }
}
