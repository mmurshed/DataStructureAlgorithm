using NUnit.Framework;
using System;
using DataStructure.Tree;

namespace DataStructure.NUnit.Tree
{
    [TestFixture()]
    public class SegmentTreeTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int[] data, Func<int, int, int> union, int[,] query)
        {
            // Arrange
            // var tree = new SegmentTree<int>(data, union);
            var tree = new SegmentTree<int>(data, union);

            for (int i = 0; i < query.GetLength(0); i++)
            {
                // Arrange
                int l = query[i, 0];
                int r = query[i, 1];
                int expected = query[i, 2];

                // Act
                int result = tree.Find(l, r);

                // Assert
                Assert.AreEqual(expected, result);
            }
        }

        static readonly object[] TestCases =
        {
            new object[] {
                new int[] {5, 3, 1, 4, 20, 11, 14, 13, 12, 10, 25, 21, 30, 15, 6},
                new Func<int, int, int> ( (x, y) => Math.Min(x, y) ),
                new int[,]
                {
                    {0, 14, 1},
                    {3, 14, 4}
                }
            }
        };

    }
}
