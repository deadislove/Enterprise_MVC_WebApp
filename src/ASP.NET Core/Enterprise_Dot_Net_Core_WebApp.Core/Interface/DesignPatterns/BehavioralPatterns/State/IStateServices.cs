using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.State
{
    public interface IStateServices<T>: IDisposable where T :class 
    {
        void Execute(out Tuple<IEnumerable<T>, IEnumerable<T>> ReturnObj);
    }
}
