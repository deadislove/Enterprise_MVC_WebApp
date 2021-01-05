using Newtonsoft.Json;
using System.Diagnostics;
using System.Web.Mvc;

namespace Enterprise_MVC_WebApplication.Logging
{
    public class ExtendedActionAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string parametersInfo = JsonConvert.SerializeObject(filterContext.ActionParameters, new JsonSerializerSettings());
            string routeData = JsonConvert.SerializeObject(filterContext.RouteData.Values);
            Debug.WriteLine("OnActionExecuting");
            Debug.WriteLine(routeData);
            Debug.WriteLine(parametersInfo);

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}