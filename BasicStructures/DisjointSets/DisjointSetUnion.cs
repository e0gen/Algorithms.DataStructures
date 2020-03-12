namespace DataStructures.DisjointSets
{
    //Disjoint Set with Union by rank implementation with path compression
    public class DisjointSetUnion : IDisjointSetUnion
    {
        public DisjointSetUnion(int size)
        {
            _parent = new int[size];
            _rank = new int[size];
        }

        private readonly int[] _parent;
        private readonly int[] _rank;


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
            var xId = Find(x);
            var yId = Find(y);
            if (xId == yId) return;
            if (_rank[xId] > _rank[yId])
            {
                _parent[yId] = xId;
            }
            else
            {
                _parent[xId] = yId;

                if (_rank[xId] == _rank[yId])
                    _rank[yId]++;
            }
        }
    }
}
