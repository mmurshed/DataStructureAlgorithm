using NUnit.Framework;
using System;
using System.Collections.Generic;
using DataStructure.Tree;

namespace DataStructure.NUnit.Tree
{
    [TestFixture()]
    public class BinarySearchTreeTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(Dictionary<int, int> dict, string expected)
        {
            // Arrange
            var tree = new BinarySearchTree<int, int>();

            foreach(var item in dict)
            {
                tree.Add(item.Key, item.Value);
            }

            var v = new StringVisitor<int, int>();

            // Act
            tree.InOrder(v);
            var result = v.String;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCaseSource(nameof(RemovalTestCases))]
        public void RemovalTest(Dictionary<int, int> dict, int[] remove, string[] expected)
        {
            // Arrange
            var tree = new BinarySearchTree<int, int>();

            foreach (var item in dict)
            {
                tree.Add(item.Key, item.Value);
            }

            for (int i = 0; i < remove.Length; i++)
            {
                // Arrange
                var v = new StringVisitor<int, int>();

                // Act
                tree.Remove(remove[i]);
                tree.InOrder(v);

                // Assert
                Assert.AreEqual(expected[i], v.String);
            }
        }

        static object[] TestCases =
        {
            new object[] {
                new Dictionary<int, int> {
                    {5, 10},
                    {3, 10},
                    {1, 10},
                    {4, 10},
                    {20, 10},
                    {11, 10},
                    {14, 10},
                    {13, 10},
                    {12, 10},
                    {10, 10},
                    {25, 10},
                    {21, 10},
                    {30, 10},
                    {15, 10},
                    {6, 10}
                },
                "1,3,4,5,6,10,11,12,13,14,15,20,21,25,30"
            }
        };

        static object[] RemovalTestCases =
        {
            new object[] {
                new Dictionary<int, int> {
                    {5, 10},
                    {3, 10},
                    {1, 10},
                    {4, 10},
                    {20, 10},
                    {11, 10},
                    {14, 10},
                    {13, 10},
                    {12, 10},
                    {10, 10},
                    {25, 10},
                    {21, 10},
                    {30, 10},
                    {15, 10},
                    {6, 10}
                },
                new int[] {
                    1,
                    20,
                    14,
                    15,
                    11,
                    10,
                    11,
                    12,
                    11
                },
                new string[] {
                    "3,4,5,6,10,11,12,13,14,15,20,21,25,30",
                    "3,4,5,6,10,11,12,13,14,15,21,25,30",
                    "3,4,5,6,10,11,12,13,15,21,25,30",
                    "3,4,5,6,10,11,12,13,21,25,30",
                    "3,4,5,6,10,12,13,21,25,30",
                    "3,4,5,6,12,13,21,25,30",
                    "3,4,5,6,12,13,21,25,30",
                    "3,4,5,6,13,21,25,30",
                    "3,4,5,6,13,21,25,30"
                }
            }
        };

    }
}
