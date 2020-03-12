using NUnit.Framework;
using System;
using System.Linq;
using DataStructures.BasicStructures;

namespace LinkedLists.Tests
{
    class OneWayListTests
    {
        private int[] iarray = Enumerable.Range(1, 100).ToArray();

        [Test]
        public void EnumerateOnEmptyList()
        {
            var sut = new OneWayList<int>();

            // Assert
            Assert.AreEqual(new int[] { }, sut.ToArray());
        }

        [Test]
        public void Enumerate()
        {
            var sut = new OneWayList<int>(iarray);

            // Assert
            Assert.AreEqual(iarray, sut.ToArray());
        }



        [Test]
        public void InsertFirstInEmptyList()
        {
            var sut = new OneWayList<int>();

            sut.InsertFirst(1);
            // Assert
            Assert.AreEqual(1, sut.Head.Value);
            Assert.AreEqual(1, sut.Count);
            Assert.AreEqual(sut.Head, sut.Tail);
        }

        [Test]
        public void InsertLastInEmptyList()
        {
            var sut = new OneWayList<int>();

            sut.InsertLast(1);
            // Assert
            Assert.AreEqual(1, sut.Head.Value);
            Assert.AreEqual(1, sut.Count);
            Assert.AreEqual(sut.Head, sut.Tail);
        }

        [Test]
        public void InsertFirstInList()
        {
            var sut = new OneWayList<int>(iarray);

            sut.InsertFirst(2);
            // Assert
            Assert.AreEqual(2, sut.Head.Value);
            Assert.AreEqual(iarray.Length + 1, sut.Count);
        }

        [Test]
        public void InsertLastInList()
        {
            var sut = new OneWayList<int>(iarray);

            sut.InsertLast(2);
            // Assert
            Assert.AreEqual(2, sut.Tail.Value);
            Assert.AreEqual(iarray.Length + 1, sut.Count);
        }

        [Test]
        public void DeleteFirstInList()
        {
            var sut = new OneWayList<int>(iarray);
            var first = iarray[0];

            sut.DeleteFirst();
            // Assert
            Assert.AreNotEqual(first, sut.Head.Value);
            Assert.AreEqual(iarray.Length - 1, sut.Count);
        }

        [Test]
        public void DeleteLastInList()
        {
            var sut = new OneWayList<int>(iarray);
            var last = iarray[iarray.Length - 1];

            sut.DeleteLast();
            // Assert
            Assert.AreNotEqual(last, sut.Tail.Value);
            Assert.AreEqual(iarray.Length - 1, sut.Count);
        }

        [Test]
        public void DeleteInMiddle()
        {
            int[] input     = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] expOutput = new int[] { 1, 2, 3, 4,    6, 7, 8, 9, 10 };

            var sut = new OneWayList<int>(input);

            int index = 5;
            var remNode = sut.Head;

            while (--index > 0)
            {
                remNode = remNode.Next;
            }
            

            sut.Delete(remNode);
            // Assert
            Assert.AreEqual(expOutput, sut.ToArray());
            Assert.AreEqual(expOutput.Count(), sut.Count);
        }


        [Test]
        public void FailOnDeleteInEmptyList()
        {
            var sut = new OneWayList<int>();

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.DeleteFirst());
            Assert.Throws<InvalidOperationException>(() => sut.DeleteLast());
        }

        [Test]
        public void FailOnOperationsWithInvalidNode()
        {
            var invalidNode = new OneWayListNode<int>(new OneWayList<int>(), 12);
            var sut = new OneWayList<int>(iarray);

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.Delete(invalidNode));
            Assert.Throws<InvalidOperationException>(() => sut.InsertAfter(invalidNode, 12));
        }

    }
}
