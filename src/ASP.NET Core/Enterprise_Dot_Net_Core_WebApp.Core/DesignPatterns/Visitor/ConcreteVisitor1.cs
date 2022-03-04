using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Visitor;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Visitor
{
    public class ConcreteVisitor1<T> : IVisitor<T> where T : class
    {
        private IList<IEnumerable<T>> Result = new List<IEnumerable<T>>();
        private Object _obj;

        public ConcreteVisitor1(object obj)
        {
            _obj = obj;
        }

        public void VisitorConcreteComponentA(ConcreteVisitorComponentA<T> element)
        {
            object ResultObj = element.ExclusiveMethodOfConcreteComponentA(_obj);
            Result.Add(ResultObj as List<T>);
        }

        public void VisitorConcreteComponentB(ConcreteVisitorComponentB<T> element)
        {
            object ResultObj = element.SpeicalMethodOfConcreteComponentB(_obj);
            Result.Add(new List<T> { ResultObj as T});            
        }

        public IList<IEnumerable<T>> LayoutResult() => Result;

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
        // ~ConcreteVisitor1() {
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
