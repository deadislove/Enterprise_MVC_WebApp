using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Singleton;
using System;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Singleton
{
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton
    {
        public Operation()
        {
            string obj = Guid.NewGuid().ToString();
            OperationId = obj.Substring(obj.Length - 4);
        }

        public string OperationId { get; }

        string IOperationTransient.OperationId()
        {
            if (string.IsNullOrEmpty(OperationId))
                throw new NotImplementedException();
            else
                return OperationId;
        }

        string IOperationScoped.OperationId()
        {
            if (string.IsNullOrEmpty(OperationId))
                throw new NotImplementedException();
            else
                return OperationId;
        }

        string IOperationSingleton.OperationId()
        {
            if (string.IsNullOrEmpty(OperationId))
                throw new NotImplementedException();
            else
                return OperationId;
        }
    }
}
