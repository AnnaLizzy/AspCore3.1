using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.WebApp.Areas.Identity.Data;
using WebApplication.WebApp.Data;

[assembly: HostingStartup(typeof(WebApplication.WebApp.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication.WebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebApplicationWebAppDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebApplicationWebAppDbContextConnection")));

                services.AddDefaultIdentity<WebApplicationWebAppUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                   
                }) 
                    .AddEntityFrameworkStores<WebApplicationWebAppDbContext>();
            });
        }
    }
}