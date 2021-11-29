using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.NullObject
{
    public sealed class IsNullObject<T> : BaseClass<T> where T : class
    {
        private object[] ObjectArr { get; set; } = new object[] { };

        public IsNullObject(object[] _ObjectArr)
        {
            ObjectArr = _ObjectArr;
        }

        public override T Instance => (T)Activator.CreateInstance(typeof(T), ObjectArr);
    }
}
