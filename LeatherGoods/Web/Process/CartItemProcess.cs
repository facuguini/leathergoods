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
    public class CartItemProcess : ProcessComponent
    {
        const String baseUrl = "/CartItem/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CartItem> SelectList()
        {
            var response = HttpGet<List<CartItem>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CartItem Find(int id)
        {
            var response = HttpGet<CartItem>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(CartItem cartItem)
        {
            var response = HttpPost<CartItem>(baseUrl + "create/", cartItem, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(CartItem cartItem)
        {
            var response = HttpPut<CartItem>(baseUrl + "edit/", cartItem, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(CartItem cartItem)
        {
            HttpDelete<CartItem>(baseUrl + "delete/" + cartItem.Id, MediaType.Json);
        }
    }
}
