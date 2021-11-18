using System;
using System.Collections.Generic;
using System.Text;
using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Facade;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Facade;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class FacadeController : Controller
    {
        readonly FacadeServices facadeServices;
        readonly IFacade<Enterprise_MVC_Core> Ifacade;

        public FacadeController(IFacade<Enterprise_MVC_Core> _Ifacade)
        {
            this.Ifacade = _Ifacade;
            FacadeSubsystem1<Enterprise_MVC_Core> facadeSubsystem1 = new FacadeSubsystem1<Enterprise_MVC_Core>(Ifacade);
            FacadeSubsystem2<Enterprise_MVC_Core> facadeSubsystem2 = new FacadeSubsystem2<Enterprise_MVC_Core>(Ifacade);
            this.facadeServices = new FacadeServices(facadeSubsystem1, facadeSubsystem2);
        }

        public IActionResult Index()
        {
            try
            {
                List<object> list = facadeServices.Layout();
                List<Enterprise_MVC_Core> tableList = new List<Enterprise_MVC_Core>();
                StringBuilder stringBuilder = new StringBuilder();

                foreach (var item in list)
                {
                    if (item.GetType() == typeof(string))
                    {
                        stringBuilder.AppendLine(string.Format("{0}", item as string));
                    }
                    else
                    {
                        tableList.Add(item as Enterprise_MVC_Core);
                    }
                }

                if (stringBuilder.Length > 0)
                    ViewData["Process"] = stringBuilder.ToString();

                Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>> tuple =
                    new Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Enterprise_MVC_Core>>(
                        new List<Enterprise_MVC_Core> {tableList[0] },
                        new List<Enterprise_MVC_Core> { tableList[1] });

                return View(tuple);
            }
            catch (Exception ec)
            {
                return View();
            }
            finally
            {
                Dispose();
            }
        }

        private new void Dispose() => GC.SuppressFinalize(this);
    }
}