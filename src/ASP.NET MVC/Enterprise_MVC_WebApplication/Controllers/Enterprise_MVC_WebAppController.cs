using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Enterprise_MVC_WebApplication.Core;
using Enterprise_MVC_WebApplication.Core.Interface;
using Enterprise_MVC_WebApplication.Infra;

namespace Enterprise_MVC_WebApplication.Controllers
{
    public class Enterprise_MVC_WebAppController : Controller
    {
        IEnterprise_MVC_CoreRepository db;

        public Enterprise_MVC_WebAppController(IEnterprise_MVC_CoreRepository db)
        {
            this.db = db;
        }

        // GET: Enterprise_MVC_WebApp
        public ActionResult Index()
        {
            return View(db.GetData());
        }

        // GET: Enterprise_MVC_WebAPp/Details/{id}
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(null))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Core.Enterprise_MVC_Core o = db.FindById(Convert.ToInt32(id));

            if (o == null)
                return HttpNotFound();
            else
                return View(o);
        }

        // GET: Enterprise_MVC_WebApp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enterprise_MVC_WebApp/Create
        /* To protect from overposting attacks.
         */
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(Core.Enterprise_MVC_Core o)
        {
            if (ModelState.IsValid)
            {
                db.Add(o);
                return RedirectToAction("Index");
            }

            return View(o);
        }

        // GET: Enterprise_MVC_WebApp/Edit/{id}
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

        // POST: Enterprise_MVC_WebApp/Edit/{id}
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

        // Get: Enterprise_MVC_WebApp/Delete/{id}
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

        // POST: Enterprise_MVC_WebApp/Delete/{id}
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Core.Enterprise_MVC_Core o = db.FindById(Convert.ToInt32(id));
            db.Remove(o.ID);
            return RedirectToAction("Index");
        }
    }
}