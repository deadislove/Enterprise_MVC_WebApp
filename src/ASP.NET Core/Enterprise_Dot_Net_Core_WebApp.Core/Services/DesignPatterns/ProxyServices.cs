using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Proxy;
using Enterprise_Dot_Net_Core_WebApp.Core.DTOs;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Proxy;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns
{
    public class ProxyServices<T> where T: class
    {
        private IProxy<T> iProxy;
        private Requests request;

        public ProxyServices(Requests _request,IGenericTypeRepository<T> repo)
        {
            request = _request;
            iProxy = new Proxy<T>(repo);
        }

        public void Response(out List<T> returnObj)
        {
            returnObj = iProxy.Request(request);
        }

        public void LoggingProcess(out List<Messages> returnObj)
        {
            iProxy.LoadLoggingInfo(out returnObj);
        }
    }
}
