using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    public class MediatorController : Controller
    {
        IMediatorExe<Enterprise_MVC_Core> iMediatorExe;
        private ICollection<IEnumerable<Enterprise_MVC_Core>> LayoutResult;

        public MediatorController(IMediatorExe<Enterprise_MVC_Core> _iMediatorExe)
        {
            iMediatorExe = _iMediatorExe;
        }

        public IActionResult Index()
        {
            iMediatorExe.MediatorExe(out LayoutResult);
            
            return View(LayoutResult);
        }
    }
}