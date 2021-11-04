using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Mediator;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Mediator
{
    public class MediatorServices<T> : IMediatorExe<T>, IDisposable where T : class
    {
        private IGenericTypeRepository<T> repo;
        private Mediator<T> mediator;
        private object DataObj;
        private Component1<T> component1;
        private Component2<T> component2;

        public MediatorServices(IGenericTypeRepository<T> _repo)
        {
            repo = _repo;
            DataAccess();
        }

        private void DataAccess()
        {
            component1 = new Component1<T>();
            component2 = new Component2<T>();
            mediator = new Mediator<T>(component1, component2);
            DataObj = repo.GetAll().Result;
        }

        public void MediatorExe(out ICollection<IEnumerable<T>> returnObj)
        {
            returnObj = new List<IEnumerable<T>>();
            component1.SortAes<T>(DataObj, out List<T> defaultData);
            returnObj.Add(defaultData.AsEnumerable());
            mediator.LayoutData(out ICollection<IEnumerable<T>> layoutData);

            foreach (var item in layoutData)
            {
                returnObj.Add(item);
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
                    DataObj = (dynamic)null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MediatorServices() {
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
