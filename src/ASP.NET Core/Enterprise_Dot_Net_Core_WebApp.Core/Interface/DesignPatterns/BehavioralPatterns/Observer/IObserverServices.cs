using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Observer
{
    public interface IObserverServices : IDisposable
    {
        void Operation(out List<string> HistoryMsgList);
    }
}
