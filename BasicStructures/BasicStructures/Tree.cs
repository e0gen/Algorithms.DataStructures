using System;
namespace DataStructures.BasicStructures
{
    public class Tree
    {
        private readonly int[] _buffer;

        public Tree(int[] array)
        {
            _buffer = array;
        }

        public int Height
        {
            get
            {
                int maxHeight = 1;
                int currentHeight;
                foreach (var parent in _buffer)
                {
                    currentHeight = GetHeight(parent, _buffer);
                    maxHeight = Math.Max(maxHeight, currentHeight);
                }
                return maxHeight;
            }
        }

        private int GetHeight(int parent, int[] tree)
        {
            int height = 1;
            if (parent != -1)
                height = Math.Max(height, 1 + GetHeight(tree[parent], tree));

            return height;
        }
    }
}
