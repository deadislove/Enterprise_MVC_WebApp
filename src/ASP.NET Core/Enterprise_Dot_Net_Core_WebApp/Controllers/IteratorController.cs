using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Iterator;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    [ServiceFilter(typeof(ILogRepository))]
    public class IteratorController : Controller
    {
        private IIteratorServices<Enterprise_MVC_Core> iteratorServices;
        private Tuple<
            IEnumerable<Enterprise_MVC_Core>, 
            IEnumerable<Enterprise_MVC_Core>,
            IEnumerable<Enterprise_MVC_Core>,
            IEnumerable<Enterprise_MVC_Core>
            > tuple;

        public IteratorController(IIteratorServices<Enterprise_MVC_Core> _iteratorServices)
        {
            iteratorServices = _iteratorServices;
        }

        public IActionResult Index()
        {
            var dataDefault = iteratorServices.IteratorDefault();
            var OpeartionData =  iteratorServices.IteratorOperation();
            var AbstractDataDefault = iteratorServices.AbstractIteratorDefault();
            var AbstractOperationData = iteratorServices.AbstractIteratorOperation();


            tuple = Tuple.Create(dataDefault, OpeartionData, AbstractDataDefault, AbstractOperationData);

            return View(tuple);
        }
    }
}