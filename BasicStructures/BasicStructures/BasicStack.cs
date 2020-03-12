using System;

namespace DataStructures.BasicStructures
{
    public class BasicStack<T> : IBasicStack<T>
    {
        private T[] _array;
        private int _size;

        private const int DefaultCapacity = 4;

        public BasicStack()
        {
            _array = Array.Empty<T>();
        }

        public BasicStack(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            _array = new T[capacity];
        }

        public BasicStack(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            _array = new T[array.Length];
            _size = array.Length;
            Array.Copy(array, 0, _array, 0, array.Length);
        }

        public int Count
        {
            get { return _size; }
        }
        public bool IsEmpty => _size == 0;

        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException();

            return _array[_size - 1];
        }

        public T Pop()
        {
            if (_size == 0)
                throw new InvalidOperationException();

            var value = _array[_size - 1];
            _size--;

            return value;
        }

        public void Push(T item)
        {
            if (_size >= _array.Length)
                ExtendCapacity();

            _array[_size] = item;
            _size++;
        }

        private void ExtendCapacity()
        {
            Array.Resize(ref _array, _array.Length == 0 ? DefaultCapacity : _array.Length * 2);
        }
    }
}
