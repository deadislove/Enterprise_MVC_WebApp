using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Decorator
{
    public interface IDecorator<T> where T : class
    {
        Task<T> GetById(int? id);
    }
}
