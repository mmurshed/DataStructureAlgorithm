using NUnit.Framework;
using System.Collections.Generic;

using Problems.Facebook;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class MedianFinderTest
    {
        [TestCase]
        public void Test()
        {
            // Arrange
            var sol = new MedianFinder();

            sol.AddNum(-1);
            sol.AddNum(-2);
            sol.AddNum(-3);
            sol.AddNum(-4);
            sol.AddNum(-5);

            // Act
            var data = sol.FindMedian();

            // Assert
            Assert.AreEqual(-3, data);
        }

	}
}
