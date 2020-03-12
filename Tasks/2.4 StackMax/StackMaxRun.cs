using System;
using DataStructures.BasicStructures;

namespace Tasks._2._4_StackMax
{
    class StackMaxRun
    {
        static void Main(string[] args)
        {
            int cmdCount = int.Parse(Console.ReadLine());

            var stack = new StackMax<int>();

            int cmdCounter = 0;
            while (cmdCounter != cmdCount)
            {
                var cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "max":
                        Console.WriteLine(stack.Max());
                        break;
                    case "pop":
                        stack.Pop();
                        break;
                    default:
                        string[] push = cmd.Split(' ');
                        stack.Push(int.Parse(push[1]));
                        break;
                }
                cmdCounter++;
            }
            Console.ReadKey();
        }
    }
}
