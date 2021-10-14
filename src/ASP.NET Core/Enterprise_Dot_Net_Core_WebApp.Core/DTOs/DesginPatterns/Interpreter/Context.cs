using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns.Interpreter
{
    public class Context
    {
        public string Expression { get; set; }

        public DateTime Date { get; set; }

        public Context(DateTime date) => this.Date = date;

        public Context() { }

    }
}
