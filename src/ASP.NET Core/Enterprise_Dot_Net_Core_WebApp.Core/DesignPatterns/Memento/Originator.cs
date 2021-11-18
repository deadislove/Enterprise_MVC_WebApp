using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Memento;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Memento
{
    public class Originator<T> : IDisposable where T : class
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
        ~Originator()
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

        private T _State;
        private List<string> RecordHistoryList = new List<string>();
        private IDataExtension _DataExtension;

        public Originator(T State, IDataExtension DataExtension)
        {
            _State = State;
            _DataExtension = DataExtension;
            Log(string.Format("Initial state: {0}", string.Join(",", _DataExtension.GetDynamicObject(_State).ToList())));
        }

        private void Log(string Msg) => RecordHistoryList.Add(Msg);

        public void TempSaveChange(T NewObj)
        {
            if (NewObj is null)
                Log("Add new state is null.");

            Log(string.Format("Add new state: {0}", string.Join(",", _DataExtension.GetDynamicObject(NewObj).ToList())));

            _State = NewObj;

            Log(string.Format("Current state: {0}", string.Join(",", _DataExtension.GetDynamicObject(_State).ToList())));

        }

        public IMemento<T> Save() => new ConcreteMemento<T>(_State);

        public void Restore(IMemento<T> memento)
        {
            if (!(memento is ConcreteMemento<T>))
                throw new Exception("Unknow memoto class " + memento.ToString());

            _State = memento.ObjectStatus();
            Log(string.Format("Originator changes the state(Restore). Current state: {0}", string.Join(",", _DataExtension.GetDynamicObject(_State).ToList())));
        }

        public T Layout() => _State;

        public void LayoutRecordHistory(out List<string> returnObj) => returnObj = RecordHistoryList;
        
    }
}
