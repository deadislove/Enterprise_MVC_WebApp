using Enterprise_Dot_Net_Core_WebApp.Core.DTOs;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Command
{
    public class CommandExeServices : ICommandExe, IDisposable
    {
        private RequestObj _reqObj;

        public CommandExeServices(RequestObj reqObj)
        {
            _reqObj = reqObj;
        }

        public Task<T> Execute<T>(object obj, object reqObj) where T : class
        {
            try
            {
                dynamic item = (dynamic)null;

                switch (_reqObj)
                {
                    case null:
                        item = reqObj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                .ToDictionary(prop => prop.Name, prop => prop.GetValue(reqObj, null));
                        break;
                    default:
                        item = _reqObj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                .ToDictionary(prop => prop.Name, prop => prop.GetValue(reqObj, null));
                        break;
                }

                if (obj != null)
                {
                    DoSomething<T>(item, obj, out List<T> returnObj);
                    return Task.FromResult(returnObj.FirstOrDefault());
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

        private void DoSomething<T>(Dictionary<string, object> item, object obj, out List<T> returnObj) where T: class
        {
            try
            {
                returnObj = (from source in obj as List<T>
                             where GetDynamicSortProperty(source, "ID").Equals(item["ID"])
                             select source).ToList();
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
        // ~CommandExeServices() {
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
