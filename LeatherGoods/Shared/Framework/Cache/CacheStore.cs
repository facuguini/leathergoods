using Framework.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Cache
{
    public class CacheStore
    {
        private static Database _store;

        public static void SetStore(Database store)
        {
            _store = store;
        }

        public void Add(string key, object value)
        {
            // TODO add to db
        }

        public void Remove(string key)
        {
            // TODO remove from db
        }

        public object Get(string key)
        {
            // TODO get from db
            return null;
        }

        public void Flush()
        {
            // TODO flush from db
        }
    }
}
