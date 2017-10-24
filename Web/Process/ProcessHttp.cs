using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using Framework;
using Newtonsoft.Json;

namespace Web.Process
{
    /// <summary>
    /// Base class for UI Controllers (not the ASP.NET MVC Controllers).
    /// This class is purposely renamed to ProcessComponent to avoid confusion from the MVC controllers.
    /// </summary>
    public abstract class ProcessComponent
    {
        private static string baseUrl = AppSettings.APIUrl;
        /// <summary>
        /// Sends a Http Get request to a URL with querystring style parameters.
        /// </summary>
        /// <typeparam name="T">The returned type from the call.</typeparam>
        /// <param name="path">The path to the service.</param>
        /// <param name="parameters">A dictionary containing the parameters and values to form the query.</param>
        /// <param name="mediaType">The media type to use i.e. application/xml or application/json.</param>
        /// <returns>An object specified in the generic type.</returns>
        protected static T HttpGet<T>(string path, Dictionary<string, object> parameters, string mediaType)
        {
            return HttpGet<T>(GetPathAndQuery(path, parameters), mediaType);
        }

        /// <summary>
        /// Sends a Http Get request to a URL.
        /// </summary>
        /// <typeparam name="T">The returned type from the call.</typeparam>
        /// <param name="pathAndQuery">The path and query to call.</param>
        /// <param name="mediaType">The media type to use i.e. application/xml or application/json.</param>
        /// <returns>An object specified in the generic type.</returns>
        private static T HttpGet<T>(string pathAndQuery, string mediaType)
        {
            T result = default(T);
            using (HttpClient client = new HttpClient())
            {
                var url = baseUrl + pathAndQuery;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                var response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();
                result = ParseResponse<T>(response.Content.ReadAsStringAsync().Result);
            }
            return result;
        }

        public static T HttpPost<T>(string path, T value, string mediaType)
        {
            var pathAndQuery = path.EndsWith("/") ? path : path + "/";
            using (var client = new HttpClient())
            {
                var url = baseUrl + pathAndQuery;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                var response = client.PostAsync(url, ParseObject<T>(value)).Result;
                response.EnsureSuccessStatusCode();
                return value;
            }
        }

        public static T HttpPut<T>(string path, T value, string mediaType)
        {
            var pathAndQuery = path.EndsWith("/") ? path : path + "/";
            using (var client = new HttpClient())
            {
                var url = baseUrl + pathAndQuery;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                var response = client.PutAsync(url, ParseObject<T>(value)).Result;
                response.EnsureSuccessStatusCode();
                return value;
            }
        }
        public static void HttpDelete<T>(string path, Dictionary<string, object> parameters, string mediaType)
        {
            using (var client = new HttpClient())
            {
                var url = baseUrl + GetPathAndQuery(path, parameters);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                var response = client.DeleteAsync(url).Result;
                response.EnsureSuccessStatusCode();
            }
        }
        public static void HttpDelete<T>(string path, string mediaType)
        {
            using (var client = new HttpClient())
            {
                var url = baseUrl + GetPathAndQuery(path);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
                var response = client.DeleteAsync(url).Result;
                response.EnsureSuccessStatusCode();
            }
        }

        private static T ParseResponse<T>(string data) {
            return JsonConvert.DeserializeObject<T>(data);
        }

        private static HttpContent ParseObject<T>(T data) {
            return new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        }

        private static string GetPathAndQuery(string path, Dictionary<string, object> parameters = null) {
            if (parameters == null) parameters = new Dictionary<string, object>();
            UriBuilder builder = new UriBuilder
            {
                Path = path,
                Query = string.Join("&", parameters.Where(p => p.Value != null)
                    .Select(p => string.Format("{0}={1}",
                        HttpUtility.UrlEncode(p.Key),
                        HttpUtility.UrlEncode(p.Value.ToString()))))
            };
            return builder.Uri.PathAndQuery;
        }
    }
}
