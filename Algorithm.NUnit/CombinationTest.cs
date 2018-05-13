using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class CombinationTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(string perm, IList<string> expected)
        {
            // Arrange
			var sp = new Algorithm.Recursion.Combination();

            // Act
			var result = sp.ProduceCombination(perm);

            // Assert
			CollectionAssert.AreEquivalent(expected, result);
        }

        static object[] TestCases =
        {
            new object[] {
                "abc",
                new List<string> {
					"abc",
                    "ab",
                    "ac",
                    "a",
                    "bc",
					"b",
                    "c"
                }
            }
        };

    }
}
