using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Memento
{
    public interface IMemento<T> where T : class
    {
        T ObjectStatus();

        DateTime GetDate();
    }
}
