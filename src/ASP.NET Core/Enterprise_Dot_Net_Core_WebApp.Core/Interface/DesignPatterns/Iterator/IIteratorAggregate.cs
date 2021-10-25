using System.Collections;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Iterator
{
    public interface IIteratorAggregate : IEnumerable
    {
        new IEnumerator GetEnumerator();
    }
}
