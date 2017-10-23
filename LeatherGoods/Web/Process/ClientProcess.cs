using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Entities;
using Web.Process;

namespace Web.Process
{
    public class ClientProcess : ProcessComponent
    {
        const String baseUrl = "/Client/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Client> SelectList()
        {
            var response = HttpGet<List<Client>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Client Find(int id)
        {
            var response = HttpGet<Client>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Client client)
        {
            var response = HttpPost<Client>(baseUrl + "create/", client, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Client client)
        {
            var response = HttpPut<Client>(baseUrl + "edit/", client, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            HttpDelete<Client>(baseUrl + "delete/" + id, MediaType.Json);
        }
    }
}
