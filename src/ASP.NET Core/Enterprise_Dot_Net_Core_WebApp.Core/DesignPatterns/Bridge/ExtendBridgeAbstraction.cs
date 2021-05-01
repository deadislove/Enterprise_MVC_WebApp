using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Bridge;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Bridge
{
    public class ExtendBridgeAbstraction : BridgeAbstraction
    {
        public ExtendBridgeAbstraction(IBridge bridge) : base(bridge)
        { }

        public override Task<object> GetAll()
        {
            return base.GetAll();
        }
    }
}
