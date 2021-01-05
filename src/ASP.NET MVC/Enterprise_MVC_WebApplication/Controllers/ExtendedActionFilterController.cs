using Enterprise_MVC_WebApplication.Core.Interface;
using Enterprise_MVC_WebApplication.Logging;
using System;
using System.Net;
using System.Web.Mvc;

namespace Enterprise_MVC_WebApplication.Controllers
{
    [ExtendedAction]
    public class ExtendedActionFilterController : Controller
    {
        IEnterprise_MVC_CoreRepository repo;

        public ExtendedActionFilterController(IEnterprise_MVC_CoreRepository _repo)
        {
            this.repo = _repo;
        }

        // GET: ExtendedActionFilter
        public ActionResult Index()
        {
            return View(repo.GetData());
        }

        // GET: ExtendedActionFilter/Details/{id}
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Core.Enterprise_MVC_Core o = repo.FindById(Convert.ToInt32(id));

            if (o == null)
                return HttpNotFound();
            else
                return View(o);
        }

        // GET: ExtendedActionFilter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExtendedActionFilter/Create
        /* To protect from overposting attacks.
         */
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Core.Enterprise_MVC_Core o)
        {
            if (ModelState.IsValid)
            {
                repo.Add(o);
                return RedirectToAction("Index");
            }

            return View(o);
        }

        // GET: ExtendedActionFilter/Edit/{id}
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Core.Enterprise_MVC_Core o = repo.FindById(Convert.ToInt32(id));
            if (o == null)
                return HttpNotFound();
            else
                return View(o);
        }

        // POST: ExtendedActionFilter/Edit/{id}
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Core.Enterprise_MVC_Core o)
        {
            if (ModelState.IsValid)
            {
                repo.Edit(o);
                return RedirectToAction("Index");
            }
            return View(o);
        }

        // Get: ExtendedActionFilter/Delete/{id}
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Core.Enterprise_MVC_Core o = repo.FindById(Convert.ToInt32(id));
            if (o == null)
                return HttpNotFound();
            else
                return View(o);
        }

        // POST: ExtendedActionFilter/Delete/{id}
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Core.Enterprise_MVC_Core o = repo.FindById(Convert.ToInt32(id));
            repo.Remove(o.ID);
            return RedirectToAction("Index");
        }
    }
}
