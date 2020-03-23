using NUnit.Framework;
using System;

namespace Algorithm.NUnit
{
    [TestFixture()]
	public class MinWindowTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(string s, string t, string expected)
        {
            // Arrange
			var prob = new Facebook.MinWindowProblem();

            // Act
			var result = prob.MinWindow(s, t);

            // Assert
			CollectionAssert.AreEquivalent(expected, result);
        }

        static object[] TestCases =
        {
            new object[] {
                "ADOBECODEBANC", "ABC", "BANC"
            },
            new object[] {
                "ADOBECODEBANC", "ZZZ", ""
            },
            new object[] {
                "YADOBECODEBANCZ", "YABCZ", "YADOBECODEBANCZ"
            },
            new object[] {
                "", "", ""
            },
            new object[] {
                "ABC", "", ""
            },
            new object[] {
                "", "A", ""
            },
            new object[] {
                "aa", "aa", "aa"
            },
            new object[] {
                "a", "aa", ""
            },
            new object[] {
                "a", "b", ""
            },
            new object[] {
                "ab", "b", "b"
            }
        };

    }
}
