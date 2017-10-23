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
    public class CountryProcess : ProcessComponent
    {
        const String baseUrl = "/Country/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Country> SelectList()
        {
            return HttpGet<List<Country>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Country Find(int id)
        {
            return HttpGet<Country>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Country country)
        {
            var response = HttpPost<Country>(baseUrl + "create/", country, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Country country)
        {
            var response = HttpPut<Country>(baseUrl + "edit/", country, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            HttpDelete<Country>(baseUrl + "delete/" + id, MediaType.Json);
        }
    }
}
