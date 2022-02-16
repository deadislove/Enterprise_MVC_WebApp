using System;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.TemplateMethod;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class TemplateMethodController : Controller
    {
        private ITemplateMethodServices<Enterprise_MVC_Core> _services;
        public TemplateMethodController(ITemplateMethodServices<Enterprise_MVC_Core> services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var Result = _services.Execute();
            return View(Tuple.Create(Result[0], Result[1]));
        }
    }
}