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
    public class ClientController : Controller
    {
        ClientBusiness business = new ClientBusiness();

        [HttpGet]
        public List<Client> GetList()
        {
            return business.GetList();
        }

        [HttpGet("{id}")]
        public Client GetById(int id)
        {
            return business.GetById(id);
        }

        [HttpPost]
        [Route("create")]
        public Client Create(Client client)
        {
            return business.Create(client);
        }

        [HttpPut]
        [Route("edit")]
        public void Edit(Client client)
        {
            business.Edit(client);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            business.Delete(id);
        }
    }
}
