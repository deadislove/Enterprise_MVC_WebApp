using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.State;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    public class StateController : Controller
    {
        private IStateServices<Enterprise_MVC_Core> _stateServices;

        public StateController(IStateServices<Enterprise_MVC_Core> stateServices)
        {
            _stateServices = stateServices;
        }

        public IActionResult Index()
        {
            _stateServices.Execute(out Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>> ReturnResult);

            return View(ReturnResult);
        }
    }
}