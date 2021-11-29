using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.NullObject
{
    /// <summary>
    /// Generic tpye and the class constructor mechanism
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseClass<T> where T : class
    {
        public virtual T Instance { get; set; }
    }
}
