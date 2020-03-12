using System;
using System.Linq;

namespace Tasks._3._2_Processor
{
    class ProcessorRun
    {
        static void Main(string[] args)
        {
            var limits = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            var tasks = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var coresCount = limits[0];
            var inputCount = limits[1];

            var processor = new Processor(coresCount);

            for (int i = 0; i < inputCount; i++)
            {
                Console.WriteLine(processor.Process(tasks[i]).ToString());
            }
            Console.ReadKey();
        }
    }
}
