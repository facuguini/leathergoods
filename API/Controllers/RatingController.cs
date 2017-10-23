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
    public class RatingController : Controller
    {
        RatingBusiness business = new RatingBusiness();

        [HttpGet]
        public IEnumerable<Rating> GetList()
        {
            return business.GetList();
        }

        [HttpGet("{id}")]
        public Rating GetById(int id)
        {
            return business.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public Rating Create(Rating rating)
        {
            return business.Create(rating);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit(Rating rating)
        {
            business.Edit(rating);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            business.Delete(id);
        }
    }
}
