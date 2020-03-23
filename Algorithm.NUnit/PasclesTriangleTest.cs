using NUnit.Framework;
using System.Collections.Generic;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class PasclesTriangleTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int n, IList<int> expected)
        {
            // Arrange
			var sp = new Problems.Recursion.PasclesTriangle();

            // Act
			var result = sp.GetRow(n);

            // Assert
			CollectionAssert.AreEquivalent(expected, result);
        }

        static object[] TestCases =
        {
            new object[] {3, new List<int> {1, 3, 3, 1,}}
        };

    }
}
