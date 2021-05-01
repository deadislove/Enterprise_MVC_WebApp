using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Composite
{
    public abstract class Component
    {
        public Component() { }

        public abstract object Operation(int? id);

        public virtual void Add(object obj) => throw new NotImplementedException();

        public virtual void Remove(object obj) => throw new NotImplementedException();

        public virtual bool IsComposite() => true;
    }
}
