using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Flyweight
{
    public interface IFlyweight<T> where T : class
    {
        Task<List<T>> GetList();
    }
}
