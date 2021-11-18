using System.Collections.Generic;
using System.Linq;
using Enterprise_Dot_Net_Core_WebApp.Core.DTOs;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Command;
using Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Command;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class CommandController : Controller
    {
        private readonly RequestObj requestObj = new RequestObj
        {
            ID = 1
        };

        private ICommand<RequestObj, Enterprise_MVC_Core> _ICommand;

        public CommandController(ICommand<RequestObj, Enterprise_MVC_Core> iCommand)
        {
            _ICommand = iCommand;            
        }

        public IActionResult Index()
        {
            IEnumerable<Enterprise_MVC_Core> ResultObj;                       

            _ICommand.SetOnStart(new CommandExeServices(requestObj));
            _ICommand.SetOnFinish(new CommandAnotherExeServices(requestObj));
            var CommandResult = _ICommand.ExecuteResult<Enterprise_MVC_Core>(requestObj).Result;

            ResultObj = CommandResult.AsEnumerable();

            return View(ResultObj);
        }
    }
}