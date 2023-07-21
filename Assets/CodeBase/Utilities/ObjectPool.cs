using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBase.Utilities
{
    public class ObjectPool<T> : IDisposable where T : class
    {
        private readonly List<T> _list;
        private readonly Func<T> _create;
        private readonly Action<T> _get;
        private readonly Action<T> _release;
        private readonly Action<T> _destroy;
        private readonly int _maxSize;
        private readonly bool _collectionCheck;

        public int CountAll { get; private set; }

        public int CountActive => CountAll - CountInactive;

        public int CountInactive => _list.Count;

        public ObjectPool(
            Func<T> createFunc,
            Action<T> get = null,
            Action<T> release = null,
            Action<T> destroy = null,
            bool collectionCheck = true,
            int defaultCapacity = 10,
            int maxSize = 10000)
        {
            if (maxSize <= 0)
                throw new ArgumentException("Max Size must be greater than 0", nameof(maxSize));
            _list = new List<T>(defaultCapacity);
            _create = createFunc ?? throw new ArgumentNullException(nameof(createFunc));
            _maxSize = maxSize;
            _get = get;
            _release = release;
            _destroy = destroy;
            _collectionCheck = collectionCheck;
        }

        public T Get()
        {
            T obj;
            if (_list.Count == 0)
            {
                obj = _create();
                ++CountAll;
            }
            else
            {
                var index = _list.Count - 1;
                obj = _list[index];
                _list.RemoveAt(index);
            }

            _get?.Invoke(obj);
            return obj;
        }

        public T Get(Predicate<T> predicate)
        {
            T obj;
            if (_list.Count == 0)
            {
                obj = _create();
                ++CountAll;
            }
            else
            {
                var index = _list.FindIndex(predicate);
                var isFound = index != -1;
                if (isFound)
                {
                    obj = _list[index];
                    _list.RemoveAt(index);
                }
                else
                {
                    obj = _create();
                    ++CountAll;
                }
            }

            _get?.Invoke(obj);
            return obj;
        }

        public void Release(T element)
        {
            if (_collectionCheck && _list.Count > 0)
            {
                if (_list.Any(t => element == t))
                {
                    throw new InvalidOperationException(
                        "Trying to release an object that has already been released to the pool.");
                }
            }

            _release?.Invoke(element);
            if (CountInactive < _maxSize)
            {
                _list.Add(element);
            }
            else
            {
                _destroy?.Invoke(element);
            }
        }

        public void Clear()
        {
            if (_destroy != null)
            {
                foreach (var obj in _list)
                    _destroy(obj);
            }

            _list.Clear();
            CountAll = 0;
        }

        public void Dispose() => Clear();
    }
}