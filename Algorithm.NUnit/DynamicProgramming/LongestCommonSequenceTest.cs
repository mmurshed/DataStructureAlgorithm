using NUnit.Framework;
using System;
using Algorithm.DynamicProgramming;
using System.Collections.Generic;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class LongestCommonSequenceTest
    {
        [TestCase("ABCDGH", "AEDFHR", 3)]
        public void LongestCommonSequenceNaiveTest(string str1, string str2, int expected)
        {
            // Arrange

            // Act
            int result = Algorithm.DynamicProgramming.LongestCommonSubsequence.GenerateNaive(str1, str2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase("ABCDGH", "AEDFHR", 3)]
        public void LongestCommonSequenceDPTest(string str1, string str2, int expected)
        {
            // Arrange

            // Act
            var result = Algorithm.DynamicProgramming.LongestCommonSubsequence.Generate(str1, str2);

            // Assert
            Assert.AreEqual(expected, result.Item1);
        }
    }
}
