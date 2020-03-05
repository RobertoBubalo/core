using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Core
{
    public class Startup
    {
        private IConfiguration _config;
        private IServiceCollection _services;

        public Startup (IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services)
        {
            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            // Middleware -> Handles http request or response
            // Short circuiting the middleware

            if (env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }

            app.UseDefaultFiles ();
            app.UseStaticFiles ();

            // can be used instead of previous two, but has directory browsing included as well!
            //app.UseFileServer ();

            app.Use (async (context, next) =>
            {
                logger.LogInformation ("mw1: Incoming request");
                await next ();
                logger.LogInformation ("mw1: Outgoing response");
            });

            app.Use (async (context, next) =>
            {
                logger.LogInformation ("mw2: Incoming request");
                await next ();
                logger.LogInformation ("mw2: Outgoing response");
            });

            app.Run (async (context) =>
            {
                await context.Response.WriteAsync ("Hello from second middleware!");
            });
        }
    }
}
