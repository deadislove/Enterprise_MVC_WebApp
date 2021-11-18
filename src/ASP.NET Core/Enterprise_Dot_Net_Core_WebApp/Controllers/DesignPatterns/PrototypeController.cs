using System;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Prototype;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class PrototypeController : Controller
    {
        private IPrototype<Enterprise_MVC_Core> repo;

        public PrototypeController(IPrototype<Enterprise_MVC_Core> _repo)
        {
            this.repo = _repo;
        }

        public IActionResult Index()
        {
            var PrototypeObj = repo.Prototype_GetById(1);
            PrototypeEntity prototypeEntity = new PrototypeEntity()
            {
                ID = PrototypeObj.ID,
                Name = PrototypeObj.Name,
                Age = PrototypeObj.Age,
                IdInfo = new IdInfo(Guid.NewGuid())
            };

            PrototypeEntity prototypeEntity2 = prototypeEntity.ShallowCopy();
            PrototypeEntity prototypeEntity3 = prototypeEntity.DeepCopy();

            Tuple<PrototypeEntity, PrototypeEntity, PrototypeEntity> Result_tuple;                
            Result_tuple = Tuple.Create(prototypeEntity, prototypeEntity2, prototypeEntity3);

            // Before
            // prototypeEntity object
            ViewData["Item1_ID"] = prototypeEntity.ID;
            ViewData["Item1_Name"] = prototypeEntity.Name;
            ViewData["Item1_Age"] = prototypeEntity.Age;
            ViewData["Item1_Guid"] = prototypeEntity.IdInfo.IdNumber;
            // prototypeEntity2 object
            ViewData["Item2_ID"] = prototypeEntity2.ID;
            ViewData["Item2_Name"] = prototypeEntity2.Name;
            ViewData["Item2_Age"] = prototypeEntity2.Age;
            ViewData["Item2_Guid"] = prototypeEntity2.IdInfo.IdNumber;
            // prototypeEntity3 object
            ViewData["Item3_ID"] = prototypeEntity3.ID;
            ViewData["Item3_Name"] = prototypeEntity3.Name;
            ViewData["Item3_Age"] = prototypeEntity3.Age;
            ViewData["Item3_Guid"] = prototypeEntity3.IdInfo.IdNumber;
            // After
            prototypeEntity.Name = "After_Changed_Nmae";
            prototypeEntity.IdInfo.IdNumber = Guid.NewGuid();

            return View(Result_tuple);
        }
    }
}