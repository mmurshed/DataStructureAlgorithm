using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithm.NUnit
{
    [TestFixture()]
	public class FindAnagramsTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(string s, string p, List<int> expected)
        {
            // Arrange
			var prob = new Facebook.FindAnagramsProblem();

            // Act
			var result = prob.FindAnagrams(s, p);

            // Assert
			CollectionAssert.AreEquivalent(expected, result);
        }

        static object[] TestCases =
        {
            new object[] {
                "cbaebabacd", "abc", new List<int> { 0, 6}
            },
            new object[] {
                "abab", "ab", new List<int> { 0, 1, 2}
            },
            new object[] {
                "aaabaaa", "aaa", new List<int> { 0, 4}
            }
        };

    }
}
