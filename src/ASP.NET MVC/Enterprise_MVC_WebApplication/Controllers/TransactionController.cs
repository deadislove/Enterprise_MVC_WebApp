using Enterprise_MVC_WebApplication.Core.Interface;
using Enterprise_MVC_WebApplication.Core;
using System;
using System.Web.Mvc;
using System.Net;

namespace Enterprise_MVC_WebApplication.Controllers
{
    public class TransactionController : Controller
    {
        private ITransactionRepository<Enterprise_MVC_Core> repo;

        public TransactionController(ITransactionRepository<Enterprise_MVC_Core> _repo)
        {
            this.repo = _repo;
        }

        // GET: Transaction/Index
        public ActionResult Index()
        {
            return View(repo.GetAll().Result);
        }

        // GET: Transaction/Details/{string:id}
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var obj = repo.GetById(Convert.ToInt32(id)).Result;

            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
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

        // GET: Transaction/Edit/{string:id}
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

        // POST: Transaction/Edit{string:id}
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

        // GET: Transaction/Delete/{string:id}
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

        // POST: Transaction/Delete/{string:id}
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var o = repo.GetById(Convert.ToInt32(id)).Result;
            repo.Delete(o);
            return RedirectToAction("Index");
        }
    }
}