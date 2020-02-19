using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityExample.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IdentityExample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(configuration =>
            {
                configuration.UseInMemoryDatabase("Memory_Database");

            });

            services.AddIdentity<IdentityUser, IdentityRole>( config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;    
            }
                )
                .AddEntityFrameworkStores<AppDbContext>() //link between the EF and Identity 
                .AddDefaultTokenProviders();  

            services.ConfigureApplicationCookie(configuration =>
            {
                configuration.Cookie.Name = "Identity.Cookie";
                configuration.LoginPath = "/Home/Login";
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
            app.UseAuthentication();
            //if we remove this then the application wont be able to authorize the user to use the services
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
