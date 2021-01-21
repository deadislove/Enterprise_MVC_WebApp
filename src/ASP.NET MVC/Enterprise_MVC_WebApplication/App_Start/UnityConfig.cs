using System;
using Enterprise_MVC_WebApplication.Core.Interface;
using Enterprise_MVC_WebApplication.Infra;
using Enterprise_MVC_WebApplication.Infra.Repositories;
using Enterprise_MVC_WebApplication.Logging;
using Unity;

namespace Enterprise_MVC_WebApplication
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IEnterprise_MVC_CoreRepository, Enterprise_MVC_Repository>();
            container.RegisterType(typeof(IGenericTypeRepository<>), typeof(GenericTypeRepository<>));
            container.RegisterType(typeof(ITransactionRepository<>), typeof(TransactionRepository<>));
            container.RegisterType(typeof(ITransactionScopeRepository<>), typeof(TransactionScopeRepository<>));
            container.RegisterType<LogAttribute>();
            container.RegisterType<ExtendedActionAttribute>();
        }
    }
}