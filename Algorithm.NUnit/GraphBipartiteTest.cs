using NUnit.Framework;
using System;
namespace Algorithm.NUnit
{
    [TestFixture()]
    public class GraphBipartiteTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int[][] graph, bool expected)
        {
            // Arrange
            var obj = new Facebook.GraphBipartiteProblem();

            // Act
            var result = obj.IsBipartite(graph);

            // Assert
            Assert.AreEqual(expected, result);
        }


        static object[] TestCases =
        {
            new object[] {
                new int[][]{
                    new[]{1, 3},
                    new[]{0, 2},
                    new[]{1, 3},
                    new[]{0, 2}
                },
                true
            },
            new object[] {
                new int[][]{
                    new[]{1,2,3},
                    new[]{0,2},
                    new[]{0,1,3},
                    new[]{0,2}
                },
                false
            },
            new object[] {
                new int[][]{
                    new int[] { },
                    new[]{ 2, 4, 6 },
                    new[]{ 1, 4, 8, 9 },
                    new[]{ 7, 8 },
                    new[]{ 1, 2, 8, 9 },
                    new[]{ 6, 9 },
                    new[]{ 1, 5, 7, 8, 9 },
                    new[]{ 3, 6, 9 },
                    new[]{ 2, 3, 4, 6, 9 },
                    new[]{ 2, 4, 5, 6, 7, 8 }
                },
                false
            }
        };
    }
}
