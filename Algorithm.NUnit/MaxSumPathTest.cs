using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.Tree;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class MaxSumPathTest
    {
        [TestCaseSource(nameof(MaxSumPathCases))]
        public void Test(int?[] tree, int expected)
        {
            // Arrange
            var at = new Algorithm.Tree.Problems.ArrayToTree();
            var treeNode = at.Construct(tree);
            var prob = new Algorithm.Tree.Problems.MaxSumPath();

                                  
            // Act
            var result = prob.MaxPathSum(treeNode);

            // Assert
            Assert.AreEqual(expected, result);
        }

        static object[] MaxSumPathCases =
        {
            new object[] { new int?[] {1, 2, 3}, 6 },
            new object[] { new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, null, null, 1 }, 48 }
        };
    }
}
