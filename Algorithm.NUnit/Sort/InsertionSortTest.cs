using NUnit.Framework;
using System;
using Algorithm.Sort;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class InsertionSortTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int[] data)
        {
            // Arrange
            int[] data2 = new int[data.Length];
            Array.Copy(data, data2, data.Length);
            Array.Sort(data2);
            var sorter = new InsertionSort<int>();

            // Act
            sorter.Sort(data);

            // Assert
			CollectionAssert.AreEqual(data, data2);
        }

        static object[] TestCases =
        {
            new object[] {
                new [] {2, 3, 9, 6, 7}
            },
            new object[] {
                new [] {2}
            },
            new object[] {
                new [] {1, 2, 3, 4}
            },
            new object[] {
                new [] {4, 3, 2, 1}
            }
        };
    }
}
