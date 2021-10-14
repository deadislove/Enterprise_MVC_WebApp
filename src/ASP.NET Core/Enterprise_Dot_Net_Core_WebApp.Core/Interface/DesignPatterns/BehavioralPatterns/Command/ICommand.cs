using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Command
{
    public interface ICommand<in T1, out T2> where T1: class where T2: class
    {
        Task<List<T>> ExecuteResult<T>(T1 requestObj);

        void SetOnStart(ICommandExe commandExe);

        void SetOnFinish(ICommandExe commandExe);
    }
}
