using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tasks;

namespace HashTables.Tests
{
    class PhoneBookTests
    {
        [TestCase(12, new[] {
                    "add 911 police",
                    "add 76213 Mom",
                    "add 17239 Bob",
                    "find 76213",
                    "find 910",
                    "find 911",
                    "del 910",
                    "del 911",
                    "find 911",
                    "find 76213",
                    "add 76213 daddy",
                    "find 76213"
            }, new[] {
                    "Mom",
                    "not found",
                    "police",
                    "not found",
                    "Mom",
                    "daddy"
            })]
        [TestCase(8, new[] {
                    "find 3839442",
                    "add 123456 me",
                    "add 0 granny",
                    "find 0",
                    "find 123456",
                    "del 0",
                    "del 0",
                    "find 0"
            }, new[] {
                    "not found",
                    "granny",
                    "me",
                    "not found"
            })]
        public void PhoneBookWorkCorrect(int requestsCount, string[] commands, string[] responses)
        {
            // Arrange
            var listResult = new List<string>();
            // Act
            var sut = new PhoneBook();

            for (int i = 0; i < requestsCount; i++)
            {
                var command = commands[i].Split(' ');
                switch (command[0])
                {
                    case "add":
                        //sut.Add(new PhoneBookOnLists.Contact(command[1],command[2]));
                        sut.Add(command[1], command[2]);
                        break;
                    case "find":
                        listResult.Add(sut.Find(command[1]));
                        break;
                    case "del":
                        sut.Delete(command[1]);
                        break;
                    default:
                        break;
                }
            }

            // Assert
            Assert.AreEqual(responses, listResult.ToArray());
        }
    }
}
