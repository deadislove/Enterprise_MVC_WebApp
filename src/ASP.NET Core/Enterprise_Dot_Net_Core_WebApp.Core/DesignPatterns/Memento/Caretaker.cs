using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Memento;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Memento
{
    public class Caretaker<T> : IDisposable where T : class
    {

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
        ~Caretaker()
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

        private List<IMemento<T>> _ImementoList = new List<IMemento<T>>();
        private Originator<T> _Originator;

        #region constructor
        public Caretaker() : base()
        { }

        public Caretaker(Originator<T> originator)
        {
            _Originator = originator;
        }
        #endregion

        #region Backup
        /// <summary>
        /// Backup operation
        /// </summary>
        public void Backup()
        {
            try
            {
                _ImementoList.Add(_Originator.Save());
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
        #endregion

        #region Undo
        /// <summary>
        /// Undo operation
        /// </summary>
        public void Undo()
        {
            if (_ImementoList.Count == 0)
                return;

            var memento = _ImementoList.Last();
            _ImementoList.Remove(memento);

            try
            {
                _Originator.Restore(memento);
            }
            catch (Exception ex)
            {
                Undo();
            }
            finally
            {
                Dispose();
            }
        }
        #endregion

        #region Show history
        /// <summary>
        /// Show history
        /// </summary>
        /// <param name="ReturnObj"></param>
        public void ShowHistory(out List<T> ReturnObj)
        {
            var StoreData = new List<T>();

            if (_ImementoList.Count == 0)
                ReturnObj = StoreData;

            try
            {
                foreach (var item in _ImementoList)
                {
                    StoreData.Add(item.ObjectStatus());
                }

                ReturnObj = StoreData;
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
        #endregion
    }
}
