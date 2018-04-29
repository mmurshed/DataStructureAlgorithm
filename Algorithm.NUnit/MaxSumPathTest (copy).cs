using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.Tree;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class ReverseKGroupTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int[] list, int k, int[] expected)
        {
            // Arrange
            var rk = new Algorithm.MicrosoftProblems.ReverseKGroupClass();
            var ln = rk.CreateList(list);
                                  
            // Act
            var result = rk.ReverseKGroup(ln, k);

            // Assert
            var ra = rk.GetArray(result);
            CollectionAssert.AreEqual(expected, ra);
        }

        static object[] TestCases =
        {
            new object[] { new int[] {1}, 2, new int[] {1} },
            new object[] { new int[] {1, 2}, 3, new int[] {1, 2} },
            new object[] { new int[] {1, 2, 3, 4, 5}, 0, new int[] {1, 2, 3, 4, 5} },
            new object[] { new int[] {1, 2, 3, 4, 5}, 1, new int[] { 1, 2, 3, 4, 5 } },
            new object[] { new int[] {1, 2, 3, 4, 5}, 2, new int[] {2, 1, 4, 3, 5} },
            new object[] { new int[] {1, 2, 3, 4, 5}, 3, new int[] {3, 2, 1, 4, 5} },
            new object[] { new int[] {1, 2, 3, 4, 5}, 4, new int[] {4, 3, 2, 1, 5} },
            new object[] { new int[] {1, 2, 3, 4, 5}, 5, new int[] {5, 4, 3, 2, 1} },
            new object[] { new int[] {1, 2, 3, 4, 5}, 6, new int[] {1, 2, 3, 4, 5} },
            new object[] { new int[] {1, 2, 3, 4, 5, 6, 7, 8}, 3, new int[] {3, 2, 1, 6, 5, 4, 7, 8} }
        };
    }
}
