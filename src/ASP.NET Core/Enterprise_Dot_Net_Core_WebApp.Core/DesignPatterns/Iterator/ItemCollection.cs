using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Iterator;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Iterator
{
    public class ItemCollection<T> : IIteratorAggregate, IDisposable where T : class
    {
        List<T> _collection = new List<T>();

        private bool _direction = false;

        public void ReverseDirection()
        {
            try
            {
                _direction = !_direction;
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

        public void AddItem(T Item)
        {
            try
            {
                _collection.Add(Item);
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

        public List<T> GetItems()
        {
            try
            {
                return _collection;
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

        public IEnumerator GetEnumerator()
        {
            try
            {
                return new AlphabeticalOrderIterator<T>(this, _direction);
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

        public static implicit operator List<T>(ItemCollection<T> v)
        {
            try
            {

                List<T> obj = new List<T>();
                foreach (var item in v)
                {
                    obj.Add(item as T);
                }

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
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
        ~ItemCollection()
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
