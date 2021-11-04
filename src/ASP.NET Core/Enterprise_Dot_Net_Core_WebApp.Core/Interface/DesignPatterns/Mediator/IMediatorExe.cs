using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Mediator
{
    public interface IMediatorExe<T> where T : class
    {
        void MediatorExe(out ICollection<IEnumerable<T>> returnObj);
    }
}
