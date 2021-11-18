using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class PrivateDataClassController : Controller
    {
        private PrivateDataClassServices privateDataClassService;

        public PrivateDataClassController(IGenericTypeRepository<Enterprise_MVC_Core> _repo)
        {
            privateDataClassService = new PrivateDataClassServices(_repo);
        }

        public IActionResult Index()
        {
            var obj = privateDataClassService.GetById(1);
            return View(obj);
        }
    }
}