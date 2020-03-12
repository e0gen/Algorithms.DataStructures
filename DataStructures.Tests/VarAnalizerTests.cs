using NUnit.Framework;
using System.Linq;
using DataStructures.DisjointSets;

namespace DisjointSets.Tests
{
    class VarAnalyzerTests
    {
        [TestCase(4, 6, 0, new[] {
                    "1 2",
                    "1 3",
                    "1 4",
                    "2 3",
                    "2 4",
                    "3 4"
            }, 1)]
        [TestCase(4, 6, 1, new[] {
                    "1 2",
                    "1 3",
                    "1 4",
                    "2 3",
                    "2 4",
                    "3 4",
                    "1 2"
            }, 0)]
        [TestCase(4, 0, 6, new[] {
                    "1 2",
                    "1 3",
                    "1 4",
                    "2 3",
                    "2 4",
                    "3 4"
            }, 1)]
        [TestCase(6, 5, 3, new[] {
                    "2 3",
                    "1 5",
                    "2 5",
                    "3 4",
                    "4 2",
                    "6 1",
                    "4 6",
                    "4 5",
            }, 0)]
        public void TableUnionCorrect(int varCount, int equalsCount, int unEqualsCount, string[] relations, int expResult)
        {
            // Arrange
            var result = 1;
            // Act
            var analyzer = new DisjointSetUnion(varCount);

            for (int i = 0; i < varCount; i++)
            {
                analyzer.MakeSet(i);
            }

            for (int i = 0; i < equalsCount; i++)
            {
                var equalPair = relations[i].Split(' ').Select(int.Parse).ToArray();
                analyzer.Union(equalPair[0] - 1, equalPair[1] - 1);
            }

            for (int i = equalsCount; i < equalsCount + unEqualsCount; i++)
            {
                var unEqualPair = relations[i].Split(' ').Select(int.Parse).ToArray();

                if (analyzer.Find(unEqualPair[0] - 1) == analyzer.Find(unEqualPair[1] - 1))
                    result = 0;
            }

            // Assert
            Assert.AreEqual(expResult, result);
        }
    }
}
