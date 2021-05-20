using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Common
{
    public class ComFunc : IDisposable
    {
        #region Singleton pattern
        private ComFunc() { }
        private static ComFunc instance;
        private static readonly object padlock = new object();

        public static ComFunc GetInstance()
        {
            lock (padlock)
            {
                if (instance == null)
                    instance = new ComFunc();
                return instance;
            }
        }
        #endregion

        #region Checking object null or empty
        /// <summary>
        /// ObjectIsNullOrEmpty
        /// </summary>
        /// <param name="value">Object</param>
        /// <returns></returns>
        public string ObjectIsNullOrEmpty(object value)
        {
            var type = value.GetType();

            StringBuilder stringBuilder = new StringBuilder();
            PropertyInfo[] props = type.GetProperties();

            if (props.Length > 0)
            {
                foreach (var prop in props)
                {
                    if (string.IsNullOrEmpty(prop.GetValue(value).ToString()))
                    {
                        stringBuilder.AppendLine(string.Format("{0} can't empty", prop.Name));
                    }
                }
            }

            return stringBuilder.ToString();
        }
        #endregion

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
        // ~ComFunc() {
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
