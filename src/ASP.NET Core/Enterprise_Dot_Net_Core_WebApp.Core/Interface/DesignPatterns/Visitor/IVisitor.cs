using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Visitor;
using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Visitor
{
    public interface IVisitor<T> : IDisposable where T :class
    {
        void VisitorConcreteComponentA(ConcreteVisitorComponentA<T> element);

        void VisitorConcreteComponentB(ConcreteVisitorComponentB<T> element);
    }
}
