using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Bridge
{
    public interface IBridge
    {
        Task<object> GetAll();
    }
}
