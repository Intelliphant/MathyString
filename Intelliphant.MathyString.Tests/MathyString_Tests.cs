using NUnit.Framework;

namespace Intelliphant.MathyString.Tests
{
    [TestFixture]
    public class MathyString_Tests
    {
        [Test]
        public void MultiplicationByInt()
        {
            MathyString s = "test";
            var result = s * 3;

            Assert.AreEqual("testtesttest", result.ToString());
        }

        [Test]
        public void DivisionByString()
        {
            MathyString s = "wibble wobble warble";
            var result = s / " ";

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("wibble", result[0].ToString());
            Assert.AreEqual("wobble", result[1].ToString());
            Assert.AreEqual("warble", result[2].ToString());
        }

        [Test]
        public void DivisionByInt()
        {
            MathyString s = "strings mathed";
            var result = s / 3;

            Assert.AreEqual(5, result.Length);
            Assert.AreEqual("ing", result[1].ToString());
            Assert.AreEqual("ed", result[4].ToString());
        }

        [Test]
        public void ModulusByString()
        {
            MathyString s = "wibble wobble warble";
            var result = s % " ";

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(" ", result[0].ToString());
        }

        [Test]
        public void ModulusByInt()
        {
            MathyString s = "mathy";
            var result = s % 3;

            Assert.AreEqual("hy", result.ToString());
        }

        [Test]
        public void SubtractionOfString()
        {
            MathyString s = "abcabc";
            var result = s - "c";

            Assert.AreEqual("abab", result.ToString());
        }

        [Test]
        public void SubtractionOfInt()
        {
            MathyString s = "abc";
            var result = s - 2;

            Assert.AreEqual("a", result.ToString());
        }

        [Test]
        public void SubtractionOfIntEqualToLength()
        {
            MathyString s = "abc";
            var result = s - 3;

            Assert.AreEqual("", result.ToString());
        }

        [Test]
        public void SubtractionOfIntGreaterThanLengthGivesBack()
        {
            MathyString s = "abc";
            var result = s - 5;

            Assert.AreEqual(new string('\b', 2), result.ToString());
        }

        [Test]
        public void DecrementIsJustSubtracting1()
        {
            MathyString s = "abc";
            s--;

            Assert.AreEqual("ab", s.ToString());
        }

        [Test]
        public void IncrementConcatenates1()
        {
            MathyString s = "abc";
            s++;

            Assert.AreEqual("abc1", s.ToString());
        }

        [Test]
        public void AdditionDoesConcatenation()
        {
            MathyString s = "abc";
            var result = s + "d";

            Assert.AreEqual("abcd", result.ToString());
        }

        [Test]
        public void Test()
        {
            MathyString s = "abc";
            MathyString t = "def";

            var result = s + t;

            Assert.AreEqual("abcdef", result.ToString());
        }
    }
}
