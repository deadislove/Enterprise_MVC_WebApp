using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.UnitOfWork;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.UnitOfWork
{
    [ServiceFilter(typeof(ILogRepository))]
    public class UnitOfWorkController : Controller
    {
        private IUnitOfWorkClientServices<Enterprise_MVC_Core> _services;

        public UnitOfWorkController(IUnitOfWorkClientServices<Enterprise_MVC_Core> services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var Result = _services.Execute();
            return View(Result);
        }
    }
}