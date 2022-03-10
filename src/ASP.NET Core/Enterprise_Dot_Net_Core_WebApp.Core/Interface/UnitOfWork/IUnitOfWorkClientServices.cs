using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.UnitOfWork
{
    public interface IUnitOfWorkClientServices<T> : IDisposable where T : class
    {
        IEnumerable<T> Execute();
    }
}
