using Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns.Interpreter;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Interpreter
{
    public interface IAbstractExpression
    {
        void Evaluate(Context context);
    }
}
