using Newtonsoft.Json;
using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Routing;

namespace Enterprise_MVC_WebApplication.Logging
{
    public class LogAttribute : ActionFilterAttribute, IActionFilter
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData,null,null);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData,null, filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData,filterContext,null);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting ", filterContext.RouteData, null,null);
        }

        private void Log(string methodName, RouteData routeData, ResultExecutedContext context, ActionExecutingContext actionExecutingContext)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0}- controller:{1} action:{2}", methodName,
                                                                        controllerName,
                                                                        actionName);
            
            RecordLogMsg(message);
            if (context != null)
            {
                if (context.Result != null)
                {                    
                    var obj = context.Result;
                    if (obj is JsonResult json)
                    {
                        if(json.ContentType != null || json.ContentType != "")
                            RecordLogMsg("JSON Rsult: "+ json.ContentType);
                        if (json.Data != null || json.Data != "")
                            RecordLogMsg( "JSON Data: "+ JsonConvert.SerializeObject(json.Data));
                    }
                    else if (obj is ViewResult view)
                    {
                        if( view.ViewBag != null || view.ViewBag != "")
                            RecordLogMsg("View Bag: " + JsonConvert.SerializeObject(view.ViewBag));
                        if (view.TempData != null)
                            RecordLogMsg("Temp Data: "+ JsonConvert.SerializeObject(view.TempData));
                        if (view.ViewData != null )
                            RecordLogMsg("View Data: " + JsonConvert.SerializeObject(view.ViewData));
                        if (view.Model != null)
                            RecordLogMsg("Model: "+ JsonConvert.SerializeObject(view.Model));
                    }
                }
            }
        }

        private void RecordLogMsg(string Msg)
        {
            var Path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;

            if (Directory.Exists($"{Path}\\Logs"))
            {
                File.AppendAllText(
                    $"{Path}\\Logs\\{DateTime.Now.ToString("yyyyMMdd")}_Log.txt", 
                    DateTime.Now.ToString("yyyyMMdd HH:mm:sss") +"\t" + Msg + "\n", 
                    System.Text.Encoding.UTF8);
            }
            else
            {
                Directory.CreateDirectory($"{Path}\\Logs");
                File.AppendAllText(
                    $"{Path}\\Logs\\{DateTime.Now.ToString("yyyyMMdd")}_Log.txt", 
                    DateTime.Now.ToString("yyyyMMdd HH:mm:sss") + "\t" + Msg + "\n", 
                    System.Text.Encoding.UTF8);
            }
        }
    }
}