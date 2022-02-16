using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.TemplateMethod;
using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.TemplateMethod
{
    public abstract class TemplateAbstract<T> : ITemplateMethod where T : class
    {
        private IGenericTypeRepository<T> _repo;
        public object _obj;


        public TemplateAbstract(IGenericTypeRepository<T> repo)
        {
            _repo = repo;
        }

        public void TemplateMethod()
        {
            try
            {
                BaseOperationDefault();
                RequestOperationDefault(_obj);
                BaseOperationSort();
                HookDefault();
                RequestOperationSort(_obj);
                HookSort();
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

        protected void BaseOperationDefault()
        {
            _obj = _repo.GetAll().Result;
        }

        protected void BaseOperationSort()
        { }

        protected abstract void RequestOperationDefault(object obj);

        protected abstract void RequestOperationSort(object obj);

        protected virtual void HookDefault() { }
        protected virtual void HookSort() { }

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
        // ~TemplateAbstract() {
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
