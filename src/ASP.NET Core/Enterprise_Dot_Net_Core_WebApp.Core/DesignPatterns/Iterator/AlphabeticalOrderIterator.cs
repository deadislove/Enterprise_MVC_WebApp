using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Iterator;
using System;
using System.Collections;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Iterator
{
    public class AlphabeticalOrderIterator<T> : IIterator, IDisposable where T :class
    {
        private int _position = -1;
        private bool _reverse = false;
        private ItemCollection<T> _collection;

        object IEnumerator.Current => Current();

        public AlphabeticalOrderIterator(ItemCollection<T> collection, bool reverse = false)
        {
            _collection = collection;
            _reverse = reverse;

            if (reverse)
                _position = collection.GetItems().Count;
        }

        public object Current()
        {
            try
            {
                return _collection.GetItems()[_position];
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

        public int Key()
        {
            try
            {
                return _position;
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

        public bool MoveNext()
        {
            try
            {
                int updatedPosition = _position + (_reverse ? -1 : 1);

                if (updatedPosition >= 0 && updatedPosition < _collection.GetItems().Count)
                {
                    _position = updatedPosition;
                    return true;
                }
                else
                {
                    return false;
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

        public void Reset()
        {
            try
            {
                _position = _reverse ? _collection.GetItems().Count - 1 : 0;
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
        // ~AlphabeticalOrderIterator() {
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
