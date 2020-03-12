using System;

namespace DataStructures.BasicStructures
{
    public class StackMax<T> : IBasicStack<T> where T : IComparable
    {
        private readonly BasicStack<T> _stack;
        private readonly BasicStack<T> _stackMax;

        public bool IsEmpty => _stack.IsEmpty;

        public StackMax()
        {
            _stack = new BasicStack<T>();
            _stackMax = new BasicStack<T>();
        }
        public void Push(T item)
        {
            var max = item;
            if(!_stackMax.IsEmpty)
            {
                var lastMax = _stackMax.Peek();
                if (max.CompareTo(lastMax) < 0) max = lastMax; //max < lastMax
            }

            _stack.Push(item);
            _stackMax.Push(max);
        }
        public T Pop()
        {
            _stackMax.Pop();
            return _stack.Pop();
        }

        public T Peek()
        {
            return _stack.Peek();
        }

        public T Max()
        {
            return _stackMax.Peek();
        }
    }
}
