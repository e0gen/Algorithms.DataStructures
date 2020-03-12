using System;

namespace Tasks._2._1_BracketsCheck
{
    class BracketsCheckRun
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(new BracketsChecker().CheckToString(input));
            Console.ReadKey();
        }
    }
}
