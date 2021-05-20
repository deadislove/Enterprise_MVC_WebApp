using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Facade;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns
{
    public class FacadeServices : IDisposable
    {
        private Facade facade;

        public FacadeServices(FacadeSubsystem1<Enterprise_MVC_Core> facadeSubsystem1,FacadeSubsystem2<Enterprise_MVC_Core> facadeSubsystem2)
        {
            facade = new Facade(facadeSubsystem1, facadeSubsystem2);
        }

        public List<object> Layout()
        {
            try
            {
                return facade.OperationFacade();
            }
            catch (Exception ex)
            {
                return new List<object>();
            }
            finally
            {
                Dispose(true);
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
        // ~FacadeServices() {
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
