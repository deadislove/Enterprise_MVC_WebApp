using Enterprise_Dot_Net_Core_WebApp.Infra.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Enterprise_Dot_Net_Core_WebApp.Logging.Repository;
using System.IO;
using Microsoft.Extensions.Logging;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.AbstractFactory;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.AbstractFactory;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Builder;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.FactoryMethod;

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
                option => option.UseSqlServer(Configuration.GetConnectionString("DB_EntityString")),ServiceLifetime.Transient);

            // Basic CRUD Scoped
            services.AddScoped(typeof(IEnterprise_MVC_CoreRepository), typeof(Enterprise_MVC_Repository));
            //AOP Scoped
            services.AddScoped(typeof(ILogRepository), typeof(LogRepository));
            // Generic type CRUD Scoped
            services.AddScoped(typeof(IGenericTypeRepository<>), typeof(GenericTypeRepository<>));
            // Transaction
            services.AddScoped(typeof(ITransactionRepository<>), typeof(TransactionRepository<>));
            // Transaction Scope
            services.AddScoped(typeof(ITransactionScopeRepository<>), typeof(TransactionScopeRepository<>));

            /* Design pattern
             */
            // Abstract Factory
            services.AddScoped(typeof(IAbstractFactory<>), typeof(AbstractFactoryRepo<>));
            services.AddScoped(typeof(IAbstractFactoryA<>), typeof(AbstractFactoryA_Repository<>));
            services.AddScoped(typeof(IAbstractFactoryB<>), typeof(AbstractFactoryB_Repository<>));
            // Builder
            services.AddScoped(typeof(IBuilder<>), typeof(BuilderRepo<>));
            // Factory Method
            services.AddScoped(typeof(IFactoryMethod<>), typeof(FactoryMethodRepoA<>));

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
