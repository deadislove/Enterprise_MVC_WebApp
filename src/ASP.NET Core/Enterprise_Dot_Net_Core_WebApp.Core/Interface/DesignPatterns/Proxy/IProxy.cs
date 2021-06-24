using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Proxy;
using Enterprise_Dot_Net_Core_WebApp.Core.DTOs;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Proxy
{
    public interface IProxy<T>
    {
        List<T> Request(Requests requests);
        void LoadLoggingInfo(out List<Messages> returnObj);
    }
}
