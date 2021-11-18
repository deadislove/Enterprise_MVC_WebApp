using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Iterator;
using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Iterator.AbstractIterator;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Iterator;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Iterator
{
    public class IteratorServices<T> : IIteratorServices<T>, IDisposable where T :class
    {
        private ItemCollection<T> itemCollection;
        private AbstractItemCollection<T> abstractItemCollection;
        private IGenericTypeRepository<T> genericRepo;
        private List<T> returnObj;

        public IteratorServices(IGenericTypeRepository<T> _genericRepo)
        {
            genericRepo = _genericRepo;
            DataAccess();
        }

        private void DataAccess()
        {
            try
            {
                itemCollection = new ItemCollection<T>();
                abstractItemCollection = new AbstractItemCollection<T>();
                foreach (var item in genericRepo.GetAll().Result)
                {
                    itemCollection.AddItem(item);
                    abstractItemCollection.AddItem(item);
                }
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

        public IEnumerable<T> IteratorOperation()
        {
            try
            {
                itemCollection.ReverseDirection();
                returnObj = itemCollection;

                return returnObj;
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

        public IEnumerable<T> IteratorDefault()
        {
            try
            {
                returnObj = itemCollection;
                return returnObj;
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

        public IEnumerable<T> AbstractIteratorDefault()
        {
            try
            {
                returnObj = abstractItemCollection;
                return returnObj;
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

        public IEnumerable<T> AbstractIteratorOperation()
        {
            try
            {
                abstractItemCollection.ReverseDirection();
                returnObj = itemCollection;

                return returnObj;
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
                    returnObj = new List<T>();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~IteratorServices()
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
