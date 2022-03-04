using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Visitor;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Visitor
{
    public class VisitorObjStructure<T> where T : class
    {
        public static List<IVisitorComponent<T>> components { get; private set; }

        public VisitorObjStructure()
        {
            components = new List<IVisitorComponent<T>>();
        }

        public void Attach(IVisitorComponent<T> component) => components.Add(component);

        public void Detach(IVisitorComponent<T> component) => components.Remove(component);

        public static void Accept(IVisitor<T> visitor)
        {
            foreach(IVisitorComponent<T> component in components)
            {
                component.Accept(visitor);
            }
        }
    }
}
