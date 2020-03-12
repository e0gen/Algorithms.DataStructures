using NUnit.Framework;
using Tasks._2._1_BracketsCheck;

namespace BasicStructures.Tests
{
    class BracketsTests
    {
        [TestCase("1", "{")]
        [TestCase("1", "{[]")]
        [TestCase("3", "{{{")]
        [TestCase("3", "[]([]")]
        [TestCase("3", "{{{[][][]")]
        [TestCase("6", "{{{{{{{((()))}")]
        [TestCase("5", "{()}{")]
        [TestCase("1", "}()")]
        [TestCase("3", "()}()")]
        [TestCase("1", "}()")]
        [TestCase("7", "{[()]}}()")]
        [TestCase("13", "dasdsadsadas]]]")]
        [TestCase("Success", "{}()")]
        [TestCase("Success", "({}[(((())))])")]
        [TestCase("Success", "()")]
        [TestCase("Success", "({})")]
        [TestCase("Success", "foo(bar({ <some initialization> })[i]);")]
        [TestCase("Success", "([](){([])})")]
        [TestCase("5", "()[]}")]
        [TestCase("7", "{{[()]]")]
        [TestCase("3", "{{{[][][]")]
        [TestCase("3", "{*{{}")]
        [TestCase("2", "[[*")]
        [TestCase("2", "{{")]
        [TestCase("3", "{{{**[][][]")]
        public void BeSuccessfullOrShowIndex(string expResult, string input)
        {
            // Arrange
            var checker = new BracketsChecker();
            // Act
            var res = checker.CheckToString(input);
            // Assert
            Assert.AreEqual(expResult, res);
        }
    }
}
