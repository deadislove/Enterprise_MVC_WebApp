using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Singleton;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    public class SingletonController : Controller
    {
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly IOperationScoped _scopedOperation;

        public SingletonController(
                IOperationTransient transientOperation,
                IOperationScoped scopedOperation,
                IOperationSingleton singletonOperation
            )
        {
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
        }

        public class SingletonView
        {
            public string Name { get; set; }
            public string GuidID { get; set; }
        }

        public IActionResult Index()
        {
            IEnumerable<SingletonView> tuple =                 
                new List<SingletonView>() {
                    new SingletonView() {Name="Transiet", GuidID= _transientOperation.OperationId()},
                    new SingletonView() {Name="Scoped", GuidID= _scopedOperation.OperationId()},
                    new SingletonView() {Name="Singleton", GuidID= _singletonOperation.OperationId()},
                };
            return View(tuple);
        }
    }
}