using System.Collections;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Iterator.AbstractIterator
{
    public abstract class AbstractIteratorAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }
}
