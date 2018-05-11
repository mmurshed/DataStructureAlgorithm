using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class SkylineProblemTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int[,] buildings, IList<int[]> expected)
        {
            // Arrange
            var sp = new Algorithm.GoogleProblems.SkylineProblem();

            // Act
            var result = sp.GetSkyline(buildings);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        static object[] TestCases =
        {
            new object[] {
                new int[,] {
                    { 0, 2, 3 },
                    { 2, 5, 3 } 
                },
                new List<int[]> { 
                    new int[] {0, 3},
                    new int[] {5, 3},
                    new int[] {5, 0}
                }
            },
            new object[] {
                new int[,] {
                    { 2, 9, 10 },
                    { 3, 7, 15 },
                    { 5, 12, 12 },
                    { 15, 20, 10 },
                    { 19, 24, 8 }
                },
                new List<int[]> {
                    new int[] {2, 10},
                    new int[] {3, 15},
                    new int[] {7, 12},
                    new int[] {12, 0},
                    new int[] {15, 10},
                    new int[] {20, 8},
                    new int[] {24, 0}
                }
            }
        };

    }
}
