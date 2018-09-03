using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.FacebookProblems;
using System.Linq;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class MaxSumNonoverlappingSubarrayTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int[] nums, int K, int[] expected)
        {
            // Arrange
            var prob = new MaxSumNonoverlappingSubarray();

                                  
            // Act
            var result = prob.MaxSumOfThreeSubarrays(nums, K);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        static object[] TestCases =
        {
            new object[] { new int[] {1, 2, 1, 2, 6, 7, 5, 1}, 2, new int[] {0, 3, 5} },
        };
    }
}
