
namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Decorator
{
    public abstract class Component<T> where T : class
    {
        public abstract string ReadJsonData(int? id); 
    }
}
