using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Observer;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Observer
{
    public class ConcreteObserver : IObserver
    {
        private List<string> ConcreteObserverMsgHistoryList = new List<string>();
        private ConcreteSubject subjectStatus = new ConcreteSubject();
        
        public void Update(ISubject subject)
        {
            subjectStatus.Obj = (subject as Subject).Obj;
            if (subjectStatus.Obj is null)
                ConcreteObserverMsgHistoryList.Add("Object is null");
            else
                ConcreteObserverMsgHistoryList.Add(JsonConvert.SerializeObject(subjectStatus.Obj, Formatting.Indented));
        }

        public List<string> LayoutHistory() => ConcreteObserverMsgHistoryList;

        public void Add (string Msg) => ConcreteObserverMsgHistoryList.Add(Msg);
    }
}
