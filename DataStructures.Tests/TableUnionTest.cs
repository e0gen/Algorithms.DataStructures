using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Tasks;
using Tasks._4._1_TableUnion;

namespace DisjointSets.Tests
{
    class TableUnionTest
    {
        [TestCase(5, 5, "1 1 1 1 1", new[] {
                    "3 5",
                    "2 4",
                    "1 4",
                    "5 4",
                    "5 4" 
            }, "2 2 3 5 5" )]
        [TestCase(6, 4, "10 0 5 0 3 3", new[] {
                    "6 6",
                    "6 5",
                    "5 4",
                    "4 3",
            }, "10 10 10 11")]
        public void TableUnionCorrect(int tableCount, int requestCount, string rows, string[] unions, string expResults)
        {
            // Arrange
            var tableArray = rows.Split(' ').Select(x => new Table() { RowsCount = int.Parse(x) }).ToArray();
            var expMax = expResults.Split(' ').Select(int.Parse).ToArray();
            var listResult = new List<int>();
            // Act
            var db = new TableSet(tableArray);

            for (int i = 0; i < requestCount; i++)
            {
                var request = unions[i].Split(' ').Select(int.Parse).ToArray();
                db.Union(request[0] - 1, request[1] - 1);
                listResult.Add(db.MaxValue);
            }

            // Assert
            Assert.AreEqual(expMax, listResult.ToArray());
        }
    }
}
