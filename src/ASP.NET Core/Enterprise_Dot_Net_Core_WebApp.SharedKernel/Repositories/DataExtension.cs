using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Enterprise_Dot_Net_Core_WebApp.SharedKernel.Repositories
{
    /// <summary>
    /// Generic type class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataExtension<T> : IDataExtension<T>, IDisposable where T : class
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
        // ~DataExtension() {
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

        #region Checking object null or empty
        /// <summary>
        /// Checking object null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ObjectIsNullOrEmpty(T value)
        {
            if (value is null)
                return string.Empty;

            GenericDataExtension<T>.ObjectIsNullOrEmpty(value, out string ReturnStr);

            if (string.IsNullOrEmpty(ReturnStr))
                return $"Success";
            return ReturnStr;
        }
        #endregion
        
        #region Convert List to DataTable
        /// <summary>
        /// Convert List to DataTable
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public DataTable ToDataTable(IEnumerable<T> collection)
        {
            if (collection.Count() == 0)
                return new DataTable();

            return GenericDataExtension<T>.ToDataTable(collection);
        }
        #endregion

        #region Convert List<T> to List<string>
        /// <summary>
        /// Convert List<T> to List<string>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="returnObj"></param>
        public void ToStrList(List<T> source, out List<string> returnObj)
        {
            try
            {
                if (source is null)
                    returnObj = new List<string>();

                GenericDataExtension<T>.ToStrList(source, out returnObj);
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
    }

    /// <summary>
    /// Common class
    /// </summary>
    public class DataExtensionDefault : DataException, IDataExtension, IDisposable
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
        ~DataExtensionDefault()
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

        #region Convert Bit Array to Byte Array
        /// <summary>
        /// Convert Bit Array to Byte Array
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public byte[] ToByteArr(BitArray bits)
        {
            if (bits.Count == 0)
                return null;

            return DataExtension.ToByteArr(bits);
        }
        #endregion

        #region Get dynamic sort property
        /// <summary>
        /// Get dynamic sort property
        /// </summary>
        /// <param name="item"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        public object GetDynamicSortProperty(object item, string propName)
        {
            try
            {
                if (item is null)
                    return null;
                if (string.IsNullOrEmpty(propName))
                    return null;

                return DataExtension.GetDynamicSortProperty(item, propName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Convert dynamic object to dictionary object
        /// <summary>
        /// Convert dynamic object to dictionary object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetDynamicObject(object obj)
        {
            try
            {
                return DataExtension.GetDynamicObject(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get object value
        /// <summary>
        /// Get object value
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ReturnObj"></param>
        public void GetObjectValue(object source, out Dictionary<string, object> ReturnObj)
        {
            try
            {
                if (source is null)
                    ReturnObj = new Dictionary<string, object>();

                DataExtension.GetObjectValue(source, out ReturnObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Convert object to List<KeyValuePair<string, object>>
        /// <summary>
        /// Convert object to List<KeyValuePair<string, object>>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="returnObj"></param>
        public void ToDicList(object source, out List<KeyValuePair<string, object>> returnObj)
        {
            if (source is null)
                returnObj = null;

            DataExtension.ToDicList(source, out returnObj);
        }
        #endregion
    }

    internal static class DataExtension 
    {
        #region Convert dynamic object to dictionary object
        /// <summary>
        /// Convert dynamic object to dictionary object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetDynamicObject(object obj)
        {
            return obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj, null));
        }
        #endregion

        #region Get dynamic sort property
        /// <summary>
        /// Get dynamic sort property
        /// </summary>
        /// <param name="item"></param>
        /// <param name="propName"></param>
        /// <returns></returns>
        public static object GetDynamicSortProperty(object item, string propName)
        {
            return item.GetType().GetProperty(propName).GetValue(item, null);
        }
        #endregion
        
        #region Convert Bit Array to Byte Array
        /// <summary>
        /// Convert Bit Array to Byte Array (Method 1)
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public static byte[] ToByteArr(BitArray bits)
        {
            const int BYTE = 8;
            int length = (bits.Count / BYTE) + ((bits.Count % BYTE == 0) ? 0 : 1);
            var bytes = new byte[length];

            for (int i = 0; i < bits.Length; i++)
            {

                int bitIndex = i % BYTE;
                int byteIndex = i / BYTE;

                int mask = (bits[i] ? 1 : 0) << bitIndex;
                bytes[byteIndex] |= (byte)mask;

            }

            return bytes;
        }

        /// <summary>
        /// Convert Bit Array to Byte Array (Method 2)
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }
        #endregion
        
        #region Get Object value
        /// <summary>
        /// Get object value
        /// </summary>
        /// <param name="source"></param>
        /// <param name="ReturnObj"></param>
        public static void GetObjectValue(object source, out Dictionary<string, object> ReturnObj)
        {
            if(source is null)
                ReturnObj = new Dictionary<string, object>();

            ReturnObj = source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                .ToDictionary(prop => prop.Name, prop => prop.GetValue(source, null));
        }
        #endregion

        #region Convert object to List<KeyValuePair<string, object>>
        /// <summary>
        /// Convert object to List<KeyValuePair<string, object>>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="returnObj"></param>
        public static void ToDicList(object source, out List<KeyValuePair<string, object>> returnObj)
        {
            var ReturnObj = new List<KeyValuePair<string, object>>();

            if (source is null)
                returnObj = ReturnObj;

            returnObj = source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .ToDictionary(prop => prop.Name, prop => prop.GetValue(source)).ToList();
        }
        #endregion
    }

    internal static class GenericDataExtension<T> where T : class
    {
        #region Convert List to DataTable
        /// <summary>
        /// Convert List to DataTable
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(IEnumerable<T> collection)
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

        #region Convert List<T> to List<string>
        /// <summary>
        /// Convert List<T> to List<string>
        /// </summary>        
        /// <param name="source"></param>
        /// <param name="returnObj"></param>
        public static void ToStrList(List<T> source, out List<string> returnObj)
        {
            var Result = new List<string>();

            if (source is null)
            {
                returnObj = Result;
                return;
            }

            source.ForEach(Data => {
                var tmp = Data.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .ToDictionary(prop => prop.Name, prop => prop.GetValue(Data, null)).ToList();
                Result.Add(string.Join(", ", tmp));
            });

            if (Result.Count != 0)
                returnObj = Result;
            else
                returnObj = new List<string>();

        }
        #endregion

        #region Checking object null or empty
        /// <summary>
        /// Checking object null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ReturnStr"></param>
        public static void ObjectIsNullOrEmpty(T value, out string ReturnStr)
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

            ReturnStr = stringBuilder.ToString();
        }
        #endregion
                
    }
}
