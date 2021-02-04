using System;
using JeuDontOnEstLeHeros.BackOffice.Web.UI.Areas.Identity.Data;
using JeuDontOnEstLeHeros.BackOffice.Web.UI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(JeuDontOnEstLeHeros.BackOffice.Web.UI.Areas.Identity.IdentityHostingStartup))]
namespace JeuDontOnEstLeHeros.BackOffice.Web.UI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<JeuDontOnEstLeHerosBackOfficeWebUIContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("JeuDontOnEstLeHerosBackOfficeWebUIContextConnection")));

                services.AddDefaultIdentity<JeuDontOnEstLeHerosBackOfficeWebUIUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<JeuDontOnEstLeHerosBackOfficeWebUIContext>();
            });
        }
    }
}