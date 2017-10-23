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

        public static string ConnectionString
        {
            get
            {
                return Environment.GetEnvironmentVariable("CONNECTION_STRING");
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
