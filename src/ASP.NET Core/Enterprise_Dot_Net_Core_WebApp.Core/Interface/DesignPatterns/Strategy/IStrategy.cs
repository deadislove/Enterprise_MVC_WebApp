using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Strategy
{
    public interface IStrategy : IDisposable
    {
        object DoAlgorithm(object obj);
    }
}
