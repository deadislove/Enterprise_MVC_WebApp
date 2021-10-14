using Enterprise_Dot_Net_Core_WebApp.Core.DTOs;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Command
{
    public class CommandAnotherExeServices : ICommandExe, IDisposable
    {
        private readonly RequestObj _reqObj;

        public CommandAnotherExeServices(RequestObj reqObj)
        {
            _reqObj = reqObj;
        }

        public Task<T> Execute<T>(object obj, object reqObj) where T : class
        {
            try
            {
                if (obj != null)
                {
                    DoAnotherThing(obj, out T DataItem);
                    return Task.FromResult(DataItem);
                }

                return null;
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

        private void DoAnotherThing<T>(object obj, out T returnObj) where T : class
        {
            try
            {
                returnObj = (from source in obj as List<T>
                             orderby GetDynamicSortProperty(source, "ID") descending
                             select source).FirstOrDefault();
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

        private object GetDynamicSortProperty(object item, string propName)
        {
            //Use reflection to get order type
            return item.GetType().GetProperty(propName).GetValue(item, null);
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
        // ~CommandAnotherExeServices() {
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
