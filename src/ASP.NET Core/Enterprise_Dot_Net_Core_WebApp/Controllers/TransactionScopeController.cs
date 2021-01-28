using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    [ServiceFilter(typeof(ILogRepository))]
    public class TransactionScopeController : Controller
    {
        private ITransactionScopeRepository<Enterprise_MVC_Core> repo;
        private readonly Enterprise_MVC_Core entityModel;

        public TransactionScopeController(ITransactionScopeRepository<Enterprise_MVC_Core> _repo)
        {
            this.repo = _repo;
            entityModel = new Enterprise_MVC_Core();
        }

        // GET: TransactionScope/Index
        public IActionResult Index()
        {
            return View(repo.GetAll().Result);
        }

        // GET: TransactionScope/Details/{int?:id}
        /// <summary>
        /// Detail data information
        /// </summary>
        /// <param name="id">Index ID</param>
        /// <returns></returns>
        public IActionResult Details(int? id)
        {
            if (id == null || id.Value == 0)
                return NotFound();

            var obj = repo.GetById(id.Value);
            if (obj == null)
                return NotFound();
            else
                return View(obj.Result);
        }

        // GET: TransactionScope/Create
        /// <summary>
        /// GET: Create view.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransactionScope/Create
        /// <summary>
        /// POST: Create
        /// </summary>
        /// <param name="enterprise_MVC_Core">Entity model class.</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,Age")] Enterprise_MVC_Core enterprise_MVC_Core)
        {
            if (ModelState.IsValid)
            {
                repo.Create(enterprise_MVC_Core);
                return RedirectToAction(nameof(Index));
            }

            return View(enterprise_MVC_Core);
        }

        // GET: TransactionScope/Edit/{id}
        /// <summary>
        /// GET : Edit
        /// </summary>
        /// <param name="id">Index ID</param>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = repo.GetById(id.Value);
            if (obj == null)
                return NotFound();
            else
                return View(obj.Result);
        }

        // POST: TransactionScope/Edit/{id}
        /// <summary>
        /// POST: Edit
        /// </summary>
        /// <param name="id">Index ID</param>
        /// <param name="enterprise_MVC_Core">Entity model class</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Name,Age")] Enterprise_MVC_Core enterprise_MVC_Core)
        {
            if (id != enterprise_MVC_Core.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    repo.Update(enterprise_MVC_Core);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Enterprise_MVC_CoreExists(id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(enterprise_MVC_Core);
        }

        // POST: TransactionScope/Delete/{id}
        /// <summary>
        /// Delete confirmed function.
        /// </summary>
        /// <param name="id">Index ID</param>
        /// <returns></returns>
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