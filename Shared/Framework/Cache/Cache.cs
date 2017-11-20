using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Cache
{
    /// <summary>
    ///     Manage cache class
    /// </summary>
    public static class Cache
    {
        /// <summary>
        ///     Memory cache var
        /// </summary>
        private static Dictionary<string, object> cache = new Dictionary<string, object>();

        /// <summary>
        ///     Add data to the cache
        /// </summary>
        /// <param name="key">Key for the data to store</param>
        /// <param name="value">Data to store</param>
        public static void Add(string key, object value)
        {
            // TODO save in db if configured
            try {
                cache.Add(key, value);
            } catch(ArgumentNullException ex) {
                throw ex;
            } catch(ArgumentException ex) {
                cache[key] = value;
            }
        }

        /// <summary>
        ///     Remove data from the cache
        /// </summary>
        /// <param name="key">Key for the data to remove</param>
        public static void Remove(string key)
        {
            // TODO remove from db if configured
            cache.Remove(key);
        }

        public static object Get(string key)
        {
            // TODO find in db if configured
            object value = null;
            try
            {
                value = cache[key];
            }
            catch
            {
                value = null;
            }
            return value;
        }

        public static void Flush()
        {
            // TODO flush cache from db if configured
            cache = new Dictionary<string, object>();
        }
    }
}
