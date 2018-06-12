using NUnit.Framework;
using System;
using Algorithm.DynamicProgramming;
using System.Collections.Generic;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class LongestIncreasingDecreasingSubsequenceTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int[] a, int expected)
        {
            // Arrange
            var obj = new Algorithm.DynamicProgramming.LongestIncreasingDecreasingSubsequence();
            var A = new List<int>(a);

            // Act
            int result = obj.longestSubsequenceLength(A);

            // Assert
            Assert.AreEqual(expected, result);
        }

        static object[] TestCases =
        {
            new object[] { new int[] {}, 0 },
            new object[] { new int[] {1}, 1 },
            new object[] { new int[] {1, 2, 3}, 3 },
            new object[] { new int[] {1, 11, 2, 10, 4, 5, 2, 1}, 6 },
            new object[] { new int[] {9, 6, 1, 10, 2, 5, 12, 30, 31, 20, 22, 18}, 8 }
        };

    }
}
