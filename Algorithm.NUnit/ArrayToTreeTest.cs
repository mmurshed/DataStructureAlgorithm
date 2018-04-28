using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.Tree;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class ArrayToTreeTest
    {
        // [TestCaseSource(nameof(ArrayToTreeCases))]
        [Test()]
        public void Test()
        {
            // Arrange
            var at = new Algorithm.Tree.Problems.ArrayToTree();
            var tree = new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, null, null, 1 };

                                  
            // Act
            var treeNode = at.Construct(tree);

            // Assert
            // Assert.AreEqual(result);
        }

        static object[] ArrayToTreeCases =
        {
            new object[] { new int?[] {1, 2, 3}, 6 }
            // new object[] { new int?[] {5, 4, 8, 11, new int?(), 13, 4, 7, 2, new int?(), new int?(), new int?(), 1}, 48 }
        };
    }
}
