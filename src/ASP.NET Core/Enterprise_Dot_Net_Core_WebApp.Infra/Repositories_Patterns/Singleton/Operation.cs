using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Singleton;
using System;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Singleton
{
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton, IDisposable
    {
        public Operation()
        {
            string obj = Guid.NewGuid().ToString();
            OperationId = obj.Substring(obj.Length - 4);
        }

        public string OperationId { get; }

        string IOperationTransient.OperationId()
        {
            try
            {
                if (string.IsNullOrEmpty(OperationId))
                    throw new NotImplementedException();
                else
                    return OperationId;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            finally
            {
                Dispose();
            }
        }

        string IOperationScoped.OperationId()
        {
            try
            {
                if (string.IsNullOrEmpty(OperationId))
                    throw new NotImplementedException();
                else
                    return OperationId;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            finally
            {
                Dispose();
            }
        }

        string IOperationSingleton.OperationId()
        {
            try
            {
                if (string.IsNullOrEmpty(OperationId))
                    throw new NotImplementedException();
                else
                    return OperationId;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
