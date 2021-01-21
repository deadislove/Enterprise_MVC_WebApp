using Enterprise_MVC_WebApplication.Core;
using Enterprise_MVC_WebApplication.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enterprise_MVC_WebApplication.Controllers
{
    public class TransactionScopeController : Controller
    {
        private ITransactionScopeRepository<Enterprise_MVC_Core> repo;

        public TransactionScopeController(ITransactionScopeRepository<Enterprise_MVC_Core> _repo)
        {
            this.repo = _repo;
        }

        // GET: TransactionScope
        public ActionResult Index()
        {
            return View(repo.GetAll().Result);
        }
    }
}