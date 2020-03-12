using System;
using System.Collections.Generic;

namespace PriorityQueues
{
    public class MinBinaryHeap<T> : IPriorityQueue<T>  where T : IComparable<T>, new()
    {
        public readonly IList<string> Log;
        public int Size { get; private set; }
        public int MaxSize { get; }

        private readonly T[] _buffer;

        public MinBinaryHeap(int maxSize = 16, IList<string> log = null)
        {
            Log = log;
            MaxSize = maxSize;
            Size = 0;
            _buffer = new T[maxSize];
        }

        public MinBinaryHeap(T[] array, IList<string> log = null)
        {
            Log = log;
            MaxSize = array.Length;
            Size = array.Length;
            _buffer = array;

            BuildHeap(_buffer, Size, Log);
        }

        private static void BuildHeap(T[] array, int size, IList<string> log = null)
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
                SiftDown(i, array, size, log);
        }

        // Descending for min-heap
        public static void HeapSort(T[] array, int size) 
        {
            BuildHeap(array, size);
            for (int i = 0; i < array.Length - 1; i++)
            {
                Swap(ref array[0], ref array[size - 1]);
                size = size - 1;
                SiftDown(0, array, size);
            }
        }

        private static int Parent(int i) => (i - 1) / 2;
        private static int LeftChild(int i) => 2*i + 1;
        private static int RightChild(int i) => 2 * i + 2;

        private static void Swap(ref T a, ref T b)
        {
            T x = a;
            a = b;
            b = x;
        }
        private static void SiftUp(int i, T[] array, IList<string> log = null)
        {
            while (i > 0 && array[Parent(i)].CompareTo(array[i]) > 0)
            {
                log?.Add($"{Parent(i)} {i}");
                Swap(ref array[Parent(i)], ref array[i]);
                i = Parent(i);
            }
        }
        private static void SiftDown(int i, T[] array, int size, IList<string> log = null)
        {
            var minIndex = i;

            var l = LeftChild(i);
            if (l < size)
                if(array[l].CompareTo(array[minIndex]) < 0)
                    minIndex = l;

            var r = RightChild(i);
            if (r < size)
                if (array[r].CompareTo(array[minIndex]) < 0)
                    minIndex = r;

            if (i != minIndex)
            {
                log?.Add($"{i} {minIndex}");
                Swap(ref array[i], ref array[minIndex]);
                SiftDown(minIndex, array, size, log);
            }
        }
        public T Peek()
        {
            if (Size == 0)
                throw new InvalidOperationException();

            return _buffer[0];
        }

        public void Enqueue(T p)
        {
            if (Size == MaxSize)
                throw new InvalidOperationException();

            Size++;
            _buffer[Size - 1] = p;
            SiftUp(Size - 1, _buffer);
        }
        public T Dequeue()
        {
            if (Size == 0)
                throw new InvalidOperationException();

            var result = _buffer[0];
            _buffer[0] = _buffer[Size - 1];
            Size--;
            SiftDown(0, _buffer, Size);
            return result;
        }

        public void Remove(int i)
        {
            _buffer[i] = default;
            SiftUp(i, _buffer);
            Dequeue();
        }

        public void ChangePriority(int i, T p)
        {
            var oldP = _buffer[i];
            _buffer[i] = p;

            if (p.CompareTo(oldP) > 0)
                SiftDown(i, _buffer, Size);
            else
                SiftUp(i, _buffer);
        }
    }
}
