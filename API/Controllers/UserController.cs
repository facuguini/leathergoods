using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Framework;
using Business;
using Framework.Cache;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        UserBusiness business = new UserBusiness();

        [HttpGet]
        public IEnumerable<User> GetList()
        {
            return business.GetList();
        }

        [HttpGet("{id}")]
        public User GetById(int id)
        {
            return business.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public User Create(User User)
        {
            return business.Create(User);
        }

        [HttpPost]
        [Route("login")]
        public User LogIn(User User)
        {
            return business.LogIn(User);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit(User User)
        {
            business.Edit(User);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Remove(int id)
        {
            business.Delete(id);
        }
    }
}
