using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Facade
{
    public interface IFacade<T> where T : class
    {
        Task<T> GetById(int? id);
    }
}
