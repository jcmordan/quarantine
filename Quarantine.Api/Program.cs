using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Quarantine.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var directory = Directory.GetCurrentDirectory();
                    
                    config.SetBasePath(directory);
                    
                    config.AddJsonFile(directory + "/appsettings.json", false);
                    config.AddJsonFile(directory + "/appsettings.Development.json", false);
                    config.AddEnvironmentVariables();
                    config.AddCommandLine(args);
                    
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}