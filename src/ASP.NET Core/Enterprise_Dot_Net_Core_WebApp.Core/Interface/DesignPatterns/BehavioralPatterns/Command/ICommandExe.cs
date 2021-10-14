using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Command
{
    public interface ICommandExe
    {
        Task<T> Execute<T>(object obj, object reqObj) where T : class;
    }
}
