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
    public class RatingProcess : ProcessComponent
    {
        const string baseUrl = "/Rating/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Rating> SelectList()
        {
            return HttpGet<List<Rating>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Rating Find(int id)
        {
            return HttpGet<Rating>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Rating rating)
        {
            var response = HttpPost<Rating>(baseUrl + "create/", rating, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Rating rating)
        {
            var response = HttpPut<Rating>(baseUrl + "edit/", rating, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            HttpDelete<Rating>(baseUrl + "delete/" + id, MediaType.Json);
        }
    }
}
