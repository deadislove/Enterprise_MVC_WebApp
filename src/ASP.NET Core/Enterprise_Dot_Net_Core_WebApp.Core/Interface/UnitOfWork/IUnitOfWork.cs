using System;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.UnitOfWork
{
    public interface IUnitOfWork<T> : IDisposable where T  : class
    {
        IDemoUnitOfWork<T> DemoUnitOfWork { get; }

        Task Complete();
    }
}
