using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Flyweight;
using Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Flyweight;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class FlyweightController : Controller, IDisposable
    {
        FlyweightServices flyweightServices;
        readonly IFlyweight<Enterprise_MVC_Core> iFlyweight;

        public FlyweightController(IFlyweight<Enterprise_MVC_Core> _iFlyweight)
        {
            this.iFlyweight = _iFlyweight;
            flyweightServices = new FlyweightServices(iFlyweight);
        }

        public IActionResult Index()
        {
            try
            {
                flyweightServices.GetKey(out List<string> obj);
                flyweightServices.GetFactory(out FlyweightFactory flyweightFactory);
                flyweightServices.AddElement(flyweightFactory, new Enterprise_MVC_Core
                {
                    ID = 3,
                    Name = "Sam",
                    Age = 18
                }, out string Result);

                flyweightServices.Result(Result, out List<FlyweightsDto> result);

                flyweightServices.AddElement(flyweightFactory, new Enterprise_MVC_Core
                {
                    ID = 5,
                    Name = "Dennys",
                    Age = 10
                }, out Result);

                flyweightServices.Result(Result, out List<FlyweightsDto> FinalResult, ref result);

                return View(FinalResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }

        private new void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}