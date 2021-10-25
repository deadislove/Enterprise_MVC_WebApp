using System.Collections;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Iterator.AbstractIterator
{
    public class AbstractItemCollection<T> : AbstractIteratorAggregate where T : class
    {
        List<T> _collection = new List<T>();

        bool _direction = false;

        public void ReverseDirection()
        {
            _direction = !_direction;
        }

        public List<T> GetItems()
        {
            return _collection;
        }

        public void AddItem(T Item)
        {
            _collection.Add(Item);
        }

        public override IEnumerator GetEnumerator()
        {
            return new AbstractAlphabeticalOrderIterator<T>(this, _direction);
        }

        public static implicit operator List<T>(AbstractItemCollection<T> v)
        {
            List<T> obj = new List<T>();
            foreach (var item in v)
            {
                obj.Add(item as T);
            }

            return obj;
        }
    }
}
