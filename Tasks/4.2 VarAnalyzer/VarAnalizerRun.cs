using DataStructures.DisjointSets;
using System;
using System.Linq;

namespace Tasks._4._2_VarAnalyzer
{
    class VarAnalyzerRun
    {
        static void Main(string[] args)
        {
            var counts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var varCount = counts[0];
            var equalsCount = counts[1];
            var unEqualsCount = counts[2];

            var analyzer = new DisjointSetUnion(varCount);

            for (int i = 0; i < varCount; i++)
            {
                analyzer.MakeSet(i);
            }

            for (int i = 0; i < equalsCount; i++)
            {
                var equalPair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                analyzer.Union(equalPair[0] - 1, equalPair[1] - 1);
            }

            for (int i = equalsCount; i < equalsCount + unEqualsCount; i++)
            {
                var unEqualPair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (analyzer.Find(unEqualPair[0] - 1) == analyzer.Find(unEqualPair[1] - 1))
                {
                    Console.WriteLine("0");
                    return;
                }
            }
            Console.WriteLine("1");
            Console.ReadKey();
        }
    }
}
