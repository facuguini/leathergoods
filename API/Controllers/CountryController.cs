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
    public class CountryController : Controller
    {
        CountryBusiness business = new CountryBusiness();

        [HttpGet]
        public IEnumerable<Country> GetList()
        {
            return business.GetList();
        }

        [HttpGet("{id}")]
        public Country GetById(int id)
        {
            return business.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public Country Create(Country country)
        {
            return business.Create(country);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit(Country country)
        {
            business.Edit(country);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            business.Delete(id);
        }
    }
}
