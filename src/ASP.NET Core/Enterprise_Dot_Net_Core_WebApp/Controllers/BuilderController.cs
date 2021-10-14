using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Builder;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Builder;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    [ServiceFilter(typeof(ILogRepository))]
    public class BuilderController : Controller
    {
        private readonly Director<Enterprise_MVC_Core> director;

        public BuilderController(IBuilder<Enterprise_MVC_Core> repo)
        {
            this.director = new Director<Enterprise_MVC_Core>(repo);
        }

        public IActionResult Index()
        {
            Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>> repo;
            
            var Result = director.Combine();
            var AntiResult = director.AntiCombine();
            
            repo = new Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>>(Result, AntiResult);

            return View(repo);
        }
    }
}