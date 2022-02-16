using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.TemplateMethod
{
    public interface ITemplateMethodServices<T> : IDisposable where T : class
    {
        IList<IEnumerable<T>> Execute();
    }
}
