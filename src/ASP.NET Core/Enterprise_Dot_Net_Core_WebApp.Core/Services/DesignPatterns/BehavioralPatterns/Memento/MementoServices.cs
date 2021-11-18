using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Memento;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Memento;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Interface;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Memento
{
    public class MementoServices<T> : IMementoServices<T>, IDisposable where T : class
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
        ~MementoServices()
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

        private IGenericTypeRepository<T> _repo;
        private IDataExtension _dataExenstion;
        private IDataExtension<T> _genericDataExtenstion;
        private IEnumerable<T> objList;
        private Originator<T> _originator;
        private Caretaker<T> _caretaker;

        public MementoServices() : base() { }

        public MementoServices(IGenericTypeRepository<T> repo)
        {
            _repo = repo;
            DataExtensionInitialization();

            if (!repo.Equals(null))
                DataAccess();
        }

        private void DataExtensionInitialization()
        {
            _dataExenstion = new DataExtensionDefault();
            _genericDataExtenstion = new DataExtension<T>();
        }

        private void DataAccess()
        {
            objList = _repo.GetAll().Result;
        }

        public void Operation(out Tuple<IEnumerable<string>, IEnumerable<string>> ResultList)
        {
            try
            {
                dynamic NewData = (dynamic)null;
                var StoreData = new List<string>();               

                if (objList.ToList().Count() == 0)
                {
     
                    ResultList = Tuple.Create(StoreData as IEnumerable<string>, StoreData as IEnumerable<string>);
                    return;
                }

                var Data = objList.Select(x => x).FirstOrDefault();
                _originator = new Originator<T>(Data, _dataExenstion);
                _caretaker = new Caretaker<T>(_originator);

                _caretaker.Backup();
                NewData = objList.Select(x => x).LastOrDefault();                
                _originator.TempSaveChange(NewData);

                _caretaker.Backup();
                NewData = (from data in objList
                           where _dataExenstion.GetDynamicSortProperty(data, "ID").Equals(2)
                           select data).ToList().FirstOrDefault();
                _originator.TempSaveChange(NewData);

                _caretaker.ShowHistory(out List<T> ReturnHisObj);

                _caretaker.Undo();

                _originator.Save();

                _originator.LayoutRecordHistory(out StoreData);

                _genericDataExtenstion.ToStrList(ReturnHisObj, out List<string> CaretakerHistory);

                ResultList =Tuple.Create(CaretakerHistory as IEnumerable<string>, StoreData as IEnumerable<string>);
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
    }
}
