namespace ConventionalRouting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

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

            app.Run();
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

