using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rejestr_osób_zaginionych.Areas.Identity.Data;
using Rejestr_osób_zaginionych.Data;

[assembly: HostingStartup(typeof(Rejestr_osób_zaginionych.Areas.Identity.IdentityHostingStartup))]
namespace Rejestr_osób_zaginionych.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Rejestr_osób_zaginionychDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Rejestr_osób_zaginionychDbContextConnection")));

                services.AddDefaultIdentity<User>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                    .AddEntityFrameworkStores<Rejestr_osób_zaginionychDbContext>();
            });
        }
    }
}