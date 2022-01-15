using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.State;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.State
{
    public interface IState_Context<T> : IDisposable where T : class
    {
        void TransitionTo(State<T> state);

        void Request(Object obj);

        void AnotherRequest(object obj = null);

        IEnumerable<T> Response();
    }
}
