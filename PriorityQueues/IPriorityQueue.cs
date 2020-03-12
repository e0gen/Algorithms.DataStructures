using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueues
{
    public interface IPriorityQueue<T>
    {
        void Enqueue(T p);
        void Remove(int i);
        T Dequeue();
        T Peek();
        void ChangePriority(int i, T p);
    }
}
