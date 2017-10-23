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
    public class OrderProcess : ProcessComponent
    {
        const string baseUrl = "/Order/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> SelectList()
        {
            return HttpGet<List<Order>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Order Find(int id)
        {
            return HttpGet<Order>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Order order)
        {
            var response = HttpPost<Order>(baseUrl + "create/", order, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Order order)
        {
            var response = HttpPut<Order>(baseUrl + "edit/", order, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            HttpDelete<Order>(baseUrl + "delete/" + id, MediaType.Json);
        }
    }
}
