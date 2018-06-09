using NUnit.Framework;
using System;
namespace Algorithm.NUnit
{
    [TestFixture()]
    public class StringMatchTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void TestBM(string str1, string str2, int[] expected)
        {
            // Arrange
            var obj = new Algorithm.String.BoyerMooreStringMatch();

            // Act
            var result = obj.Search(str1.ToCharArray(), str2.ToCharArray());

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCaseSource(nameof(TestCases))]
        public void TestKNP(string str1, string str2, int[] expected)
        {
            // Arrange
            var obj = new Algorithm.String.KNPStringMatch();

            // Act
            var result = obj.Search(str1.ToCharArray(), str2.ToCharArray());

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCaseSource(nameof(TestCases))]
        public void TestRK(string str1, string str2, int[] expected)
        {
            // Arrange
            var obj = new Algorithm.String.RabinKarpStringMatch();

            // Act
            var result = obj.Search(str1.ToCharArray(), str2.ToCharArray());

            // Assert
            Assert.AreEqual(expected, result);
        }

        static object[] TestCases =
        {
            new object[] {"aa", "a", new int[]{0, 1}},
            new object[] {"ABAAABCD", "ABC", new int[]{4}}
        };
    }
}
