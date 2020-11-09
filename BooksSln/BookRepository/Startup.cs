//Author:  Kyle Dailey
//Initial Creation Date:  09/22/2020

/**************************************************************************************************************************************************************************************

Description:  This project contains code for a rare and esoteric book repository using ASP.NET Core MVC 3. The overall project will contain a database full of several book types,
genres, and ages. The outline for each book will also provide URLs to location where the books still in print can be purchased.

The database will be seeded initially but will also have the ability for users to add to the database.

The project will be built as a web page using MVC and will eventually be deployed to the cloud using Microsoft Azure.

***************************************************************************************************************************************************************************************

Revisions:  Hail Mary for fixing bootstrap.

Revision Date:  11/09/2020

Revised By:  Kyle Dailey

***************************************************************************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BookRepository.Models;

namespace BookRepository
{
    public class Startup
    {
        //This adds code which will Configure the Entity Framework at startup to help connect the database.
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        private IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<RepositoryDBContext>(opts =>
                opts.UseSqlServer(
                    Configuration["ConnectionStrings:BookRepositoryConnection"]));

            services.AddScoped<IRepositoryRepository, EFRepositoryRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddServerSideBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute("catpage",
                    "{category}/Page{bookPage:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page", "Page{bookPage:int}",
                    new { Controller = "Home", action = "Index", bookPage = 1 });

                endpoints.MapControllerRoute("category", "{category}",
                    new { Controller = "Home", action = "Index", bookPage = 1 });

                endpoints.MapControllerRoute("pagination",
                    "Books/Page{bookPage}",
                    new { Controller = "Home", action = "Index", bookPage = 1 });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
