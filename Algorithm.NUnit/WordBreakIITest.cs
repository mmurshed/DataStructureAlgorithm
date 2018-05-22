using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class WordBreakIITest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(string str, IList<string> dictionary, IList<string> expected)
        {
            // Arrange
            var sp = new Algorithm.DynamicProgramming.Micellaneous.WordBreakII();

            // Act
            var result = sp.WordBreak(str, dictionary);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        static object[] TestCases =
        {
            new object[] {
                "catsanddog",
                new List<string> {"cat", "cats", "and", "sand", "dog"},
                new List<string> {"cats and dog", "cat sand dog"}
            },
            new object[] {
                "pineapplepenapple",
                new List<string> {"apple", "pen", "applepen", "pine", "pineapple"},
                new List<string> {"pine apple pen apple", "pineapple pen apple", "pine applepen apple"}
            },
            new object[] {
                "banana",
                new List<string> {"ba", "na", "fe"},
                new List<string> {"ba na na"}
            }
        };

    }
}
