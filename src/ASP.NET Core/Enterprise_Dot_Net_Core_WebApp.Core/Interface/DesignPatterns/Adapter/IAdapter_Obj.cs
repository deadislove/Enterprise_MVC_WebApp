using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Adapter
{
    public interface IAdapter_Obj<T> where T : class
    {
        IEnumerable<T> GetRequest();
    }
}
