using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class ThreeSumTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int[] s, List<List<int>> expected)
        {
            // Arrange
            var sp = new Algorithm.FacebookProblems.ThreeSumProblem();

            // Act
            var result = sp.ThreeSum(s);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        static object[] TestCases =
        {
            new object[] {
                new int[] {-1, 0, 1, 2, -1, -4},
                new List<List<int>> {
                    new List<int> {-1, 0, 1},
                    new List<int> {-1, -1, 2}
                }
            },
            new object[] {
                new int[] {-4,-2,-2,-2,0,1,2,2,2,3,3,4,4,6,6},
                new List<List<int>> {
                    new List<int> {-4, -2, 6},
                    new List<int> {-4, 0, 4},
                    new List<int> {-4, 1, 3},
                    new List<int> {-4, 2, 2},
                    new List<int> {-2, -2, 4},
                    new List<int> {-2, 0, 2}
                }
            }
        };

    }
}
