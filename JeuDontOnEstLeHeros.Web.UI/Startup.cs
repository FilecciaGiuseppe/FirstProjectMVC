using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeuDontOnEstLeHeros.Core.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using JeuDontOnEstLeHeros.Core.Data.DataLayers;

namespace JeuDontOnEstLeHeros.Web.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //le service c'est pour l'injection de dépendances
        {
            services.AddControllersWithViews();

            //ajouté
            string connectionString = this.Configuration.GetConnectionString("DefaultContext");

            services.AddTransient<ParagrapheDataLayer, ParagrapheDataLayer>();

            services.AddDbContext<DefaultContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "aventure-creation",
                    pattern: "demarrer-une-nouvelle-aventure",
                    defaults: new { controller = "Aventure", action = "Create" });

                endpoints.MapControllerRoute(
                    name: "aventure-edition",
                    pattern: "editer-une-aventure/{id}",
                    defaults: new { controller = "Aventure", action = "Edit" },
                    constraints: new {id = @"\d+" });

                endpoints.MapControllerRoute(
                    name: "mesaventures",
                    pattern: "mes-aventures",
                    defaults: new
                    {
                        controller = "Aventure",
                        action = "Index"
                    });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
