using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Observer;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Observer
{
    public class ObserverServices : IObserverServices
    {
        private IGenericTypeRepository<Enterprise_MVC_Core> repo;
        private Enterprise_MVC_Core ObjInit;
        public ObserverServices(IGenericTypeRepository<Enterprise_MVC_Core> _repo)
        {
            repo = _repo;
            if(repo != null)
                DataInitialization();
        }

        #region Data Initialization
        private void DataInitialization()
        {
            ObjInit = repo.GetAll().Result.FirstOrDefault();
        }
        #endregion

        public void Operation(out List<string> HistoryMsgList)
        {
            try
            {
                var subject = (dynamic)null;
                if (ObjInit is null)
                    subject = new Subject();
                else
                    subject = new Subject(ObjInit);

                var Observer = new ConcreteObserver();

                Observer.Add($"Initialization data: {JsonConvert.SerializeObject(ObjInit)}");
                Observer.Add($"ConcreteObserver adds to Subject. {DateTime.Now.ToString()}");
                subject.Attach(Observer);

                Observer.Add($"Subject does the Notify operations. {DateTime.Now.ToString()}");
                subject.Notify();

                Observer.Add($"Reset the subject' object.");
                subject.Obj = repo.GetAll().Result.LastOrDefault();

                Observer.Add($"Subject does the Notify operations again. {DateTime.Now.ToString()}");
                subject.Notify();

                HistoryMsgList = Observer.LayoutHistory();

            }
            catch (Exception ex)
            {
                HistoryMsgList = new List<string>();
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
        // ~ObserverServices() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

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
