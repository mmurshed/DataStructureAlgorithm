using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class DecodeWaysTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(string s, int expected)
        {
            // Arrange
            var sp = new Algorithm.FacebookProblems.DecodeWays();

            // Act
            var result = sp.NumDecodings(s);

            // Assert
			Assert.AreEqual(expected, result);
        }

        static object[] TestCases =
        {
            new object[] {
                "12", 2
            },
            new object[] {
                "226", 3
            }
        };

    }
}
