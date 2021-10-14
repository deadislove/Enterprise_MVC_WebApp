using Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns.Interpreter;
using System.Collections;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Interpreter
{
    public interface IInterpreter<in T1, out T2> where T1 : class where T2 : IEnumerable
    {
        T2 Expression(IEnumerable<T1> obj, Context context);

        IEnumerable<T> DefaultData<T>() where T : class;

        T2 Expression2<T>(IEnumerable<T1> obj, Context context) where T : InterpreterDto, new();
    }
}