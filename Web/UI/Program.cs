using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Framework;

namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"))) // TODO make this better
                .UseStartup<Startup>()
                .UseUrls(AppSettings.WebUrl)
                .Build();
    }
}
