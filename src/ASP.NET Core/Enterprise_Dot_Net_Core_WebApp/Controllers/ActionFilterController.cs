using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    [ServiceFilter(typeof(ILogRepository))]
    public class ActionFilterController : Controller
    {
        private readonly IEnterprise_MVC_CoreRepository repo;

        public ActionFilterController(IEnterprise_MVC_CoreRepository _repo)
        {
            this.repo = _repo;
        }

        // GET: ActionFilter/Index
        public IActionResult Index()
        {
            return View(repo.GetData());
        }

        // GET: ActionFilter/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprise_MVC_Core = repo.FindById(id.Value);
            if (enterprise_MVC_Core == null)
            {
                return NotFound();
            }

            return View(enterprise_MVC_Core);
        }

        // GET: ActionFilter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActionFilter/Create
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,Age")] Enterprise_MVC_Core enterprise_MVC_Core)
        {
            if (ModelState.IsValid)
            {
                repo.Add(enterprise_MVC_Core);

                return RedirectToAction(nameof(Index));
            }
            return View(enterprise_MVC_Core);
        }

        // GET: ActionFilter/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprise_MVC_Core = repo.FindById(id.Value);
            if (enterprise_MVC_Core == null)
            {
                return NotFound();
            }
            return View(enterprise_MVC_Core);
        }

        // POST: ActionFilter/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Name,Age")] Enterprise_MVC_Core enterprise_MVC_Core)
        {
            if (id != enterprise_MVC_Core.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repo.Edit(enterprise_MVC_Core);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Enterprise_MVC_CoreExists(enterprise_MVC_Core.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(enterprise_MVC_Core);
        }

        // GET: ActionFilter/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprise_MVC_Core = repo.FindById(id.Value);

            if (enterprise_MVC_Core == null)
            {
                return NotFound();
            }

            return View(enterprise_MVC_Core);
        }

        // POST: ActionFilter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            repo.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool Enterprise_MVC_CoreExists(int id)
        {
            return repo.FindById(id) != null;
        }
    }
}