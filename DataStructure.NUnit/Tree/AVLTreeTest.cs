using NUnit.Framework;
using System;
using System.Collections.Generic;
using DataStructure.Tree;

namespace DataStructure.NUnit.Tree
{
    [TestFixture()]
    public class AVLTreeTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(Dictionary<int, int> dict, string expected)
        {
            // Arrange
            var tree = new AVLTree<int, int>();

            foreach (var item in dict)
            {
                tree.Add(item.Key, item.Value);
            }


            var v = new AVLTreeVisitor<int, int>();

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
            var tree = new AVLTree<int, int>();

            foreach (var item in dict)
            {
                tree.Add(item.Key, item.Value);
            }

            for (int i = 0; i < remove.Length; i++)
            {
                // Arrange
                var v = new AVLTreeVisitor<int, int>();

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
                "((((3:1)2:3(3:4))1:5((3:6)2:10(3:11)))0:12(((3:13)2:14((4:15)3:20))1:21(2:25(3:30))))"
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
                    "(((2:3(3:4))1:5((3:6)2:10(3:11)))0:12(((3:13)2:14((4:15)3:20))1:21(2:25(3:30))))",
                    "(((2:3(3:4))1:5((3:6)2:10(3:11)))0:12(((3:13)2:14(3:15))1:21(2:25(3:30))))",
                    "(((2:3(3:4))1:5((3:6)2:10(3:11)))0:12(((3:13)2:15)1:21(2:25(3:30))))",
                    "(((2:3(3:4))1:5((3:6)2:10(3:11)))0:12((2:13)1:21(2:25(3:30))))",
                    "(((2:3(3:4))1:5((3:6)2:10))0:12((2:13)1:21(2:25(3:30))))",
                    "(((2:3(3:4))1:5(2:6))0:12((2:13)1:21(2:25(3:30))))",
                    "(((2:3(3:4))1:5(2:6))0:12((2:13)1:21(2:25(3:30))))",
                    "(((2:3(3:4))1:5(2:6))0:13((2:21)1:25(2:30)))",
                    "(((2:3(3:4))1:5(2:6))0:13((2:21)1:25(2:30)))"
                }
            }
        };
    }
}
