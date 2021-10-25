namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Iterator.AbstractIterator
{
    public class AbstractAlphabeticalOrderIterator<T> : AbstractIterator where T : class
    {
        private int _position = -1;
        private bool _reverse = false;
        private AbstractItemCollection<T> _collection;

        public AbstractAlphabeticalOrderIterator(AbstractItemCollection<T> collection, bool reverse = false)
        {
            _collection = collection;
            _reverse = reverse;

            if (reverse)
                _position = collection.GetItems().Count;
        }

        public override object Current()
        {
            return _collection.GetItems()[_position];
        }

        public override int Key()
        {
            return _position;
        }

        public override bool MoveNext()
        {
            int updatedPosition = _position + (_reverse ? -1 : 1);

            if (updatedPosition >= 0 && updatedPosition < this._collection.GetItems().Count)
            {
                _position = updatedPosition;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            _position = _reverse ? _collection.GetItems().Count - 1 : 0;
        }
    }
}
