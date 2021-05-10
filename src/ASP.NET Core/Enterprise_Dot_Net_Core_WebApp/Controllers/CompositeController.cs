using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Composite;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Composite;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    public class CompositeController : Controller
    {
        public CompositeElement<Enterprise_MVC_Core> compositeElement;
        private readonly Composite Composite;

        public CompositeController(IComposite<Enterprise_MVC_Core> _repo)
        {
            this.compositeElement = new CompositeElement<Enterprise_MVC_Core>(_repo);
            Composite = new Composite();
        }

        public IActionResult Index()
        {
            int[] arrObjOrder = new int[] { 1, 3, 2 };
            Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>> tuple;

            List<Enterprise_MVC_Core> list = new List<Enterprise_MVC_Core>();
            List<Enterprise_MVC_Core> list2 = new List<Enterprise_MVC_Core>();

            foreach (int item in arrObjOrder)
            {
                var obj1 = this.compositeElement.Operation(item);
                Composite.Add(obj1 as object);
            }

            foreach (var item in Composite.Operation(0) as List<object>)
            {
                list.Add(item as Enterprise_MVC_Core);
            }

            arrObjOrder = new int[] { 1,2,3 };

            foreach (int item in arrObjOrder)
            {
                var obj2 = this.compositeElement.Operation(item);
                Composite.Add(obj2 as object);
            }

            foreach (var item in Composite.Operation(0) as List<object>)
            {
                list2.Add(item as Enterprise_MVC_Core);
            }            

            tuple = new Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>>(
                list,
                list2
                );

            return View(tuple);
        }
    }
}