using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.PriorityQueues;

namespace PriorityQueues.Tests
{
    class BinaryHeapTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetOnEmptyFail()
        {
            var minBinHeap = new MinBinaryHeap<int>();

            Assert.Throws<InvalidOperationException>(() => minBinHeap.Peek());
        }

        [Test]
        public void ExtractOnEmptyFail()
        {
            var minBinHeap = new MinBinaryHeap<int>();

            Assert.Throws<InvalidOperationException>(() => minBinHeap.Dequeue());
        }

        [TestCase(4, "5 4 3 2")]
        public void InsertCorrect(int maxSize, string input)
        {
            // Arrange
            var minBinHeap = new MinBinaryHeap<int>(maxSize);
            var inputArray = input.Split(' ').Select(int.Parse).ToArray();

            // Act
            foreach (var item in inputArray)
            {
                minBinHeap.Enqueue(item);
            }
            // Assert
            Assert.Pass();
        }

        [Test]
        public void InsertOverLimitFail()
        {
            // Arrange
            int maxSize = 4;
            var minBinHeap = new MinBinaryHeap<int>(maxSize);
            var inputArray = new[] { 1, 2, 3, 4, 5 };

            // Act
            for (int i = 0; i < maxSize; i++)
            {
                minBinHeap.Enqueue(inputArray[i]);
            }
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => minBinHeap.Enqueue(inputArray[maxSize]));
        }

        [TestCase(5, "5 4 3 2 1", 3, new[] { "1 4", "0 1", "1 3" })]
        [TestCase(5, "1 2 3 4 5", 0, new string[] { })]
        public void BuildHeapOptimalSwaps(int inputCount, string input, int expCount, string[] expSwaps)
        {
            // Arrange
            var inputArray = input.Split(' ').Select(int.Parse).ToArray();
            var log = new List<string>();
            // Act
            var minBinHeap = new MinBinaryHeap<int>(inputArray, log);

            // Assert
            Assert.AreEqual(expCount, minBinHeap.Log.Count);
            Assert.AreEqual(expSwaps, minBinHeap.Log.ToArray());
        }

        [TestCase("10 9 8 7 6 5 4 3 2 1")]
        [TestCase("1 2 3 4 5 6 7 8 9 10")]
        [TestCase("3 3 2 2 9 9 1 1 7 7 0")]
        public void HeapSortCorrect(string input)
        {
            // Arrange
            var inputArray = input.Split(' ').Select(int.Parse).ToArray();
            var expectArray = inputArray.OrderBy(x => x).ToArray();

            var minBinHeap = new MinBinaryHeap<int>();
            int[] resultArray = new int[inputArray.Length];
            // Act

            Array.ForEach(inputArray, item => minBinHeap.Enqueue(item));

            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = minBinHeap.Dequeue();
            }
            // Assert
            Assert.AreEqual(expectArray, resultArray);
        }

        [TestCase("10 9 8 7 6 5 4 3 2 1")]
        [TestCase("1 2 3 4 5 6 7 8 9 10")]
        [TestCase("3 3 2 2 9 9 1 1 7 7 0")]
        public void DescendingSortInplaceCorrect(string input)
        {
            // Arrange
            var inputArray = input.Split(' ').Select(int.Parse).ToArray();
            var expectArray = inputArray.OrderByDescending(x => x).ToArray();
            // Act
            MinBinaryHeap<int>.HeapSort(inputArray, inputArray.Length);
            // Assert
            Assert.AreEqual(expectArray, inputArray);
        }
    }
}
