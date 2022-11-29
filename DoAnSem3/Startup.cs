using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnSem3.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DoAnSem3
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

            //using Microsoft.Extensions.DependencyInjection.Extensions;
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnections")
                )
            );
            //Cấu hình sử dụng sesion
            services.AddDistributedMemoryCache();
            services.AddSession(osp =>
            {
                osp.IdleTimeout = TimeSpan.FromHours(1);
                osp.Cookie.Name = ".Bkap.Sesion";
                osp.Cookie.HttpOnly = true;
            });


            //cấu hình kết nối
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnections")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "admin",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
