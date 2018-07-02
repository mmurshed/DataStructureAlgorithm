using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class CombinationSumTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int[] candidates, int target, IList<IList<int>> expected)
        {
            // Arrange
            var sp = new Algorithm.Backtracking.CombinationSumClass();

            // Act
            var result = sp.CombinationSum(candidates, target);

            // Assert
			CollectionAssert.AreEquivalent(expected, result);
        }

        static object[] TestCases =
        {
            new object[] {
                new [] {2, 3, 6, 7},
                7,
                new List<IList<int>> {
                    new List<int> {7},
                    new List<int> {2,2,3}
                }
            }
        };

    }
}
