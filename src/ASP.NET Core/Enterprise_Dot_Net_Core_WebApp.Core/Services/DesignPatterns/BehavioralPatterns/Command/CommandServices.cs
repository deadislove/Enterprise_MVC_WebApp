using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Command;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Command
{
    public class CommandServices<T1, T2> : ICommand<T1, T2>, IDisposable where T1 : class where T2 : class
    {
        private object _obj;

        private IGenericTypeRepository<T2> _repo;
        private ICommandExe _commandExe;
        private ICommandExe _OncommandExeStart;
        private ICommandExe _OncommandExeFinish;
                
        public CommandServices(IGenericTypeRepository<T2> repo)
        {
            _repo = repo;
            DataAccess();
            ServiceInitialization();
        }

        private void DataAccess()
        {
            _obj = _repo.AsyncGetAll().Result;            
        }

        private void ServiceInitialization()
        {
            _commandExe = new CommandExeServices(null);
            SetOnStart(_commandExe);
            SetOnFinish(_commandExe);
        }

        public void SetOnStart(ICommandExe commandExe) => _OncommandExeStart = commandExe;

        public void SetOnFinish(ICommandExe commandExe) => _OncommandExeFinish = commandExe;        

        public async Task<List<T>> ExecuteResult<T>(T1 requestObj = null)
        {
            try
            {
                List<T> retunObj = new List<T>();
                dynamic ObjItem = (dynamic)null;

                if (requestObj != null)
                {
                    if (_OncommandExeStart is ICommandExe)
                    {
                        ObjItem = _OncommandExeStart.Execute<T2>(_obj, requestObj).Result;
                        retunObj.Add(ObjItem);
                    }

                    if (_OncommandExeFinish is ICommandExe)
                    {
                        ObjItem = _OncommandExeFinish.Execute<T2>(_obj, null).Result;
                        retunObj.Add(ObjItem);
                    }
                }

                return retunObj;
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
        // ~CommandServices() {
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
