﻿using Enterprise_Dot_Net_Core_WebApp.Infra.DBContext;
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
// Design patterns
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.AbstractFactory;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Builder;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.FactoryMethod;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Prototype;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Singleton;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Adapter;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Bridge;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Composite;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Facade;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Flyweight;
//Object Pooling patterns
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Text;
using Enterprise_Dot_Net_Core_WebApp.Middleware;
// Design patterns
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Singleton;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Adapter;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.AbstractFactory;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Bridge;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Builder;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.FactoryMethod;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Prototype;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Composite;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Facade;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Flyweight;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Command;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.ChainOfResponsibility;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Interpreter;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Iterator;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Memento;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Mediator;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.NullObject;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Observer;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.State;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Strategy;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.TemplateMethod;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Visitor;
//Design patterns - services
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.ChainOfResponsibility;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Command;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Interpreter;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Iterator;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Mediator;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Memento;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.NullObject;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Observer;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.State;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Strategy;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.TemplateMethod;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Visitor;
//Unit of Work
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.UnitOfWork;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.UnitOfWork;

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
            // Object Pool
            services.TryAddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
            services.TryAddSingleton<ObjectPool<StringBuilder>>(serviceProvider =>
            {
                var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();
                var policy = new StringBuilderPooledObjectPolicy();
                return provider.Create(policy);
            });
            // Prototype
            services.AddScoped(typeof(IPrototype<>), typeof(PrototypeRepo<>));
            // Singleton            
            services.AddSingleton<IOperationSingleton, Operation>();
            // Adapter
            services.AddScoped(typeof(IAdapter_Obj<>), typeof(AdapterRepo_Obj<>));
            services.AddScoped(typeof(IAdapter_Class<>), typeof(AdapterRepo_Class<>));
            // Bridge
            services.AddScoped(typeof(IBridge), typeof(BridgeRepoA));
            services.AddScoped(typeof(IBridge), typeof(BridgeRepoB));
            // Composite
            services.AddScoped(typeof(IComposite<>), typeof(CompositeRepo<>));
            // Decorator
            services.AddScoped(typeof(DecoratorServices));
            // Facade
            services.AddScoped(typeof(IFacade<>), typeof(FacadeRepo<>));
            services.AddScoped(typeof(FacadeServices));
            // Flyweight
            services.AddScoped(typeof(IFlyweight<>), typeof(FlyweightRepo<>));
            services.AddScoped(typeof(FlyweightServices));
            // Private Data Class
            services.AddScoped(typeof(PrivateDataClassServices));
            // Proxy service 
            //
            // CofR service
            services.AddScoped(typeof(ICofR), typeof(HandlerService));
            // Command
            services.AddScoped(typeof(ICommand<,>), typeof(CommandServices<,>));
            services.AddScoped(typeof(ICommandExe), typeof(CommandExeServices));
            // Interpreter
            services.AddScoped(typeof(IInterpreter<,>), typeof(InterpreterServices<,>));
            // Iterator
            services.AddScoped(typeof(IIteratorServices<>), typeof(IteratorServices<>));
            // Mediator
            services.AddScoped(typeof(IMediatorExe<>), typeof(MediatorServices<>));
            // Memento
            services.AddScoped(typeof(IMementoServices<>), typeof(MementoServices<>));
            // Null object pattern
            services.AddScoped(typeof(INullObject), typeof(NullObjServices));
            // Observer
            services.AddScoped(typeof(IObserverServices), typeof(ObserverServices));
            // State
            services.AddScoped(typeof(IStateServices<>), typeof(StateServices<>));
            // Strategy
            services.AddScoped(typeof(IStrategyServices<>), typeof(StrategyServices<>));
            // Template Method
            services.AddScoped(typeof(ITemplateMethodServices<>), typeof(TemplateMethodServices<>));
            // Visitor
            services.AddScoped(typeof(IVisitorServices<>), typeof(VisitorServices<>));

            // Unit of Work
            services.AddScoped(typeof(IUnitOfWorkClientServices<>), typeof(UnitOfWorkClientServices<>));

            // Service type method.
            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();

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

            // Middleware - Object Pooling
            //Test using /?Id=123&day=28&month=9
            app.UseMiddleware<ObjectPoolingMiddleware>();

            /* Static files, such as HTML, CSS, images, and JavaScript, are assets an ASP.NET Core app serves directly to clients by default.
             * Reference link: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-2.2
             */
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
