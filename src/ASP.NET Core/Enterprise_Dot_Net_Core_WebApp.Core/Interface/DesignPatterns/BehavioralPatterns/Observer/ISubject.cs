using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Observer
{
    public interface ISubject : IDisposable
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
}
