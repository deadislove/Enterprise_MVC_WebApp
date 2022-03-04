using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Visitor
{
    public interface IVisitorComponent<T> : IDisposable where T : class
    {
        void Accept(IVisitor<T> visitor);
    }
}