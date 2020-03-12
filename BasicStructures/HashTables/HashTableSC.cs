using System.Text;
using DataStructures.BasicStructures;

namespace DataStructures.HashTables
{
    //Separate chaining with linked lists
    public class HashTableSc
    {
        private readonly OneWayList<string>[] _entries;
        private readonly int _modulo;
        private readonly int _prime;

        public HashTableSc(int size)
        {
            _entries = new OneWayList<string>[size];
            _modulo = size;
            _prime = 1_000_000_007;
        }
        public int GetHashCode(string entry)
        {
            long result = 0;
            long x = 1;
            foreach (var c in entry)
            {
                result = (result + c * x) % _prime;
                x = (x * 263) % _prime;
            }

            return (int)(result % _modulo);
        }

        private bool PrivateFind(string entry, out int hash, out OneWayListNode<string> node)
        {
            hash = GetHashCode(entry);
            var list = _entries[hash];
            if (list != null)
            {
                var current = list.Head;
                while (current != null)
                {
                    if (current.Value.Equals(entry))
                    {
                        node = current;
                        return true;
                    }
                    current = current.Next;
                }
            }
            node = null;
            return false;
        }

        public void Add(string entry)
        {
            if (PrivateFind(entry, out var hash, out _))
                return;

            var list = _entries[hash] ?? new OneWayList<string>();
            list.InsertFirst(entry);
            _entries[hash] = list;
        }

        public string Find(string entry)
        {
            if (PrivateFind(entry, out _, out _))
                return "yes";
            return "no";
        }

        public void Delete(string entry)
        {
            if (!PrivateFind(entry, out var hash, out var node))
                return;

            _entries[hash].Delete(node);
        }

        public string Check(int hash)
        {
            StringBuilder sb = new StringBuilder();

            var list = _entries[hash];
            if (list != null)
            {
                var current = list.Head;
                if (current != null)
                {
                    sb.Append(current.Value);
                    current = current.Next;
                }

                while (current != null)
                {
                    sb.Append(" " + current.Value);
                    current = current.Next;
                }
            }
            return sb.ToString();
        }
    }
}
