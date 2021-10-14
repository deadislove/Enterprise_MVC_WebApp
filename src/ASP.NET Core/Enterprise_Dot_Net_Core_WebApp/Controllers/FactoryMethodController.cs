using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.FactoryMethod;
using Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.FactoryMethod;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    [ServiceFilter(typeof(ILogRepository))]
    public class FactoryMethodController : Controller
    {
        private ConcreteA<Enterprise_MVC_Core> concreteA;
        private ConcreteB<Enterprise_MVC_Core> concreteB;

        public FactoryMethodController(IFactoryMethod<Enterprise_MVC_Core> _repo)
        {
            this.concreteA = new ConcreteA<Enterprise_MVC_Core>(_repo);
            this.concreteB = new ConcreteB<Enterprise_MVC_Core>(_repo);
        }

        public IActionResult Index()
        {
            var objA = concreteA.GetByID_Creator(1).Result;
            var objA_From = concreteA.From_Info();
            var objB = concreteB.GetByID_Creator(2).Result;
            var objB_From = concreteB.From_Info();

            ViewData["P_1"] = objA_From.ToString().Trim();
            ViewData["P_2"] = objB_From.ToString().Trim();

            Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>> tuple_View
                = new Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>>(
                    new List<Enterprise_MVC_Core> { objA },
                    new List<Enterprise_MVC_Core> { objB }
                    );

            return View(tuple_View);
        }
    }
}