using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Memento;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class MementoController : Controller
    {
        private IMementoServices<Enterprise_MVC_Core> _mementoServices;

        public MementoController(IMementoServices<Enterprise_MVC_Core> mementoServices)
        {
            _mementoServices = mementoServices;
        }

        public IActionResult Index()
        {
            _mementoServices.Operation(out Tuple<IEnumerable<string>, IEnumerable<string>> returnObj);
            return View(returnObj);
        }
    }
}