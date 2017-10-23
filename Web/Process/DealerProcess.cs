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
    public class DealerProcess : ProcessComponent
    {
        const string baseUrl = "/Dealer/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Dealer> SelectList()
        {
            return HttpGet<List<Dealer>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dealer Find(int id)
        {
            return HttpGet<Dealer>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Dealer dealer)
        {
            var response = HttpPost<Dealer>(baseUrl + "create/", dealer, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Dealer dealer)
        {
            var response = HttpPut<Dealer>(baseUrl + "edit/", dealer, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            HttpDelete<Dealer>(baseUrl + "delete/" + id, MediaType.Json);
        }
    }
}
