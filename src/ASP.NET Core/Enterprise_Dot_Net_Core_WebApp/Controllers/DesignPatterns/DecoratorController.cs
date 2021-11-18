using System;
using System.Threading;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class DecoratorController : Controller
    {        
        private DecoratorServices _decoratorServices;

        public DecoratorController(IGenericTypeRepository<Enterprise_MVC_Core> GenericTypeRepository)
        {
            _decoratorServices = new DecoratorServices(GenericTypeRepository);
        }

        public IActionResult Index()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            source.CancelAfter(TimeSpan.FromSeconds(1));

            var msg = _decoratorServices.Notification(true, 1,source.Token);

            ViewData["db_Result"] = msg.Result;

            return View();
        }
    }
}