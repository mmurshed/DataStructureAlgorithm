using NUnit.Framework;
using System;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class RegularExpressionTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(string str1, string str2, bool expected)
        {
            // Arrange
            var obj = new Algorithm.FacebookProblems.RegularExpression();

            // Act
            var result = obj.IsMatch(str1, str2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCaseSource(nameof(TestCases))]
        public void TestDP(string str1, string str2, bool expected)
        {
            // Arrange
            var obj = new Algorithm.FacebookProblems.RegularExpression();

            // Act
            var result = obj.IsMatchDP(str1, str2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        static object[] TestCases = 
        {
            new object[] {"aa", "a", false},
            new object[] {"aa", "a", false},
            new object[] {"aa", "a*", true},
            new object[] {"ab", ".*", true},
            new object[] {"aaa", "a*a", true},
            new object[] {"aab", "c*a*b", true},
            new object[] {"mississippi", "mis*is*p*.", false},
            new object[] {"aaa", "ab*a*c*a", true},
            new object[] {"a", "ab*", true},
            new object[] {"a", ".*..a*", false},
        };

    }
}
