using System.Collections;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Iterator
{
    public interface IIterator : IEnumerator
    {
        int Key();

        object Current();

        bool MoveNext();

        void Reset();
    }
}
