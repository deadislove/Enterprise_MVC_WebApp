using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    public class PrivateDataClassController : Controller
    {
        private IGenericTypeRepository<Enterprise_MVC_Core> repo;
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