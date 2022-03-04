using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Visitor;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Visitor;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Visitor
{
    public class VisitorServices<T> : IVisitorServices<T> where T : class
    {
        private IGenericTypeRepository<T> _repo;
        private Object DataObj;
        private IList<IEnumerable<T>> Result = new List<IEnumerable<T>>();

        public VisitorServices(IGenericTypeRepository<T> repo)
        {
            _repo = repo;
            ServiceInitialization();
        }

        private void ServiceInitialization()
        {
            DataObj = _repo.GetAll().Result;
        }

        public IList<IEnumerable<T>> Execute()
        {
            VisitorObjStructure<T> objStructure = new VisitorObjStructure<T>();
            objStructure.Attach(new ConcreteVisitorComponentA<T>());
            objStructure.Attach(new ConcreteVisitorComponentB<T>());

            var Visitor = new ConcreteVisitor1<T>(DataObj);

            VisitorObjStructure<T>.Accept(Visitor);

            Result = Visitor.LayoutResult();

            objStructure.Detach(VisitorObjStructure<T>.components[0]);

            var Subvisitor = new ConcreteVisitor2<T>(DataObj);

            VisitorObjStructure<T>.Accept(Subvisitor);

            Result.Add(Subvisitor.LayoutResult()[0]);

            return Result;
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
        // ~VisitorServices() {
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
