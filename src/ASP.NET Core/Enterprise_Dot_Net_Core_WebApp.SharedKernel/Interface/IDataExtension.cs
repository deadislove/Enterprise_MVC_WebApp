using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Enterprise_Dot_Net_Core_WebApp.SharedKernel.Interface
{
    public partial interface IDataExtension<T> where T : class
    {
        string ObjectIsNullOrEmpty(T value);

        DataTable ToDataTable(IEnumerable<T> collection);        

        void ToStrList(List<T> source, out List<string> returnObj);
    }

    public partial interface IDataExtension
    {
        byte[] ToByteArr(BitArray bits);

        object GetDynamicSortProperty(object item, string propName);

        Dictionary<string, object> GetDynamicObject(object obj);

        void GetObjectValue(object source, out Dictionary<string, object> ReturnObj);

        void ToDicList(object source, out List<KeyValuePair<string, object>> returnObj);
    }
}
