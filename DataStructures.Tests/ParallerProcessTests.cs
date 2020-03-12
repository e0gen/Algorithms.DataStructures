using NUnit.Framework;
using Tasks;
using System.Collections.Generic;
using System.Linq;
using Tasks._3._2_Processor;

namespace PriorityQueues.Tests
{
    public class ParallerProcessTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2, 5, "1 2 3 4 5",
            new[] {
                "0 0",
                "1 0",
                "0 1",
                "1 2",
                "0 4" })]
        [TestCase(4, 20, "1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1",
            new[] {
                "0 0",
                "1 0",
                "2 0",
                "3 0",
                "0 1",
                "1 1",
                "2 1",
                "3 1",
                "0 2",
                "1 2",
                "2 2",
                "3 2",
                "0 3",
                "1 3",
                "2 3",
                "3 3",
                "0 4",
                "1 4",
                "2 4",
                "3 4",
            })]
        [TestCase(2, 15, "0 0 1 0 0 0 2 1 2 3 0 0 0 2 1",
            new[] {
                "0 0",
                "0 0",
                "0 0",
                "1 0",
                "1 0",
                "1 0",
                "1 0",
                "0 1",
                "0 2",
                "1 2",
                "0 4",
                "0 4",
                "0 4",
                "0 4",
                "1 5",
            })]

        public void ProcessorsWorkCorrect(int coresCount, int inputCount, string tasksArray, string[] expResults)
        {
            // Arrange
            var tasks = tasksArray.Split(' ').Select(x => int.Parse(x)).ToArray();
            var listResult = new List<string>();
            // Act
            var sut = new Processor(coresCount);

            for (int i = 0; i < inputCount; i++)
            {
                listResult.Add(sut.Process(tasks[i]).ToString());
            }

            // Assert
            Assert.AreEqual(expResults, listResult.ToArray());
        }
    }
}