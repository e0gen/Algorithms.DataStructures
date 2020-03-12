using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.BasicStructures
{
    //One way enumerable linked list implementation
    public class OneWayList<T> : IEnumerable<T>
    {
        public int Count { get; private set; }
        public OneWayListNode<T>? Head { get; private set; }
        public OneWayListNode<T>? Tail { get; private set; }

        public OneWayList()
        {
        }

        public OneWayList(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            foreach (T item in array)
            {
                InsertLast(item);
            }
        }
        public void InsertFirst(T item)
        {
            if (Head == null)
                InternalInsertToEmptyList(item);
            else
                InternalInsertBeforeHead(item);
        }

        public void InsertLast(T item)
        {
            if(Tail == null)
                InternalInsertToEmptyList(item);
            else
                InternalInsertAfterNode(Tail, item);
        }

        public void InsertAfter(OneWayListNode<T> node, T item)
        {
            ValidateNode(node);
            InternalInsertAfterNode(node, item);
        }

        public void DeleteFirst()
        {
            if (Head == null)
                throw new InvalidOperationException();
            InternalRemoveNode(Head);
        }
        public void DeleteLast()
        {
            if (Tail == null)
                throw new InvalidOperationException();
            InternalRemoveNode(Tail);
        }

        public void Delete(OneWayListNode<T> node)
        {
            ValidateNode(node);
            InternalRemoveNode(node);
        }

        private void InternalInsertToEmptyList(T item)
        {
            Head = Tail = new OneWayListNode<T>(this, item);
            Count++;
        }
        private void InternalInsertAfterNode(OneWayListNode<T> node, T item)
        {
            var newNode = new OneWayListNode<T>(this, item);
            if (node == Tail)
            {
                //newNode.Next = newNode;
                Tail = newNode;
                
            }
            else //if (node.Next != node)
            {
                newNode.Next = node.Next;
            }
            node.Next = newNode;
            Count++;
        }

        private void InternalInsertBeforeHead(T item)
        {
            var newNode = new OneWayListNode<T>(this, item);
            newNode.Next = Head;
            Head = newNode;
            Count++;
        }

        internal OneWayListNode<T>? InternalFindPreviousNode(OneWayListNode<T> node)
        {
            if (Head == null) return null;

            var current = Head;
            while (current != null)
            {
                if (current.Next == node)
                    return current;

                current = current.Next;
            }
            return current;
        }

        internal void InternalRemoveNode(OneWayListNode<T> node)
        {
            if (node == Head)
                if (node == Tail)
                    Head = Tail = null;
                else
                    Head = Head.Next;
            else
            {
                var prev = InternalFindPreviousNode(node);
                if (node == Tail)
                {
                    prev!.Next = null;
                    Tail = prev;
                }
                else
                {
                    prev!.Next = node.Next;
                }
            }
            node.Invalidate();
            Count--;
        }

        internal void ValidateNode(OneWayListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            if (node.List != this)
            {
                throw new InvalidOperationException();
            }
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>
        {
            private T _current;
            private readonly OneWayList<T> _list;
            private OneWayListNode<T>? _node;
            private int _index;
            public Enumerator(OneWayList<T> list)
            {
                _list = list;
                _node = list.Head;
                _current = default;
                _index = 0;
            }
            public T Current => _current;

            object? IEnumerator.Current
            {
                get
                {
                    if (_index == 0 || (_index == _list.Count + 1))
                    {
                        throw new InvalidOperationException();
                    }

                    return Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_node == null)
                {
                    _index = _list.Count + 1;
                    return false;
                }

                ++_index;
                _current = _node.Value;
                if (_node == _node.Next)
                    _node = null;
                else
                    _node = _node.Next;
                return true;
            }

            public void Reset()
            {
                _current = default;
                _node = _list.Head;
                _index = 0;
            }
        }
    }

    public class OneWayListNode<T>
    {
        public OneWayList<T>? List { get; private set; }
        public OneWayListNode<T>? Next { get; set; }
        public T Value { get; set; }
        public OneWayListNode(OneWayList<T> list, T value)
        {
            List = list;
            Value = value;
        }

        internal void Invalidate()
        {
            List = null;
            Next = null;
        }
    }
}
