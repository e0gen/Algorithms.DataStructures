using System;
using System.Linq;
using DataStructures.BasicStructures;

namespace Tasks._2._2_TreeHeight
{
    class TreeHeightRun
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var tree = new Tree(data);

            Console.WriteLine(tree.Height);
            Console.ReadKey();
        }
    }
}
