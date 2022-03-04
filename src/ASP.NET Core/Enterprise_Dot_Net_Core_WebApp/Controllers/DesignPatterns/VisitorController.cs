using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Visitor;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class VisitorController : Controller
    {
        private IVisitorServices<Enterprise_MVC_Core> _services;

        public VisitorController(IVisitorServices<Enterprise_MVC_Core> services) => _services = services;

        public IActionResult Index()
        {
            var Result = _services.Execute();

            if (Result.Count.Equals(0))
                return View(Tuple.Create(new List<Enterprise_MVC_Core>(), new List<Enterprise_MVC_Core>(), new List<Enterprise_MVC_Core>()));

            return View(Tuple.Create(Result[0], Result[1], Result[2]));
        }
    }
}