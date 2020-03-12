using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tasks;

namespace HashTables.Tests
{
    class SubstringSearchTests
    {
        [TestCase("aba","abacaba", "0 4")]
        [TestCase("testTesttesT", "abacaba", "4")]
        public void SubstringSearchCorrect(string pattern, string text, string result)
        {
            //// Arrange
            //var listResult = new List<string>();
            //// Act
            //var sut = new PhoneBook();

            //for (int i = 0; i < requestsCount; i++)
            //{
            //    var command = commands[i].Split(' ');
            //    switch (command[0])
            //    {
            //        case "add":
            //            //sut.Add(new PhoneBookOnLists.Contact(command[1],command[2]));
            //            sut.Add(command[1], command[2]);
            //            break;
            //        case "find":
            //            listResult.Add(sut.Find(command[1]));
            //            break;
            //        case "del":
            //            sut.Delete(command[1]);
            //            break;
            //        default:
            //            break;
            //    }
            //}

            // Assert
            //Assert.AreEqual(responses, listResult.ToArray());
        }
    }
}
