﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DexLK.API.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                  // .UseUrls("http://localhost:9000");
                })
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.SetBasePath(hostContext.HostingEnvironment.ContentRootPath)
                          .AddJsonFile("configuration.json", optional: false, reloadOnChange: true);
                         // .AddEnvironmentVariables();
                });
    }
}
