using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.ChainOfResponsibility;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    [ServiceFilter(typeof(ILogRepository))]
    public class CofRController : Controller
    {
        private ICofR _iCofR;

        public CofRController(ICofR iCofR)
        {
            _iCofR = iCofR;
        }

        public IActionResult Index()
        {
            _iCofR.CofR("ASC", out List<Enterprise_MVC_Core> DataASCObj);
            _iCofR.CofR("DESC", out List<Enterprise_MVC_Core> DataDESCObj);

            List<int> RangeList = new List<int>() { 1, 3, 2 };
            _iCofR.CofRByID(RangeList, out List<Enterprise_MVC_Core> DataRangeObj);

            Tuple<
                IEnumerable<Enterprise_MVC_Core>,
                IEnumerable<Enterprise_MVC_Core>,
                IEnumerable<Enterprise_MVC_Core>> tuple = new Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>>(DataASCObj, DataDESCObj, DataRangeObj);

            if (tuple.Equals(default(Tuple<IEnumerable<Enterprise_MVC_Core>,
                IEnumerable<Enterprise_MVC_Core>,
                IEnumerable<Enterprise_MVC_Core>>)))
            {
                dynamic defaultObj = new List<Enterprise_MVC_Core>();
                tuple = new Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>>(defaultObj, defaultObj, defaultObj);
                return View(tuple);
            }
            else
            {                
                return View(tuple);
            }
        }
    }
}