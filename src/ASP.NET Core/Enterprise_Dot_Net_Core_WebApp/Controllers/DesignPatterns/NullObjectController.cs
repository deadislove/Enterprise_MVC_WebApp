using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.NullObject;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class NullObjectController : Controller
    {
        INullObject _Inullobject;

        public NullObjectController(INullObject Inullobject) => _Inullobject = Inullobject;

        public IActionResult Index()
        {
            Tuple<IEnumerable<string>> Return = _Inullobject.Operation();

            return View(Return.Item1);
        }
    }
}