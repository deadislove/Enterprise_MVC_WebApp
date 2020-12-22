using Enterprise_MVC_WebApplication.Core.Interface;
using Enterprise_MVC_WebApplication.Logging;
using System;
using System.Net;
using System.Web.Mvc;

namespace Enterprise_MVC_WebApplication.Controllers
{
    [Log]
    public class ActionFilterController : Controller
    {

        IEnterprise_MVC_CoreRepository db;

        public ActionFilterController(IEnterprise_MVC_CoreRepository db)
        {
            this.db = db;
        }

        // GET: ActionFilter
        public ActionResult Index()
        {
            return View(db.GetData());
        }

        // GET: ActionFilter/Details/{id}
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Core.Enterprise_MVC_Core o = db.FindById(Convert.ToInt32(id));

            if (o == null)
                return HttpNotFound();
            else
                return View(o);
        }

        // GET: ActionFilter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActionFilter/Create
        /* To protect from overposting attacks.
         */
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Core.Enterprise_MVC_Core o)
        {
            if (ModelState.IsValid)
            {
                db.Add(o);
                return RedirectToAction("Index");
            }

            return View(o);
        }

        // GET: ActionFilter/Edit/{id}
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Core.Enterprise_MVC_Core o = db.FindById(Convert.ToInt32(id));
            if (o == null)
                return HttpNotFound();
            else
                return View(o);
        }

        // POST: ActionFilter/Edit/{id}
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Core.Enterprise_MVC_Core o)
        {
            if (ModelState.IsValid)
            {
                db.Edit(o);
                return RedirectToAction("Index");
            }
            return View(o);
        }

        // Get: ActionFilter/Delete/{id}
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Core.Enterprise_MVC_Core o = db.FindById(Convert.ToInt32(id));
            if (o == null)
                return HttpNotFound();
            else
                return View(o);
        }

        // POST: ActionFilter/Delete/{id}
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Core.Enterprise_MVC_Core o = db.FindById(Convert.ToInt32(id));
            db.Remove(o.ID);
            return RedirectToAction("Index");
        }
    }
}