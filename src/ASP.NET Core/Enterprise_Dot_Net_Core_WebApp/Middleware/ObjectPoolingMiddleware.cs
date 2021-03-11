using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Middleware
{
    public class ObjectPoolingMiddleware
    {
        private readonly RequestDelegate next;

        public ObjectPoolingMiddleware(RequestDelegate _next)
        {
            this.next = _next;
        }

        public async Task InvokeAsync(HttpContext context, ObjectPool<StringBuilder> builderPool)
        {
            if (
                context.Request.Query.TryGetValue("Id", out var Id) &&
                context.Request.Query.TryGetValue("month", out var month) &&
                context.Request.Query.TryGetValue("day", out var day) &&
                int.TryParse(month, out var monthOfYear) &&
                int.TryParse(day, out var dayOfMonth))
            {
                var now = DateTime.UtcNow; 

                var stringBuilder = builderPool.Get();

                try
                {
                    stringBuilder.Append("Object Pooling ID - ")
                                 .Append(Id)
                                 .Append("; GUID - ")
                                 .Append(Guid.NewGuid().ToString());

                    var encoder = context.RequestServices.GetRequiredService<HtmlEncoder>();

                    if (now.Day == dayOfMonth && now.Month == monthOfYear)
                    {
                        stringBuilder.Append("Happy birthday!!!");

                        var html = encoder.Encode(stringBuilder.ToString());
                        await context.Response.WriteAsync(html);
                    }
                    else
                    {
                        var thisYearsDay = new DateTime(now.Year, monthOfYear, dayOfMonth);

                        int daysUntilBirthday = thisYearsDay > now
                            ? (thisYearsDay - now).Days
                            : (thisYearsDay.AddYears(1) - now).Days;

                        stringBuilder.Append("There are ")
                            .Append(daysUntilBirthday).Append(" days until your login again!");

                        var html = encoder.Encode(stringBuilder.ToString());
                        await context.Response.WriteAsync(html);
                    }
                }
                finally
                {
                    builderPool.Return(stringBuilder);
                }

                return;
            }

            await next(context);
        }
    }
}
