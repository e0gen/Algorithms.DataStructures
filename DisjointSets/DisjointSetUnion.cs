namespace DisjointSets
{
    //Disjoint Set with Union by rank implementation with path compression
    public class DisjointSetUnion : IDisjointSetUnion
    {
        public DisjointSetUnion(int size)
        {
            _parent = new int[size];
            _rank = new int[size];
        }

        private int[] _parent;
        private int[] _rank;


        public void MakeSet(int x)
        {
            _parent[x] = x;
            _rank[x] = 0;
        }
        public int Find(int x)
        {
            if (x != _parent[x])
                _parent[x] = Find(_parent[x]);
            return _parent[x];
        }
        public void Union(int x, int y)
        {
            var x_id = Find(x);
            var y_id = Find(y);
            if (x_id == y_id) return;
            if (_rank[x_id] > _rank[y_id])
            {
                _parent[y_id] = x_id;
            }
            else
            {
                _parent[x_id] = y_id;

                if (_rank[x_id] == _rank[y_id])
                    _rank[y_id]++;
            }
        }
    }
}
