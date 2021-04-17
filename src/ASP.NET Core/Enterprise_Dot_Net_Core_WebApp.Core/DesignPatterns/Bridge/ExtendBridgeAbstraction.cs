using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
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
