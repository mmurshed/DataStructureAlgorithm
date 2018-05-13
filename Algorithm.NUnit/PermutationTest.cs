using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class PermutationTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(string perm, IList<string> expected)
        {
            // Arrange
			var sp = new Algorithm.Recursion.Permutation();

            // Act
			var result = sp.Permutate(perm);

            // Assert
			CollectionAssert.AreEquivalent(expected, result);
        }

        static object[] TestCases =
        {
            new object[] {
                "abc",
                new List<string> {
					"abc",
                    "acb",
                    "bac",
                    "bca",
                    "cba",
                    "cab"
                }
            }
        };

    }
}
