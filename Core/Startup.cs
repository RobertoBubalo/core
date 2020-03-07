using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Controllers;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Core
{
    public class Startup
    {

#pragma warning disable IDE0060 // Remove unused parameter
        public Startup (IConfiguration config)
#pragma warning restore IDE0060 // Remove unused parameter
        {
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services)
        {
            //MvcOptions options = new MvcOptions();
            //options.EnableEndpointRouting = false;
            //services.AddMvc(options);
            // the previous code does not work since it won't accept options...
            services.AddMvc(option => option.EnableEndpointRouting = false);//.AddXmlSerializerFormatters();
            // dependency injection
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            // Middleware -> Handles http request or response
            // Short circuiting the middleware

            // Essentially has to be the first MW to be used
            if (env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }

            //app.UseDefaultFiles ();
            app.UseStaticFiles();
            // can be used instead of previous two, but has directory browsing included as well!
            //app.UseFileServer ();

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(configureRoutes =>
            {
                configureRoutes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
