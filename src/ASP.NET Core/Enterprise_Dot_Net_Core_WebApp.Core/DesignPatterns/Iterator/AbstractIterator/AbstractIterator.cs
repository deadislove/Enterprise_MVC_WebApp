using System.Collections;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Iterator.AbstractIterator
{
    public abstract class AbstractIterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        public abstract object Current();

        public abstract int Key();

        public abstract bool MoveNext();
        public abstract void Reset();
    }
}
