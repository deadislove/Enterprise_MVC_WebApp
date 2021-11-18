using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Bridge;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Bridge;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class BridgeController : Controller
    {
        private readonly IGenericTypeRepository<Enterprise_MVC_Core> GenericRepo;
        BridgeAbstraction bridgeAbstraction;

        public BridgeController(
            IGenericTypeRepository<Enterprise_MVC_Core> _GenericRepo
            )
        {            
            this.GenericRepo = _GenericRepo;
            bridgeAbstraction = new ExtendBridgeAbstraction(new BridgeRepoB(this.GenericRepo));
        }

        public IActionResult Index()
        {
            Tuple<IEnumerable<Enterprise_MVC_Core_Variant>, IEnumerable<Enterprise_MVC_Core_Variant>> tuple;
            var obj = this.bridgeAbstraction.GetAll().Result;
            this.bridgeAbstraction = new ExtendBridgeAbstraction(new BridgeRepoA(this.GenericRepo));
            var obj2 = this.bridgeAbstraction.GetAll().Result;
            IEnumerable<Enterprise_MVC_Core_Variant> test = new List<Enterprise_MVC_Core_Variant>();
            
            if (obj.GetType().Equals(obj2.GetType()))
            {
                tuple = new Tuple<IEnumerable<Enterprise_MVC_Core_Variant>, IEnumerable<Enterprise_MVC_Core_Variant>>(
                    obj as IEnumerable<Enterprise_MVC_Core_Variant>,
                    obj2 as IEnumerable<Enterprise_MVC_Core_Variant>
                    );
            }
            else
                tuple = new Tuple<IEnumerable<Enterprise_MVC_Core_Variant>, IEnumerable<Enterprise_MVC_Core_Variant>>(
                    new List<Enterprise_MVC_Core_Variant>(),
                    new List<Enterprise_MVC_Core_Variant>()
                    );


            return View(tuple);
        }
    }
}