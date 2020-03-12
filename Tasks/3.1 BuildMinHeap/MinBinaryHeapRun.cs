using System;
using System.Linq;
using DataStructures.PriorityQueues;

namespace Tasks._3._1_BuildMinHeap
{
    class MinBinaryHeapRun
    {
        static void Main(string[] args)
        {
            int heapCount = int.Parse(Console.ReadLine());
            var array = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var mbh = new MinBinaryHeap<int>(array);

            Console.WriteLine(mbh.Log.Count);
            foreach (var msg in mbh.Log)
                Console.WriteLine(msg);

            Console.ReadKey();
        }
    }
}
