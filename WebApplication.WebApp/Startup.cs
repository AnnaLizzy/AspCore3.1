using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using WebApplication.WebApp.LocalizationResources;
using WebApplication.WebApp.Data;

namespace WebApplication.WebApp
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
            /* global culture */
            var cultures = new[]
            {
                new CultureInfo("vi"),
                new CultureInfo("en"),
    
            };

            services.AddControllersWithViews()
                .AddExpressLocalization<ExpressLocalizationResource,ViewLocalizationResource>(
                ops =>
                {
                    ops.ResourcesPath = "LocalizationResources";
                    ops.RequestLocalizationOptions = o =>
                    {
                        o.SupportedCultures = cultures;
                        o.SupportedUICultures = cultures;
                        o.DefaultRequestCulture = new RequestCulture("vi");
                    };
                });
            /*  end */
            //
            services.AddDbContext<WebApplicationWebAppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("WebtestDb"));
            });

            services.AddRazorPages();
            // DI
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseRequestLocalization();

            app.UseAuthentication();   // Phục hồi thông tin đăng nhập (xác thực)
            app.UseAuthorization();   // Phục hồi thông tinn về quyền của User

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{culture=vi}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
