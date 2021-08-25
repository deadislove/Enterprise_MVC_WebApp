using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

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

        #region Common checking object function for Enterprise_MVC_Core class object
        public void CheckObject(Enterprise_MVC_Core obj)
        {
            PropertyInfo[] propertyInfos;
            propertyInfos = typeof(Enterprise_MVC_Core).GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                //propertyInfo.Name;
                //propertyInfo.GetValue(obj).ToString();
            }
        }
        #endregion

        #region Convert List to DataTable
        /// <summary>
        /// Convert List to DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());

            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }
        #endregion

        #region Convert List<object> to List<KeyValuePair<string, object>>
        /// <summary>
        /// Convert List<object> to List<KeyValuePair<string, object>>
        /// </summary>
        /// <param name="source">List<object></param>
        /// <param name="returnObj"></param>
        public void ToDicList(List<object> source, out List<KeyValuePair<string, object>> returnObj)
        {
            try
            {
                returnObj = source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .ToDictionary(prop => prop.Name, prop => prop.GetValue(source, null)).ToList();
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
