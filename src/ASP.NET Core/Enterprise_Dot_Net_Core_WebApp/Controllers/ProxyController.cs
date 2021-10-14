using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Proxy;
using Enterprise_Dot_Net_Core_WebApp.Core.DTOs;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    [ServiceFilter(typeof(ILogRepository))]
    public class ProxyController : Controller
    {
        private ProxyServices<Enterprise_MVC_Core> proxyServices;
        private Requests request;
        readonly IGenericTypeRepository<Enterprise_MVC_Core> repo;

        public ProxyController(IGenericTypeRepository<Enterprise_MVC_Core> _repo)
        {
            repo = _repo;
        }

        public IActionResult Index()
        {
            request = new Requests
            {
                Id= 2,
                Username = "local",
                Password = "123"
            };

            proxyServices = new ProxyServices<Enterprise_MVC_Core>(request, repo);

            proxyServices.Response(out List<Enterprise_MVC_Core> obj);
            proxyServices.LoggingProcess(out List<Messages> logList);

            Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Messages>> tuple = new Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Messages>>(obj, logList); 

            return View(tuple);
        }
    }
}