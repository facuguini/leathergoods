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
    public class SettingProcess : ProcessComponent
    {
        const string baseUrl = "/Setting/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Setting> SelectList()
        {
            return HttpGet<List<Setting>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Setting Find(int id)
        {
            return HttpGet<Setting>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Setting setting)
        {
            var response = HttpPost<Setting>(baseUrl + "create/", setting, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Setting setting)
        {
            var response = HttpPut<Setting>(baseUrl + "edit/", setting, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            HttpDelete<Setting>(baseUrl + "delete/" + id, MediaType.Json);
        }
    }
}
