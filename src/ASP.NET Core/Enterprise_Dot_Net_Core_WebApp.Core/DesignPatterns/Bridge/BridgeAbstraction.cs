using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Bridge;
using System;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Bridge
{
    public abstract class BridgeAbstraction : IDisposable
    {
        protected IBridge bridge;

        public BridgeAbstraction(IBridge _bridge)
        {
            this.bridge = _bridge;
        }

        public virtual Task<object> GetAll()
        {
            try
            {
                return Task.Run(() => this.bridge.GetAll());
            }
            catch (Exception ex)
            {
                return Task.FromResult((object)null);
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
