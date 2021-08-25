using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.ChainOfResponsibility
{
    public class IDHandler<T> : AbstractHandler, IDisposable where T : class
    {
        public string Sequence { get; set; }

        public override object Handle(object request)
        {
            try
            {
                List<T> data_sorted = new List<T>();

                if (Sequence.ToString() == "ASC")
                {
                    data_sorted = (from source in request as List<T>
                                   orderby GetDynamicSortProperty(source, "ID") ascending
                                   select source
                                       ).ToList();
                    return data_sorted;
                }
                else if (Sequence.ToString() == "DESC")
                {
                    data_sorted = (from source in request as List<T>
                                   orderby GetDynamicSortProperty(source, "ID") descending
                                   select source
                                       ).ToList();

                    return data_sorted;
                }
                else
                    return base.Handle(request);
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
        // ~IDHandler() {
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
