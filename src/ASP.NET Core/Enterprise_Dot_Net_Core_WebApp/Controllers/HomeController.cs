using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise_Dot_Net_Core_WebApp.Models;
using System.Reflection;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Index - UI will includes all of controller URL.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<RouteClass> _list = GellControllerAction();

            return View(_list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /// <summary>
        /// Detect all of controller routes.
        /// </summary>
        /// <returns>List<RouteClass></returns>
        private static List<RouteClass> GellControllerAction()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            //var obj = asm.GetTypes()
            //    .Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
            //    .SelectMany(type => type.GetMethods())
            //    .Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute)));

            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(
                        m => m.Name == "Index" && 
                             m.DeclaringType.Name != "HomeController" &&
                            !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => 
                        new RouteClass {
                            Controller = x.DeclaringType.Name.Replace("Controller",""),
                            Action = x.Name,
                            ReturnType = x.ReturnType.Name,
                            Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                    .OrderBy(x => x.Controller)
                    .ThenBy(x => x.Action)
                    .ToList();

            return controlleractionlist;
        }

        public class RouteClass
        {
            public string Controller { get; set; } = string.Empty;
            public string Action { get; set; } = string.Empty;
            public string ReturnType { get; set; } = string.Empty;
            public string Attributes { get; set; } = string.Empty;
        }
    }
}
