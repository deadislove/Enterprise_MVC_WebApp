using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.TemplateMethod;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.TemplateMethod;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.TemplateMethod
{
    public class TemplateMethodServices<T> : ITemplateMethodServices<T> where T : class
    {
        private IGenericTypeRepository<T> _repo;
        private IList<IEnumerable<T>> Result;

        public TemplateMethodServices(IGenericTypeRepository<T> repo)
        {
            _repo = repo;
        }

        public IList<IEnumerable<T>> Execute()
        {
            try
            {
                Result = Result ?? new List<IEnumerable<T>>();

                TemplateClient.ClientCode(new ConcreteSortTemplateMethod<T>(_repo), out object obj);
                Result.Add(obj as List<T>);
                TemplateClient.ClientCode(new ConcreteReverseTemplateMethod<T>(_repo), out obj);
                Result.Add(obj as List<T>);
                return Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TemplateMethodServices() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
