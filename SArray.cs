using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myers.Diff
{
    /// <summary>
    /// Sign Indexed Array, which accepts negative bounds
    /// </summary>
    class SArray<T> : IEnumerable<T>
    {
        T[] _items;
        int _lowerbound;
        public T this[int index]
        {
            get
            {
                int i = _lowerbound + index;
                return _items[i];
            }
            set
            {
                int i = _lowerbound + index;
                _items[i] = value;
            }
        }

        public SArray(int size, int lowerbound = 0)
        {
            _items = new T[size];
            _lowerbound = Math.Abs(lowerbound);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_items).GetEnumerator();
        }
    }
}
