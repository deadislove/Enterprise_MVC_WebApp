using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Mediator
{
    public class Mediator<T> : IMediator<T>, IDisposable where T : class
    {
        private Component1<T> component1;
        private Component2<T> component2;
        private ICollection<IEnumerable<T>> resultCollection = new List<IEnumerable<T>>();

        public Mediator(Component1<T> obj1, Component2<T> obj2)
        {
            component1 = obj1;
            component1.SetMediator(this);
            component2 = obj2;
            component2.SetMediator(this);
        }

        public void Notify(object sender, string ev)
        {
            try
            {
                switch (ev)
                {
                    case "Aes":
                        component2.SortDesc<T>(sender, out List<T> returnDescObj);
                        resultCollection.Add(returnDescObj.AsEnumerable());
                        break;
                    case "Desc":
                        component2.SortDescTop<T>(sender, out T returnObj);
                        
                        resultCollection.Add(new List<T>
                        {
                            returnObj
                        });
                        break;
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

        public void LayoutData(out ICollection<IEnumerable<T>> LayoutData) => LayoutData = resultCollection;
        
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
        // ~Mediator() {
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
