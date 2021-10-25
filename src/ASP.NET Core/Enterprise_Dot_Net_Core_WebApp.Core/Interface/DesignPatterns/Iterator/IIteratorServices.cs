using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Iterator
{
    public interface IIteratorServices<T> where T : class
    {
        IEnumerable<T> IteratorDefault();
        IEnumerable<T> IteratorOperation();
        IEnumerable<T> AbstractIteratorDefault();
        IEnumerable<T> AbstractIteratorOperation();
    }
}
