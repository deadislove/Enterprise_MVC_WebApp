using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Visitor;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Interface;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Visitor
{
    public class ConcreteVisitorComponentA<T> : IVisitorComponent<T> where T : class
    {
        private IDataExtension _dataExtension;

        public ConcreteVisitorComponentA()
        {
            _dataExtension = new DataExtensionDefault();
        }

        public void Accept(IVisitor<T> visitor)
        {
            visitor.VisitorConcreteComponentA(this);
        }

        public object ExclusiveMethodOfConcreteComponentA(object obj)
        {
            try
            {
                return (from source in obj as List<T>
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
        // ~ConcreteVisitorComponentA() {
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
