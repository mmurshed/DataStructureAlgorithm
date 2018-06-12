using NUnit.Framework;
using System;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class LongestRepeatingSubsequence
    {
        [TestCase("AABB", 2)]
        public void LongestRepeatingSubsequenceDPTest(string str1, int expected)
        {
            // Arrange

            // Act
            var result = Algorithm.DynamicProgramming.LongestRepeatingSubsequence.Generate(str1);

            // Assert
            Assert.AreEqual(expected, result.Item1);
        }
    }
}
