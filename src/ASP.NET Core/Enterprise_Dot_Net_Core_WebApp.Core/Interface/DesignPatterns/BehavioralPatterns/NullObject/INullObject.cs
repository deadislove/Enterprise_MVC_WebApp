using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.NullObject
{
    public interface INullObject
    {
        Tuple<IEnumerable<string>> Operation();
    }
}
