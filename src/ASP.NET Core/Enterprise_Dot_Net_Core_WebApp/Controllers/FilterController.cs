using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enterprise_Dot_Net_Core_WebApp.Core.DTOs;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers
{
    public class FilterController : Controller
    {
        FilterServices<Enterprise_MVC_Core> _filterServices;

        public FilterController(IGenericTypeRepository<Enterprise_MVC_Core> _repo)
        {
            _filterServices = new FilterServices<Enterprise_MVC_Core>(_repo);
        }
        
        public IActionResult Index()
        {
            _filterServices.Initialization(out List<Enterprise_MVC_Core> InitObj);

            _filterServices.RecordMessages("Filter for Name: Andy");

            var FilterObj = _filterServices.ObjectFilterForName(InitObj, "Andy");

            var LoadRecordMsg = _filterServices.LoadMessages();

            Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Messages>> tuple =
                new Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<Messages>>(FilterObj, LoadRecordMsg);

            return View(tuple);
        }
    }
}