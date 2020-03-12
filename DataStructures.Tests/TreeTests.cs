using DataStructures.BasicStructures;
using NUnit.Framework;
using System.Linq;

namespace BasicStructures.Tests
{
    class TreeTests
    {
        [TestCase(3, "5", "4 -1 4 1 1")]
        [TestCase(4, "5", "-1 0 4 0 3")]
        public void CorrectCalcTreeHeight(int expResult, string n, string input)
        {
            // Arrange
            var size = int.Parse(n);
            var data = input.Split(' ').Select(int.Parse).ToArray();
            var tree = new Tree(data);
            // Act

            var res = tree.Height;
            // Assert
            Assert.AreEqual(expResult, res);
        }
    }
}
