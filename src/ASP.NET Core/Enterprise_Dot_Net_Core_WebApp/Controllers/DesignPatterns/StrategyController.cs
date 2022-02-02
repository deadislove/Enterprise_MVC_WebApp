using System;
using System.Collections.Generic;
using System.Linq;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Strategy;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    public class StrategyController : Controller
    {
        private readonly IStrategyServices<Enterprise_MVC_Core> _repo;

        public StrategyController(IStrategyServices<Enterprise_MVC_Core> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var result = _repo.Execute();
            Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>> TupleResult;
            if (result.Count > 0)
                return View(Tuple.Create(
                        result[0].AsEnumerable(),
                        result[1].AsEnumerable()
                    ));

            return View(Tuple.Create(
                        new List<Enterprise_MVC_Core>(),
                        new List<Enterprise_MVC_Core>()
                    ));
        }
    }
}