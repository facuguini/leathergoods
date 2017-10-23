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
    public class SettingController : Controller
    {
        SettingBusiness business = new SettingBusiness();

        [HttpGet]
        public IEnumerable<Setting> GetList()
        {
            return business.GetList();
        }

        [HttpGet("{id}")]
        public Setting GetById(int id)
        {
            return business.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public Setting Create(Setting setting)
        {
            return business.Create(setting);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit(Setting setting)
        {
            business.Edit(setting);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Remove(int id)
        {
            business.Delete(id);
        }
    }
}
