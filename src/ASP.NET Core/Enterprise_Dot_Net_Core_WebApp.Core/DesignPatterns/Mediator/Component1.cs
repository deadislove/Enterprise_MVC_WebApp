using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Mediator;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Interface;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Mediator
{
    public class Component1<T> : BaseComponent<T>, IDisposable where T : class
    {
        private IDataExtension _dataExtension;

        #region Constructor 
        public Component1() : base()
        {
            DataExtensionInitialization();
        }

        public Component1(IMediator<T> iMediator) : base(iMediator)
        {
            DataExtensionInitialization();
        }
        #endregion

        private void DataExtensionInitialization()
        {
            _dataExtension = new DataExtensionDefault();
        }

        public void SortAes<T>(object obj, out List<T> returnObj) where T : class
        {
            try
            {                
                DoSortAes<T>(obj, out returnObj);

                iMediator.Notify(returnObj, "Aes");
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

        public new void SetMediator(IMediator<T> _iMediator) => iMediator = _iMediator;

        private void DoSortAes<T>(object obj, out List<T> returnObj) where T : class
        {
            try
            {
                returnObj = (from source in obj as List<T>
                             orderby _dataExtension.GetDynamicSortProperty(source, "ID") ascending
                             select source).ToList();
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
        // ~Component1() {
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
