using System;
using System.Linq;

namespace Tasks
{
    public class SeparateChainingRun
    {
        static void Main(string[] args)
        {
            var m = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());

            var sut = new HashTableSc(m);

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(' ').ToArray();
                switch (command[0])
                {
                    case "add":
                        sut.Add(command[1]);
                        break;
                    case "find":
                        Console.WriteLine(sut.Find(command[1]));
                        break;
                    case "check":
                        Console.WriteLine(sut.Check(int.Parse(command[1])));
                        break;
                    case "del":
                        sut.Delete(command[1]);
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}