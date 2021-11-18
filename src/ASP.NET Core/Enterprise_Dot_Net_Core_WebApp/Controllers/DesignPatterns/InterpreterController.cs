using System;
using System.Collections.Generic;
using Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns.Interpreter;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Interpreter;
using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise_Dot_Net_Core_WebApp.Controllers.DesignPatterns
{
    [ServiceFilter(typeof(ILogRepository))]
    public class InterpreterController : Controller
    {

        private IInterpreter<Enterprise_MVC_Core, IEnumerable<InterpreterDto>> _IInterpreter;

        public InterpreterController(IInterpreter<Enterprise_MVC_Core, IEnumerable<InterpreterDto>> Interpreter)
        {
            _IInterpreter = Interpreter;
        }

        public IActionResult Index()
        {
            IEnumerable<Enterprise_MVC_Core> DefaultData = _IInterpreter.DefaultData<Enterprise_MVC_Core>();
            IEnumerable<InterpreterDto>  ExpressionData = _IInterpreter.Expression(null, new Context() { Expression = "YYYY MM DD"});
            // Other method
            IEnumerable<InterpreterDto>  ExpressionData2 = _IInterpreter.Expression2<InterpreterDto>(null, new Context() { Expression = "YYYY MM DD" });
            Tuple<IEnumerable<Enterprise_MVC_Core>, IEnumerable<InterpreterDto>, IEnumerable<InterpreterDto>> tuple;
            tuple = Tuple.Create(DefaultData, ExpressionData, ExpressionData2);
            
            return View(tuple);
        }
    }
}