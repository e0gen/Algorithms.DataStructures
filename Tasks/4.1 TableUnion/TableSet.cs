using DataStructures.DisjointSets;

namespace Tasks._4._1_TableUnion
{
    public class TableSet
    {
        private Table[] _data;
        private DisjointSetUnion _dsu;

        public int MaxValue { get; private set; }

        public TableSet(Table[] data)
        {
            _dsu = new DisjointSetUnion(data.Length);
            _data = data;

            for (int i = 0; i < data.Length; i++)
            {
                _dsu.MakeSet(i);
                UpdateMax(_data[i].RowsCount);
            }
        }

        private void UpdateMax(int value)
        {
            if (MaxValue < value)
                MaxValue = value;
        }
        public void Union(int x, int y)
        {
            var x_id = _dsu.Find(x);
            var y_id = _dsu.Find(y);
            if (x_id == y_id) return;

            _dsu.Union(x, y);

            if (x_id == _dsu.Find(x))
            {
                _data[x_id].RowsCount += _data[y_id].RowsCount;
                _data[y_id].RowsCount = 0;
                UpdateMax(_data[x_id].RowsCount);
            }
            else
            {
                _data[y_id].RowsCount += _data[x_id].RowsCount;
                _data[x_id].RowsCount = 0;
                UpdateMax(_data[y_id].RowsCount);
            }
        }
    }
}
