using System.Collections.Generic;
using System.Linq;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Observer;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class ObserverController : Controller
    {
        private IObserverServices _observerServices;

        public ObserverController(IObserverServices observerServices)
        {
            _observerServices = observerServices;
        }

        public IActionResult Index()
        {
            _observerServices.Operation(out List<string> HistoryMsgList);

            return View(HistoryMsgList.AsEnumerable());
        }
    }
}