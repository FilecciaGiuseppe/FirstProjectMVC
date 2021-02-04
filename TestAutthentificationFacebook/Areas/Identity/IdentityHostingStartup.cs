using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAutthentificationFacebook.Areas.Identity.Data;
using TestAutthentificationFacebook.Data;

[assembly: HostingStartup(typeof(TestAutthentificationFacebook.Areas.Identity.IdentityHostingStartup))]
namespace TestAutthentificationFacebook.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TestAutthentificationFacebookContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TestAutthentificationFacebookContextConnection")));

                services.AddDefaultIdentity<TestAutthentificationFacebookUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TestAutthentificationFacebookContext>();
            });
        }
    }
}