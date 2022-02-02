using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Strategy
{
    public interface IStrategyServices<T> : IDisposable where T: class
    {
        IList<IEnumerable<T>> Execute();
    }
}