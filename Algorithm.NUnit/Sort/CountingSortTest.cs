using NUnit.Framework;
using System;
using Algorithm.Sort;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class CountingSortTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(string data)
        {
            // Arrange
            var data2 = new char[data.Length];
            Array.Copy(data.ToCharArray(), data2, data.Length);
            Array.Sort(data2);
            var sorter = new CountingSort(256);

            // Act
            sorter.Sort(data.ToCharArray());

            // Assert
            CollectionAssert.AreEqual(data, data2);
        }

        static object[] TestCases =
        {
            new object[] {
                "bdcwe"
            },
            new object[] {
                "b"
            },
            new object[] {
                "abcde"
            },
            new object[] {
                "edcba"
            }
        };
    }
}
