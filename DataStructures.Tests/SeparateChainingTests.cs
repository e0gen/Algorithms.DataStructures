using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tasks;

namespace HashTables.Tests
{
    class SeparateChainingTests
    {
        [TestCase(5, 12, new[] {
                    "add world",
                    "add Hell0",
                    "check 4",
                    "find World",
                    "find world",
                    "del world",
                    "check 4",
                    "del Hell0",
                    "add luck",
                    "add GooD",
                    "check 2",
                    "del good"
            }, new[] {
                    "Hell0 world",
                    "no",
                    "yes",
                    "Hell0",
                    "GooD luck"
            })]
        [TestCase(4, 8, new[] {
                    "add test",
                    "add test",
                    "find test",
                    "del test",
                    "find test",
                    "find Test",
                    "add Test",
                    "find Test"
            }, new[] {
                    "yes",
                    "no",
                    "no",
                    "yes"
            })]
        public void SeparateChainingHashTableWorkCorrect(int m, int n, string[] commands, string[] responses)
        {
            // Arrange
            var listResult = new List<string>();
            // Act
            var sut = new HashTableSc(m);

            for (int i = 0; i < n; i++)
            {
                var command = commands[i].Split(' ');
                switch (command[0])
                {
                    case "add":
                        sut.Add(command[1]);
                        break;
                    case "find":
                        listResult.Add(sut.Find(command[1]));
                        break;
                    case "check":
                        listResult.Add(sut.Check(int.Parse(command[1])));
                        break;
                    case "del":
                        sut.Delete(command[1]);
                        break;
                }
            }

            // Assert
            Assert.AreEqual(responses, listResult.ToArray());
        }

        [TestCase("GooD", 5, 2)]
        [TestCase("luck", 5, 2)]
        [TestCase("Hell0", 5, 4)]
        [TestCase("world", 5, 4)]
        [TestCase("qaxndhusptgrewo", 25, 7)]
        [TestCase("uiljkwhypgmfdst", 250, 72)]
        [TestCase("pweiknqgcxazjyh", 2500, 263)]
        [TestCase("ilvpygszwdeurjn", 25000, 9134)]
        [TestCase("xnzrvwcutfgbqje", 250000, 170995)]
        [TestCase("rpqlfogsamhjkic", 2500000, 954764)]
        [TestCase("zhjutqslrpyfcoa", 25000000, 9581368)]
        //[TestCase("kxlcfgpezjmuynv", 250000000, 127141737)]
        public void HashCodeCheck(string entry, int m, int h)
        {
            // Arrange
            var sut = new HashTableSc(m);
            // Act
            var hash = sut.GetHashCode(entry);

            // Assert
            Assert.AreEqual(h, hash);
        }
    }
}
