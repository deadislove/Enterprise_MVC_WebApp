using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Newtonsoft.Json;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Flyweight
{
    public class Flyweight
    {
        public Enterprise_MVC_Core sharedState;

        public Flyweight(Enterprise_MVC_Core enterprise_MVC_Core)
        {
            this.sharedState = enterprise_MVC_Core;
        }

        public void Operation(Enterprise_MVC_Core uniqueState, out string Result)
        {
            string s = JsonConvert.SerializeObject(this.sharedState);
            string u = JsonConvert.SerializeObject(uniqueState);
            Result = $"Flyweight: Displaying shared {s} and unique {u} state.";
        }
    }
}
