using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace Enterprise_MVC_WebApplication.Infra.Interceptor
{
    public class InterceptorHandler:IMessageSink
    {
        private string _callLayer;

        private IMessageSink _nextSink;

        public InterceptorHandler(string callLayer, IMessageSink nextSink)
        {
            this._callLayer = callLayer;
            this._nextSink = nextSink;
        }

        public IMessageSink NextSink
        {
            get { return _nextSink; }
        }

        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMethodCallMessage interceptMsg = msg as IMethodCallMessage;

            #region Parameter information

            IDictionary parameters = new Dictionary<string, object>();
            IList<string> parameterSignatures = new List<string>();
            for (int i = 0; i < interceptMsg.Args.Length; i++)
            {
                parameters.Add(interceptMsg.GetInArgName(i), interceptMsg.GetArg(i));
            }

            foreach (Type signature in (Array)interceptMsg.MethodSignature)
            {
                parameterSignatures.Add(signature.FullName);
            }

            string parametersInfo = string.Empty;

            if (parameters.Count != 0)
            {
                parametersInfo = JsonConvert.SerializeObject(parameters, new JsonSerializerSettings()
                {
                    ContractResolver = new ReadablePropertiesOnlyResolver()
                });
            }

            #endregion

            // Messages body
            string message = string.Format(
                "[{0}] {1}.{2}({3}) => {4}",
                this._callLayer,
                interceptMsg.TypeName.Split(',')[0],
                interceptMsg.MethodName,
                parameterSignatures.Count > 0 ? string.Join(",", parameterSignatures) : string.Empty,
                string.IsNullOrEmpty(parametersInfo) ? "Empty" : parametersInfo
                );

            //Record log
            Debug.WriteLine("David Infra layer");
            Debug.WriteLine(message);

            return this.NextSink.SyncProcessMessage(msg);
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink) { return null; }
    }

    class ReadablePropertiesOnlyResolver : DefaultContractResolver
    {
        /// <summary>
        /// Build the analytics property.
        /// </summary>
        /// <returns>Display property information</returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (typeof(Stream).IsAssignableFrom(property.PropertyType))
            {
                property.Ignored = true;
            }
            return property;
        }
    }
}
