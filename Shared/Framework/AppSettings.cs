using System;

namespace Framework
{
    public static class AppSettings
    {
        public static string Env
        {
            get
            {
                return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            }
        }

        public static string DbProvider
        {
            get
            {
                return Environment.GetEnvironmentVariable("DB_PROVIDER");
            }
        }

        public static string DbConnectionString
        {
            get
            {
                return Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            }
        }

        public static string CacheStoreProvider
        {
            get
            {
                return Environment.GetEnvironmentVariable("CACHE_STORE_PROVIDER");
            }
        }

        public static string CacheStoreConnectionString
        {
            get
            {
                return Environment.GetEnvironmentVariable("CACHE_STORE_CONNECTION_STRING");
            }
        }

        public static string APIUrl
        {
            get
            {
                return Environment.GetEnvironmentVariable("API_URL");
            }
        }

        public static string WebUrl
        {
            get
            {
                return Environment.GetEnvironmentVariable("WEB_URL");
            }
        }


    }
}
