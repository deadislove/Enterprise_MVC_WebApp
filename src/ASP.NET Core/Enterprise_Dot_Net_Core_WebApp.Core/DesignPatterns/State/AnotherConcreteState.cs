using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.State
{
    public class AnotherConcreteState<T> : State<T> where T : class
    {
        public override void AnotherHandle(object obj)
        {
            _context.Result = obj as List<T>;
            _context.TransitionTo(new ConcreteState<T>());
        }

        public override void Handle(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
