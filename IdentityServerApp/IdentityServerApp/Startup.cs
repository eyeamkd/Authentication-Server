using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IdentityServerApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("CookieAuth")
                    .AddCookie("CookieAuth", configuration =>
                    {
                        configuration.Cookie.Name = "Kunals.Cookie";
                        configuration.LoginPath = "/Home/Authenticate";
                    });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //route resolution happens here 
            //endpoint objects gets created below  
            //app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            //here we use the endpoints objects created above and map them with configurable custom properties  
            app.UseEndpoints(endpoints =>
            {
                /* endpoints.MapGet("/", async context =>
                 {
                     await context.Response.WriteAsync("Hello World!");
                 }); */
                //this middleware should resolve the endpoint object
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
