﻿using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.UnitOfWork;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.UnitOfWork
{
    public class UnitOfWorkServices<T> : IUnitOfWork<T> where T : class
    {
        private IGenericTypeRepository<T> _repo;

        public UnitOfWorkServices(IGenericTypeRepository<T> repo) => _repo = repo;

        public IDemoUnitOfWork<T> DemoUnitOfWork => new DemoUnitOfWork<T>(_repo);

        public Task Complete()
        {
            return _repo.SaveChange();
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
        // ~UnitOfWorkServices() {
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
