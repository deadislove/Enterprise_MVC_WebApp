using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Flyweight;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Flyweight
{
    public class FlyweightRepo<T> : IFlyweight<T>, IDisposable where T : class
    {
        private IGenericTypeRepository<T> repo;

        public FlyweightRepo(IGenericTypeRepository<T> _repo)
        {
            this.repo = _repo;
        }

        public async Task<List<T>> GetList()
        {
            try
            {
                dynamic obj = repo.GetAll().Result;

                return await Task.Run(() => obj as List<T>);
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
        // ~FlyweightRepo() {
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
