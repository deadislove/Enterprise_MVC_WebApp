using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Memento
{
    public interface IMementoServices<T> where T : class
    {
        void Operation(out Tuple<IEnumerable<string>, IEnumerable<string>> ResultList);
    }
}
