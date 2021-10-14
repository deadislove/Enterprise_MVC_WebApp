using Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns.Interpreter;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Interpreter;
using System.Text.RegularExpressions;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Interpreter
{
    public class SeparatorExpression : IAbstractExpression
    {
        private string expression;
        private readonly string pattern = @"\s";
        public void Evaluate(Context context)
        {
            Regex regex = new Regex(pattern, RegexOptions.None);
            expression = context.Expression;
            context.Expression = regex.Replace(expression, "-");
        }
    }
}
