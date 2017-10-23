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
    public class OrderNumberProcess : ProcessComponent
    {
        const string baseUrl = "/OrderNumber/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderNumber> SelectList()
        {
            return HttpGet<List<OrderNumber>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OrderNumber Find(int id)
        {
            return HttpGet<OrderNumber>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(OrderNumber orderNumber)
        {
            var response = HttpPost<OrderNumber>(baseUrl + "create/", orderNumber, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(OrderNumber orderNumber)
        {
            var response = HttpPut<OrderNumber>(baseUrl + "edit/", orderNumber, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            HttpDelete<OrderNumber>(baseUrl + "delete/" + id, MediaType.Json);
        }
    }
}
