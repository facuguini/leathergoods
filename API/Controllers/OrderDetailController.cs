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
    public class OrderDetailController : Controller
    {
        OrderDetailBusiness business = new OrderDetailBusiness();

        [HttpGet]
        public IEnumerable<OrderDetail> GetList()
        {
            return business.GetList();
        }

        [HttpGet("{id}")]
        public OrderDetail GetById(int id)
        {
            return business.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public OrderDetail Create(OrderDetail orderDetail)
        {
            return business.Create(orderDetail);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit(OrderDetail orderDetail)
        {
            business.Edit(orderDetail);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            business.Delete(id);
        }
    }
}
