using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Strategy;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Strategy
{
    public class StrategyContext<T>: IDisposable where T : class
    {
        private IStrategy _strategy;

        public StrategyContext() { }

        public StrategyContext(IStrategy strategy) => _strategy = strategy;

        public void SetStrategy(IStrategy strategy) => _strategy = strategy;

        public IEnumerable<T> DoStrategyThing(object source)
        {
            try
            {
                var result = _strategy.DoAlgorithm(source);

                return result as List<T>;
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
        // ~StrategyContext() {
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
