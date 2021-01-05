using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace Enterprise_MVC_WebApplication.Core.Interceptor
{
    public class InterceptorOfCoreAttribute : ContextAttribute, IContributeObjectSink
    {        
        private readonly string layer = "Enterprise_MVC_WebApplication.Core";

        public InterceptorOfCoreAttribute() : base("InterceptorOfCoreAttribute") { }

        
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            return new InterceptorHandler(this.layer, nextSink);
        }
    }
}
