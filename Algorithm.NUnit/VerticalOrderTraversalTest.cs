using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.Tree;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class VerticalOrderTraversalTest
    {
		[TestCaseSource(nameof(TestCases))]
        public void Test(string tree, IList<IList<int>> expected)
        {
            // Arrange
            var at = new Algorithm.Tree.Problems.TreeCodec(',', '$');
            var treeNode = at.Deserialize(tree);
            var prob = new Algorithm.Tree.Problems.VerticalOrderTraversal();

            // Act
            var result = prob.VerticalOrder(treeNode);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

		static object[] TestCases =
        {
            new object[] {
                "3,9,20,$,$,15,7",
                new List<IList<int>> {
                    new List<int> {9},
                    new List<int> {3, 15},
                    new List<int> {20},
                    new List<int> {7}
                }
            },
            new object[] {
                "3,9,8,4,0,1,7",
                new List<IList<int>> {
                    new List<int> {4},
                    new List<int> {9},
                    new List<int> {3,0,1},
                    new List<int> {8},
                    new List<int> {7}
                }
            },
            new object[] {
                "3,9,8,4,0,1,7,$,$,$,2,5",
                new List<IList<int>> {
                    new List<int> {4},
                    new List<int> {9,5},
                    new List<int> {3,0,1},
                    new List<int> {8,2},
                    new List<int> {7}
                }
            }
        };

	}
}
