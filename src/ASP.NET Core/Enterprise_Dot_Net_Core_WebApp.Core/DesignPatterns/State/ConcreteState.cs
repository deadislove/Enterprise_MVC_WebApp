using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.State
{
    public class ConcreteState<T> : State<T> where T : class
    {
        public override void AnotherHandle(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Handle(object obj)
        {
            List<T> temp = obj is null ? new List<T>() : obj as List<T>;

            var Result = temp.Select(s => s).Skip(0).Take(1);

            _context.Result = Result;
            _context.TransitionTo(new AnotherConcreteState<T>());
        }
    }
}
