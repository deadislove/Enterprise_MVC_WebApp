using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.UnitOfWork
{
    public interface IDemoUnitOfWork<T> where T : class
    {
        IEnumerable<T> DemoGetAll();
    }
}
