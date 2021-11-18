using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.ChainOfResponsibility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.ChainOfResponsibility
{
    public class HandlerService : ICofR, IDisposable
    {
        private List<Enterprise_MVC_Core> DataList;

        private IGenericTypeRepository<Enterprise_MVC_Core> _repo;

        public HandlerService(IGenericTypeRepository<Enterprise_MVC_Core> repo)
        {
            _repo = repo;
            DataAccess();
        }

        #region DataAccess
        private void DataAccess()
        {
            DataList = _repo.GetAll().Result.ToList();
        }
        #endregion

        public void CofR(string Sequence, out List<Enterprise_MVC_Core> returnObj)
        {
            try
            {                
                var IdHandler = new IDHandler<Enterprise_MVC_Core>
                {
                    Sequence = Sequence
                };
                returnObj = IdHandler.Handle(DataList as List<Enterprise_MVC_Core>) as List<Enterprise_MVC_Core>;
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

        public void CofRByID(List<int> request, out List<Enterprise_MVC_Core> returnObj)
        {
            try
            {
                var findHandler = new FindHandler<Enterprise_MVC_Core>
                {
                    Sequence = request
                };

                returnObj = findHandler.Handle(DataList) as List<Enterprise_MVC_Core>;

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
        ~HandlerService()
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
