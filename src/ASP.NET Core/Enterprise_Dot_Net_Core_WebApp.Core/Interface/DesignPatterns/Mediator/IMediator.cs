using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Mediator
{
    public interface IMediator<T> where T : class
    {
        void Notify(object sender, string ev);

        void LayoutData(out ICollection<IEnumerable<T>> LayoutData);
    }
}
