using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Bridge;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Bridge
{
    public abstract class BridgeAbstraction
    {
        protected IBridge bridge;

        public BridgeAbstraction(IBridge _bridge)
        {
            this.bridge = _bridge;
        }

        public virtual Task<object> GetAll()
        {
            return Task.Run(() => this.bridge.GetAll());
        }
    }
}
