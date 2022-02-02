using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Strategy;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Strategy;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Strategy
{
    public class StrategyServices<T> : IStrategyServices<T> where T : class
    {
        private IGenericTypeRepository<T> _repo;
        private IList<IEnumerable<T>> _result;
        private object obj;

        public StrategyServices(IGenericTypeRepository<T> repo)
        {
            _repo = repo;

            DataInitialization();
        }

        private void DataInitialization()
        {
            obj = _repo.GetAll().Result;
            _result = new List<IEnumerable<T>>();
        }

        public IList<IEnumerable<T>> Execute()
        {
            try
            {
                var context = new StrategyContext<T>();
                context.SetStrategy(new ConcreteStrategySort<T>());
                _result.Add(context.DoStrategyThing(obj) as List<T>);

                context.SetStrategy(new ConcreteStrategyReverse<T>());
                _result.Add(context.DoStrategyThing(obj) as List<T>);

                return _result;
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
        // ~StrategyServices() {
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
