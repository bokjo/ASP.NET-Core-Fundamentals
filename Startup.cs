using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_Fundamentals.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
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
            //services.AddScoped<IRestaurantData, MockupRestaurantData>();
            services.AddSingleton<IRestaurantData, MockupRestaurantData>();
            services.AddMvc();
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

            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(configureRoutes);


            app.Run(async (context) =>
            {
                // throw new Exception("Unexpected error occurred! XA");   // HC exeption for testing the "DeveloperExceptionPage()"
 
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);

            });
        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index

            routeBuilder.MapRoute("Default",  
                                  "{controller=Home}/{action=Index}/{id?}");
        }
    }
}