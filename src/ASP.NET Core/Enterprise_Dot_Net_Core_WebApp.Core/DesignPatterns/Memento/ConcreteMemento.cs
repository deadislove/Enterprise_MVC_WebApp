using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Memento;
using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Memento
{
    public class ConcreteMemento<T> : IMemento<T>, IDisposable where T : class
    {
        private T _State;
        private DateTime _Date;

        public ConcreteMemento(T State)
        {
            _State = State;
            _Date = DateTime.Now;
        }

        public DateTime GetDate() => _Date;

        public T ObjectStatus() => _State;
        

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
        ~ConcreteMemento()
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
