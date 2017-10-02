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
    public class CategoryProcess : ProcessComponent
    {
        const String baseUrl = "api/category/";
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> SelectList()
        {
            var response = HttpGet<List<Category>>(baseUrl, new Dictionary<string, object>(), MediaType.Json);
            return response;
        }
        /// <summary>
        /// FindByID
        /// </summary>
        /// <returns></returns>
        public Category FindByID(int id)
        {
            var response = HttpGet<Category>(baseUrl + id, new Dictionary<string, object>(), MediaType.Json);
            return response;
        }
        /// <summary>
        /// Add category
        /// </summary>
        /// <param name="category"></param>
        public void Add (Category category)
        {
            var response = HttpPost<Category>(baseUrl + "Add/", category, MediaType.Json);
        }
        /// <summary>
        /// Edit a category
        /// </summary>
        /// <returns></returns>
        public void Edit(Category category)
        {
            var response = HttpPut<Category>(baseUrl + "Edit/", category, MediaType.Json);
        }
        /// <summary>
        /// Delete a category
        /// </summary>
        /// <returns></returns>
        public void Delete(Category category)
        {
            HttpDelete<Category>(baseUrl + "Remove/" + category.Id, MediaType.Json);
        }
    }
}