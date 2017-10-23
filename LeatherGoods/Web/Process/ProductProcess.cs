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
    public class ProductProcess : ProcessComponent
    {
        const string baseUrl = "/Product/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Product> SelectList()
        {
            return HttpGet<List<Product>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Product Find(int id)
        {
            return HttpGet<Product>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Product product)
        {
            var response = HttpPost<Product>(baseUrl + "create/", product, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Product product)
        {
            var response = HttpPut<Product>(baseUrl + "edit/", product, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            HttpDelete<Product>(baseUrl + "delete/" + id, MediaType.Json);
        }
    }
}
