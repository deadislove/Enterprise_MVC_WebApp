namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Observer
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
