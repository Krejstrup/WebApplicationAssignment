using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace WebApplicationAssignment
{
    public class Startup    // THE START UP CLASS - WARNING EXCESSIVE USE OF COMMENTING!
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)  // Links up appsettings.json
        {
            // Add logins and databases, SQLConnections etc: services.AddDbContent => options.UseSqlServer etc
            // appsettings.json contains information about data handleling.
            // This is the right place for theese:
            // Service about Identity - services.AddDefaultIdentity...
            // Controllers med Views - services.AddControllersWithViews(); // om vi inte ska använda Models, utan bara Controllers/Views
            // Razor Pages - services.AddRazorPages();

            services.AddMvc();  // starta framework services

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddRazorPages();

        }
        // URI = URL Interaction, not a strict Location, but an Interaction

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // Overall Configure!
        {
            //==== Configure this; they are run in order!!!

            if (env.IsDevelopment())                // Just Dev - To be able to see stack-trace etc!
            {
                app.UseDeveloperExceptionPage();    // Crash exception pages will be generated!
            }

            app.UseHttpsRedirection();  // om inte HTTPS så gå dit istället (vad betyder det? - kolla upp!)
            app.UseDefaultFiles();      // ??
            app.UseStaticFiles();       // To be able to use static files, like HTML, JavaScript or CSS: wwwroot
            app.UseRouting();           // Activate routing
            app.UseSession();           // Activate the Session data passing




            //
            //===== ROUTING - More Routs in this section:
            //
            app.UseEndpoints(endpoints =>
            {

                // Maybe I should put another Route here - I dunno...


                endpoints.MapControllerRoute(   // for MVC endpoint to Guess/Index with new Name of path
                    name: "ToGuessTheNumber",
                    pattern: "Guess_This",
                    defaults: new { controller = "Guess", action = "Index" }
                );


                endpoints.MapControllerRoute(   // for MVC endpoint
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );


                // If nothing is routed the page will send a 404!
            });
        }
    }
}
