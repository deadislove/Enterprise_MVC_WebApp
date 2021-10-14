﻿using Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns.Interpreter;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Interpreter;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Interpreter
{
    public class MonthExpression : IAbstractExpression
    {
        private string expression;

        public void Evaluate(Context context)
        {
            expression = context.Expression;
            context.Expression = expression.Replace("MM", context.Date.Month.ToString());
        }
    }
}
