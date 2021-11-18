using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Mediator;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Interface;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Mediator
{
    public class Component2<T> : BaseComponent<T>, IDisposable where T : class
    {
        private IDataExtension _dataExtension;

        #region Constructor
        public Component2() : base()
        {
            DataExtensionInitialization();
        }

        public Component2(IMediator<T> iMediator) : base(iMediator)
        {
            DataExtensionInitialization();
        }
        #endregion

        private void DataExtensionInitialization()
        {
            _dataExtension = new DataExtensionDefault();
        }

        public void SortDesc<T>(object obj, out List<T> returnObj) where T : class
        {
            try
            {
                DoSortDesc(obj, out returnObj);

                iMediator.Notify(obj, "Desc");
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

        public void SortDescTop<T>(object obj, out T returnObj) where T : class
        {
            try
            {
                DoSortDescTop<T>(obj, out returnObj);

                iMediator.Notify(returnObj, "DescTop1");
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

        private void DoSortDesc<T>(object obj, out List<T> returnObj) where T : class
        {
            try
            {
                returnObj = (from source in obj as List<T>
                             orderby _dataExtension.GetDynamicSortProperty(source, "ID") descending
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

        private void DoSortDescTop<T>(object obj, out T returnObj) where T : class
        {
            try
            {
                returnObj = (from source in obj as List<T>
                             orderby _dataExtension.GetDynamicSortProperty(source, "ID") descending
                             select source
                             ).ToList().FirstOrDefault();
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
        // ~Component2() {
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
