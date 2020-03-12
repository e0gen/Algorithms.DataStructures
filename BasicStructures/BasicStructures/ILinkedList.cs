namespace DataStructures.BasicStructures
{
    public interface ILinkedList<T>
    {
        void InsertFirst(T item);
        void InsertLast(T item);
        void InsertAfter(T item);
        void InsertBefore(T item);
        void DeleteFirst();
        void DeleteLast();
    }

    public interface ILinkedListNode<T>
    {
        ILinkedListNode<T> Next();
        ILinkedListNode<T> Previous();
        T Value { get; set; }
    }

}
