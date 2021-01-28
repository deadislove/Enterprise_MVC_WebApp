using System;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    [ServiceFilter(typeof(ILogRepository))]
    public class TransactionController : Controller
    {
        ITransactionRepository<Enterprise_MVC_Core> repo;
        readonly Enterprise_MVC_Core entityModel;

        public TransactionController(ITransactionRepository<Enterprise_MVC_Core> _repo)
        {
            this.repo = _repo;
            entityModel = new Enterprise_MVC_Core();
        }

        // GET: Transaction/Index
        public IActionResult Index()
        {
            return View(repo.GetAll().Result);
        }

        // GET: Transaction/Details/{int?: id}
        public IActionResult Details(int? id)
        {
            if (id == null || id.Value == 0)
                return NotFound();

            var obj = repo.GetById(id.Value);

            if (id == null)
                return NotFound();
            else
                return View(obj.Result);
        }

        // GET: Transaction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,Age")] Enterprise_MVC_Core enterprise_MVC_Core)
        {
            if (ModelState.IsValid)
            {
                repo.Create(enterprise_MVC_Core);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(enterprise_MVC_Core);
        }

        // GET: Transaction/Edit/{int?:id}
        public ActionResult Edit(int? id)
        {
            if (id == null || id.Value == 0)
                return NotFound();

            var obj = repo.GetById(id.Value);

            if (id == null)
                return NotFound();
            else
                return View(obj.Result);
        }

        // POST: Transaction/Edit/{int?:id}
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,[Bind("ID,Name,Age")] Enterprise_MVC_Core enterprise_MVC_Core)
        {
            if (id.Value != enterprise_MVC_Core.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    repo.Update(enterprise_MVC_Core);
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

        // GET: Transaction/Delete/{id}
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = repo.GetById(id.Value);

            if (obj == null)
                return NotFound();

            return View(obj.Result);
        }

        // POST: Transaction/Delete/{id}
        [HttpOptions, ActionName("Delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var obj = repo.GetById(id);
                if (obj != null && obj.Result != null)
                    repo.Delete(obj.Result);
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
            return repo.GetById(id) != null;
        }
    }
}