﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASP.NET_Core_Fundamentals
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                 app.UseDeveloperExceptionPage(); 
            }

            // app.Use( next =>
            // {
            //     return async context => {
            //         logger.LogInformation("Request incoming!");
            //         if (context.Request.Path.StartsWithSegments("/mym"))
            //         {
            //             await context.Response.WriteAsync("Hit!!!");
            //             logger.LogInformation("Request handled!!!");        
            //         }
            //         else 
            //         {
            //             await next(context);
            //             logger.LogInformation("Response outgoing!!!");    
            //         }
            //     };
            // });

            // app.UseWelcomePage(new WelcomePageOptions {
            //     Path="/welcome"
            // });

            // app.UseFileServer();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                // throw new Exception("Unexpected error occurred! XA");   // HC exeption for testing the "DeveloperExceptionPage()"
 
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);

                // TEST PUSH TO GITHUB ERROR HMMMMM
            });
        }
    }
}