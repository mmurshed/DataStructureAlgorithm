using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class MedianTwoSortedArrayTest
    {
        [TestCaseSource(nameof(MedianCases))]
        public void Test(int[] A, int[] B, double expected)
        {
            // Arrange
            var itw = new Algorithm.MicrosoftProblems.MedianTwoSortedArray();
                                  
            // Act
            var result = itw.FindMedian(A, B);

            // Assert
            Assert.AreEqual(expected, result);
        }

        static object[] MedianCases =
        {
            new object[] { new int[] { 1, 2, 3 }, new int[] { 3, 4, 6 }, 3.0 },
            new object[] { new int[] { 3, 4, 6 }, new int[] { 1, 2, 3 }, 3.0 },
            new object[] { new int[] { 3, 3, 3 }, new int[] { 3, 3 }, 3.0 },
            new object[] { new int[] { 3 }, new int[] { 4 }, 3.5 },
            new object[] { new int[] { 5, 6 }, new int[] { 1, 2, 3, 4, 7 }, 4.0 }
        };
    }
}
