using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface
{
    public interface IFactoryMethod<T> where T : class
    {
        Task<T> GetById(int? id);
    }
}
