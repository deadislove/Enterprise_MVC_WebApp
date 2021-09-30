using Enterprise_Dot_Net_Core_WebApp.Logging.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Enterprise_Dot_Net_Core_WebApp.Logging.Repository
{
    public class LogRepository : ActionFilterAttribute, ILogRepository
    {
        private readonly ILogger _logger;
        private string _routeRequestInfo;

        public LogRepository(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("LoggingActionFilter");
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("ClassFilter OnActionExecuting");

            if (context.ActionArguments.Count != 0)
                _logger.LogInformation("Parameter: " + JsonConvert.SerializeObject(context.ActionArguments.Values));

            //Record route info
            _routeRequestInfo = string.Format("Controller: {0}; Action: {1}", context.RouteData.Values["controller"], context.RouteData.Values["action"]);
            _logger.LogInformation(_routeRequestInfo);

            if (context.Result != null)
            {
                var resultMsg = context.Result;
                if (resultMsg is JsonResult json)
                {
                    _logger.LogInformation("JSON Serializer Setting: " + json.SerializerSettings);
                    _logger.LogInformation("JSON Content Type: " + json.ContentType);
                    _logger.LogInformation("JSON Status Code: " + json.StatusCode);
                    _logger.LogInformation("JSON Value: " + JsonConvert.SerializeObject(json.Value));
                }

                if (resultMsg is ViewResult view)
                {
                    _logger.LogInformation("View Name: " + view.ViewName);
                    _logger.LogInformation("View Status: " + view.StatusCode);
                    _logger.LogInformation("View ContentTpye:" + view.ContentType);
                    _logger.LogInformation("View Data: " + JsonConvert.SerializeObject(view.ViewData));
                    _logger.LogInformation("View Data Model: " + JsonConvert.SerializeObject(view.ViewData.Model));
                    _logger.LogInformation("Temp Data: " + JsonConvert.SerializeObject(view.TempData));
                }

            }

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("ClassFilter OnActionExecuted");
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation("ClassFilter OnResultExecuting");
                        
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation("ClassFilter OnResultExecuted");
            base.OnResultExecuted(context);
        }
    }
}
