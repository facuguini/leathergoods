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
    public class CartProcess : ProcessComponent
    {
        const String baseUrl = "/Cart/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Cart> SelectList()
        {
            return HttpGet<List<Cart>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Cart Find(int id)
        {
            return HttpGet<Cart>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Cart cart)
        {
            var response = HttpPost<Cart>(baseUrl + "create/", cart, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Cart cart)
        {
            var response = HttpPut<Cart>(baseUrl + "edit/", cart, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(Cart cart)
        {
            HttpDelete<Cart>(baseUrl + "delete/" + cart.Id, MediaType.Json);
        }
    }
}
