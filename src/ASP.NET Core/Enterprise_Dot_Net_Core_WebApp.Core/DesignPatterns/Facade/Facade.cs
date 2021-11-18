using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Facade
{
    public class Facade : IDisposable
    {
        protected FacadeSubsystem1<Enterprise_MVC_Core> repo1;
        protected FacadeSubsystem2<Enterprise_MVC_Core> repo2;

        public Facade(FacadeSubsystem1<Enterprise_MVC_Core> _repo1, FacadeSubsystem2<Enterprise_MVC_Core> _repo2)
        {
            this.repo1 = _repo1;
            this.repo2 = _repo2;
        }

        public List<object> OperationFacade()
        {
            List<object> list = new List<object>
            {
                repo1.OperationInitiation().Result,
                repo1.Operation(null).Result,
                repo2.OperationInitiation().Result,
                repo2.Operation(null).Result
            };

            return list;
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
                    repo1.Dispose();
                    repo2.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~Facade()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
