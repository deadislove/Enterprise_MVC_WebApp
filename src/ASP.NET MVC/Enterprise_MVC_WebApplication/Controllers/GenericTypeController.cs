using Enterprise_MVC_WebApplication.Core.Interface;
using Enterprise_MVC_WebApplication.Core;
using System;
using System.Web.Mvc;
using System.Net;
using Enterprise_MVC_WebApplication.Logging;

namespace Enterprise_MVC_WebApplication.Controllers
{
    [ExtendedAction]
    public class GenericTypeController : Controller
    {
        IGenericTypeRepository<Enterprise_MVC_Core> repo;

        public GenericTypeController(IGenericTypeRepository<Enterprise_MVC_Core> _repo)
        {
            this.repo = _repo;
        }

        // GET: GenericType
        public ActionResult Index()
        {
            return View(repo.GetAll().Result);
        }

        // GET: GenericType/Details/{id}
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Core.Enterprise_MVC_Core o = repo.GetById(Convert.ToInt32(id)).Result;

            if (o == null)
                return HttpNotFound();
            else
                return View(o);
        }

        // GET: GenericType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenericType/Create
        /* Proctect form overpositing attacks.
         */
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Enterprise_MVC_Core o)
        {
            if (ModelState.IsValid)
            {
                repo.Create(o);
                return RedirectToAction("Index");
            }
            else
                return View(o);
        }

        // GET: GenericType/Edit/{string:id}
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var o = repo.GetById(Convert.ToInt32(id)).Result;
            if (o == null)
                return HttpNotFound();
            else
                return View(o);
        }

        // POST: GenericType/Edit{string:id}
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Enterprise_MVC_Core o)
        {
            if (ModelState.IsValid)
            {
                repo.Update(o);
                return RedirectToAction("Index");
            }
            else
                return View(o);
        }

        // GET: GenericType/Delete/{string:id}
        public ActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var o = repo.GetById(Convert.ToInt32(id)).Result;
            if (o == null)
                return HttpNotFound();
            else
                return View(o);
        }

        // POST: GenericType/Delete/{string:id}
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var o = repo.GetById(Convert.ToInt32(id)).Result;
            repo.Delete(o);
            return RedirectToAction("Index");
        }
    }
}