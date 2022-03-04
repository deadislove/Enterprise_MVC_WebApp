using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Visitor
{
    public interface IVisitorServices<T> : IDisposable where T :class
    {
        IList<IEnumerable<T>> Execute();
    }
}
