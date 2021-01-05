using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace Enterprise_MVC_WebApplication.Infra.Interceptor
{
    public class InterceptorOfInfraAttribute: ContextAttribute, IContributeObjectSink
    {
        private readonly string layer = "Enterprise_MVC_WebApplication.Infra";

        public InterceptorOfInfraAttribute() : base("InterceptorOfInfraAttribute") { }
        
        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
        {
            return new InterceptorHandler(this.layer, nextSink);
        }
    }
}
