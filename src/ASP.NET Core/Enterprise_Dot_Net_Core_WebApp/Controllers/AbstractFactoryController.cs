using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.AbstractFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    public class AbstractFactoryController : Controller
    {
        private IAbstractFactory<Enterprise_MVC_Core> factory;

        private readonly Enterprise_MVC_Core entity_model = null;

        public AbstractFactoryController(IAbstractFactory<Enterprise_MVC_Core> _factory)
        {            
            this.entity_model = new Enterprise_MVC_Core();
            this.factory = _factory;
        }

        // GET: AbstractFactory/Index
        public IActionResult Index()
        {
            try
            {
                var objA = factory.CreateA().GetAll().Result;
                var objB = factory.CreateB().GetAll().Result;
                ViewData["CompareResult"] = objA.ToList().SequenceEqual(objB.ToList());
                return View(factory.CreateA().GetAll().Result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: AbstractFactory/Details/{int?:id}
        public IActionResult Details(int? id)
        {
            try
            {
                if (id == null || id.Value == 0)
                    return NotFound();

                var objA = factory.CreateA().GetByID(id.Value).Result;
                var objB = factory.CreateB().GetByID(id.Value).Result;
                ViewData["CompareResult"] = objA.Equals(objB);
                return View(objA);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: AbstractFactory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AbstractFactory/Create
        public IActionResult Create([Bind("ID,Name,Age")] Enterprise_MVC_Core enterprise_MVC_Core)
        {
            if (ModelState.IsValid)
            {
                factory.CreateA().Create(enterprise_MVC_Core);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(enterprise_MVC_Core);
        }

        // GET: AbstractFactory/Edit/{int?:id}
        public ActionResult Edit(int? id)
        {
            if (id == null || id.Value == 0)
                return NotFound();

            var obj = factory.CreateA().GetByID(id.Value);

            if (id == null)
                return NotFound();
            else
                return View(obj.Result);
        }

        // POST: AbstractFactory/Edit/{int?:id}
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind("ID,Name,Age")] Enterprise_MVC_Core enterprise_MVC_Core)
        {
            if (id.Value != enterprise_MVC_Core.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    factory.CreateA().Update(enterprise_MVC_Core);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Enterprise_MVC_CoreExists(id.Value))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(enterprise_MVC_Core);
        }

        // GET: AbstractFactory/Delete/{id}
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = factory.CreateA().GetByID(id.Value);

            if (obj == null)
                return NotFound();

            return View(obj.Result);
        }

        // POST: AbstractFactory/Delete/{id}
        [HttpOptions, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var obj = factory.CreateA().GetByID(id);
                if (obj != null && obj.Result != null)
                    factory.CreateA().Delete(obj.Result);
            }
            catch (Exception e)
            {
                throw e;
            }

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check data Exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool Enterprise_MVC_CoreExists(int id)
        {
            return factory.CreateA().GetByID(id) != null;
        }
    }
}