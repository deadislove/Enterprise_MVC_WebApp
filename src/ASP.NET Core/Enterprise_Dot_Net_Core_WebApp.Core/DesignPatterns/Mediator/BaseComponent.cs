using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Mediator;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Mediator
{
    public class BaseComponent<T> where T : class
    {
        protected IMediator<T> iMediator;

        public BaseComponent(IMediator<T> _iMediator = null) => iMediator = _iMediator;

        public void SetMediator(IMediator<T> _iMediator) => iMediator = _iMediator;
    }
}
