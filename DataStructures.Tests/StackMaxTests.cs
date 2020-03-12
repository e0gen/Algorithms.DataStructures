using NUnit.Framework;
using System;
using System.Collections.Generic;
using DataStructures.BasicStructures;

namespace BasicStructures.Tests
{
    class StackMaxTests
    {
        public static int[] TestAdapter(string[] input)
        {
            int cmdCount = int.Parse(input[0]);

            var stack = new StackMax<int>();
            List<int> Result = new List<int>();

            int cmdCounter = 0;
            while (cmdCounter != cmdCount)
            {
                var cmd = input[cmdCounter + 1];
                switch (cmd)
                {
                    case "max":
                        Result.Add(stack.Max());
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
            return Result.ToArray();
        }

        static IEnumerable<TestCaseData> TestMatrixs()
        {
            yield return new TestCaseData(new int[] { 2, 2 },
                new string[] { "5", "push 2", "push 1", "max", "pop", "max" });
            yield return new TestCaseData(new int[] { 7, 7 },
                new string[] { "6", "push 7", "push 1", "push 7", "max", "pop", "max" });
            yield return new TestCaseData(new int[] { 2, 1 },
                new string[] { "5", "push 1", "push 2", "max", "pop", "max" });
            yield return new TestCaseData(new int[] { 9, 9, 9, 9 },
                new string[] { "10", "push 2", "push 3", "push 9", "push 7", "push 2",
                    "max", "max", "max", "pop", "max" });
        }

        [TestCaseSource(nameof(TestMatrixs))]
        public void WorkCorrect(int[] expResult, string[] input)
        {
            // Arrange
            // Act
            var res = TestAdapter(input);
            // Assert
            Assert.AreEqual(expResult, res);
        }

        [Test]
        public void TestLimit()
        {
            // Arrange
            int q = 400000;
            Random rnd = new Random();

            string[] input = new string[q + 1];

            input[0] = q.ToString();
            int openedPush = 0;
            for (int i = 1; i < input.Length; i++)
            {
                switch (rnd.Next(2))
                {
                    case 0:
                        input[i] = "push " + rnd.Next(100000);
                        openedPush++;
                        break;
                    case 1:
                        if (openedPush > 0)
                        {
                            input[i] = "pop";
                            openedPush--;
                        }
                        else
                        {
                            input[i] = "push " + rnd.Next(100000);
                            openedPush++;
                        }
                        break;
                    case 2:
                        if (openedPush > 0)
                        {
                            input[i] = "max";
                        }
                        else
                        {
                            input[i] = "push " + rnd.Next(100000);
                            openedPush++;
                        }
                        break;
                }
            }
            var start = DateTime.Now;
            // Act
            var res = TestAdapter(input);
            // Assert
            var end = DateTime.Now;
            Assert.True((end - start).TotalMilliseconds < 2000);
        }
    }
}
