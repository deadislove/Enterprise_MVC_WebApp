using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Adapter;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    [ServiceFilter(typeof(ILogRepository))]
    public class AdapterController : Controller
    {
        private readonly IAdapter_Obj<Enterprise_MVC_Core> adapter_Obj;
        private readonly IAdapter_Class<Enterprise_MVC_Core> adapter_Class;

        public AdapterController(
            IAdapter_Obj<Enterprise_MVC_Core> _adapter_Obj,
            IAdapter_Class<Enterprise_MVC_Core> _adapter_Class
            )
        {
            this.adapter_Obj = _adapter_Obj;
            this.adapter_Class = _adapter_Class;
        }

        public IActionResult Index()
        {
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            var objA = this.adapter_Obj.GetRequest();
            sw.Stop();
            ViewData["objA_Time"] = string.Format(
                    sw.Elapsed.TotalSeconds + " Sec    / " +
                    ((float)sw.Elapsed.TotalSeconds / (float)60).ToString("N2") +
                    " min");
            sw.Reset();
            sw.Start();
            var objB = this.adapter_Class.GetRequest(new Adaptee_Class<Enterprise_MVC_Core>());
            sw.Stop();
            ViewData["objB_Time"] = string.Format(
                    sw.Elapsed.TotalSeconds + " Sec    / " +
                    ((float)sw.Elapsed.TotalSeconds / (float)60).ToString("N2") +
                    " min");

            Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>> tuple =
                new Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>>(objA, objB);

            return View(tuple);
        }
    }
}