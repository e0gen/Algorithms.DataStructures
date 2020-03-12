namespace DataStructures.BasicStructures
{
    public interface IBasicStack<T>
    {
        bool IsEmpty { get; }
        void Push(T item);
        T Pop();
        T Peek();
    }
}
