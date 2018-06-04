using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class LargestAreaUnderHistogramTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int[] histogram, int expected)
        {
            // Arrange
            var itw = new Algorithm.MicrosoftProblems.LargestAreaUnderHistogram();
                                  
            // Act
            var result = itw.FindLargestAreaUnderHistogram(histogram);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCaseSource(nameof(TestCases))]
        public void Test2(int[] histogram, int expected)
        {
            // Arrange
            var itw = new Algorithm.MicrosoftProblems.LargestAreaUnderHistogram();

            // Act
            var result = itw.FindLargestAreaUnderHistogram2(histogram);

            // Assert
            Assert.AreEqual(expected, result);
        }


        static object[] TestCases =
        {
            new object[] {new int[] {6, 1, 5, 4, 5, 2, 6}, 12}
        };
    }
}
