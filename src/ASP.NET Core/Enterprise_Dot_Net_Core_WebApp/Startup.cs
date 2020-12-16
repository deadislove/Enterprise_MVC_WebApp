using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enterprise_Dot_Net_Core_WebApp.Infra.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Enterprise_Dot_Net_Core_WebApp.Logging.Repository;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Enterprise_Dot_Net_Core_WebApp
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

            services.AddDbContext<DemoDbContext>(
                option => option.UseSqlServer(Configuration.GetConnectionString("DB_EntityString")));

            services.AddScoped(typeof(IEnterprise_MVC_CoreRepository), typeof(Enterprise_MVC_Repository));
            //AOP Scoped
            services.AddScoped(typeof(ILogRepository), typeof(LogRepository));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //Add log file path
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
