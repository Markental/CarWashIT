using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWashIT.Data;
using CarWashIT.Models.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarWashIT
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("ConnectionName"));
            });

            services.AddIdentity<UserEntity, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            app.UseStaticFiles();
            app.UseAuthentication();
            

            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                     name: "account",
                     template: "{controller=Account}/{action=Login}/{id?}");
                routes.MapRoute(
                     name: "roles",
                     template: "{controller=Roles}/{action=Index}/{id?}");
                routes.MapRoute(
                     name: "users",
                     template: "{controller=Users}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "clients",
                    template: "{controller=Clients}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "cars",
                    template: "{controller=Cars}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "carnumbers",
                    template: "{controller=CarNumbers}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "orders",
                    template: "{controller=Orders}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "ordercars",
                    template: "{controller=OrderCars}/{action=Index}/{id?}");
            });
        }
    }
}
