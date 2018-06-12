using NUnit.Framework;
using System;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class EditDistanceTest
    {
        [TestCase("sunday", "saturday", 3)]
        public void EditDistanceNaiveTest(string str1, string str2, int expected)
        {
            // Arrange

            // Act
            int dist = EditDistance.EditDistNaive(str1, str2, str1.Length, str2.Length);

            // Assert
            Assert.AreEqual(dist, expected);
        }

        [TestCase("sunday", "saturday", 3)]
        public void EditDistanceDPTest(string str1, string str2, int expected)
        {
            // Arrange

            // Act
            int dist = EditDistance.EditDistDP(str1, str2, str1.Length, str2.Length);

            // Assert
            Assert.AreEqual(dist, expected);
        }
    }
}
