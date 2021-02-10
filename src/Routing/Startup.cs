using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Routing
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                // this is conventional routing
                //  It's called conventional routing because it establishes a convention for URL paths
                endpoints.MapControllerRoute(
                    name: "myRoute",
                    pattern: "Game/{*index}",
                    defaults: new { controller = "MyRoute", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{firstName?}/{lastName?}"); ///Home/index

                // defining an inline middleware
                endpoints.MapGet("/health", async context =>
                {
                    await context.Response.WriteAsync("I am healthy!");
                });
            });

            app.Map("/map1", HandleMapTest1);

            app.Map("/map2", HandleMapTest1Again);
        }

        private static void HandleMapTest1(IApplicationBuilder app)
        {
            // this defines a terminal middleware
            // it prevents further middleware from processing the request
            // It's called terminal middleware because it terminates the searc
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }

        private static void HandleMapTest1Again(IApplicationBuilder app)
        {
            // adds an inline middleware
            app.Use(async (context, next) =>
            {
                // Do work that doesn't write to the Response.
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello Test 1 again");
            });
        }
    }
}
