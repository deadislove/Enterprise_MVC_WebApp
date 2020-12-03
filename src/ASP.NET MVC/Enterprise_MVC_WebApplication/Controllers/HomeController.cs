using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Enterprise_MVC_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
      public string Index(){
         return "Hello World, this is ASP.Net MVC Tutorials";
      }
    }
}