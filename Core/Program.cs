using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Core
{
    public class Program
    {
        public static void Main (string[] args)
        {
            CreateWebHostBuilder (args).Build ().Run ();
        }

        // Setting up the web server
        // Loading the host and application configuration from various configuration sources
        // Configures logging
        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
                .UseStartup<Startup> ();
    }
    // An asp.Net core app can be hosted InProcess || OutOfProcess
}