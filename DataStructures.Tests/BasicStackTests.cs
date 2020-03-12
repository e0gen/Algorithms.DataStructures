using NUnit.Framework;
using System;
using System.Linq;
using DataStructures.BasicStructures;

namespace BasicStructures.Tests
{
    class BasicStackTests
    {
        private int[] GenerateArray(int count)
        {
            Random rnd = new Random(45);
            return Enumerable.Range(1, count).Select(x => rnd.Next(0, int.MaxValue)).ToArray();
        }

        [TestCase(100)]
        public void CorrectPushAndPop(int capacity)
        {
            int[] inputArray = GenerateArray(capacity);
            int[] resultArray = new int[capacity];
            var sut = new BasicStack<int>();

            Array.ForEach(inputArray, x => sut.Push(x));

            for (int i = 0; i < capacity; i++)
            {
                resultArray[i] = sut.Pop();
            }
            // Assert
            Assert.AreEqual(inputArray.Reverse(), resultArray);
        }

        [Test]
        public void FailPopOnEmpty()
        {
            var sut = new BasicStack<int>();
            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Peek());
            Assert.Throws<InvalidOperationException>(() => sut.Pop());
        }

        [TestCase(0)]
        [TestCase(100)]
        public void PushOverCapacity(int capacity)
        {
            var sut = new BasicStack<int>(GenerateArray(capacity));
            // Assert
            Assert.DoesNotThrow(() => sut.Push(12));
            Assert.Greater(sut.Count, capacity);
        }
    }
}
