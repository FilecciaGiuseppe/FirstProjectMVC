using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeuDontOnEstLeHeros.BackOffice.Web.UI.Constraints;
using JeuDontOnEstLeHeros.Core.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JeuDontOnEstLeHeros.BackOffice.Web.UI
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
            services.AddControllersWithViews();

            //ajouté
            string connectionString = this.Configuration.GetConnectionString("DefaultContext");
            //**
            services.AddDbContext<DefaultContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);


            //Ajouté
            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = this.Configuration["apis:facebook:id"];
                options.AppSecret = this.Configuration["apis:facebook:secret"];

            });
            //**

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

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                //ajouté pour avoir accès à Login/Register
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                //******

                endpoints.MapControllerRoute(
                    name: "editparaf",
                    pattern: "edition-paragraphe/{id}",
                    defaults : new { controller = "Paragraphe", action = "Edit" },
                    constraints: new { id = new LogConstraint()  });
                    //constraints : new {id =@"\d+" }); //d c'est pour dire que c'est numérique et + c'est pour dire qu'il y ai au moins une valeur
                    
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
