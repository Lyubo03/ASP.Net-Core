using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Middleware.Middlewears;

namespace Middleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.Map("/Map", appBuilder =>

            //        appBuilder.Run(async (context) => await context.Response.WriteAsync("$#!?"))
            //    );

            app.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("I am waiting.." + Environment.NewLine);

                    await next();

                    await context.Response.WriteAsync("Thank you for saving me from this waiting!");
                });

            // There is no next concept (this is the end)
            app.Run(ReturnHello);
        }
        public async Task ReturnHello(HttpContext context)
        {
            await context.Response.WriteAsync("Hello from My program" + Environment.NewLine);
        }
    }
}