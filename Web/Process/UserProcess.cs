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
    public class UserProcess : ProcessComponent
    {
        const string baseUrl = "/User/";
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<User> SelectList()
        {
            return HttpGet<List<User>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public User Find(int id)
        {
            return HttpGet<User>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public User LogIn(User user)
        {
            return HttpPost<User>(baseUrl + "login", user, MediaType.Json);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public void Insert(User User)
        {
            var response = HttpPost<User>(baseUrl + "create/", User, MediaType.Json);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public void Edit(User User)
        {
            var response = HttpPut<User>(baseUrl + "edit/", User, MediaType.Json);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            HttpDelete<User>(baseUrl + "delete/" + id, MediaType.Json);
        }
    }
}
