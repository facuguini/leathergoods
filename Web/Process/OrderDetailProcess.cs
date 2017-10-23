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
    public class OrderDetailProcess : ProcessComponent
    {
        const string baseUrl = "/OrderDetail/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderDetail> SelectList()
        {
            return HttpGet<List<OrderDetail>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OrderDetail Find(int id)
        {
            return HttpGet<OrderDetail>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(OrderDetail orderDetail)
        {
            var response = HttpPost<OrderDetail>(baseUrl + "create/", orderDetail, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(OrderDetail orderDetail)
        {
            var response = HttpPut<OrderDetail>(baseUrl + "edit/", orderDetail, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            HttpDelete<OrderDetail>(baseUrl + "delete/" + id, MediaType.Json);
        }
    }
}
