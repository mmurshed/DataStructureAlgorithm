using NUnit.Framework;
using System;
using Algorithm.Sort;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class BucketSortTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(float[] data)
        {
            // Arrange
            var data2 = new float[data.Length];
            Array.Copy(data, data2, data.Length);
            Array.Sort(data2);
            var sorter = new BucketSort();

            // Act
            sorter.Sort(data);

            // Assert
			CollectionAssert.AreEqual(data, data2);
        }

        static object[] TestCases =
        {
            new object[] {
                new [] {.1, .5, .2, .7, .3}
            },
            new object[] {
                new [] {.2}
            },
            new object[] {
                new [] {.1, .2, .3, .4}
            },
            new object[] {
                new [] {.4, .3, .2, .1}
            }
        };
    }
}
