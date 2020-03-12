using System;
using System.Linq;

namespace Tasks._4._1_TableUnion
{
    class TableUnionRun
    {
        static void Main(string[] args)
        {
            var counts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var tablesArray = Console.ReadLine().Split(' ').Select(x => new Table() { RowsCount = int.Parse(x) }).ToArray();

            var tableCount = counts[0];
            var requestCount = counts[1];

            var db = new TableSet(tablesArray);

            for (int i = 0; i < requestCount; i++)
            {
                var request = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                db.Union(request[0]-1, request[1]-1);
                Console.WriteLine(db.MaxValue);
            }
            Console.ReadKey();
        }
    }
}
