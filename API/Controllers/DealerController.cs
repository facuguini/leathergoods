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
    public class DealerController : Controller
    {
        DealerBusiness business = new DealerBusiness();

        [HttpGet]
        public IEnumerable<Dealer> GetList()
        {
            return business.GetList();
        }

        [HttpGet("{id}")]
        public Dealer GetById(int id)
        {
            return business.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public Dealer Create(Dealer dealer)
        {
            return business.Create(dealer);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit(Dealer dealer)
        {
            business.Edit(dealer);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            business.Delete(id);
        }
    }
}
