using NUnit.Framework;
using System.Collections.Generic;

using Problems.Facebook;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class RandomizedCollectionTest
    {
        [TestCase]
        public void Test()
        {
            // Arrange
            var rndc = new RandomizedCollection();


            // Act
            rndc.Insert(4);
            rndc.Insert(3);
            rndc.Insert(4);
            rndc.Insert(2);
            rndc.Insert(4);

            rndc.Remove(4);
            rndc.Remove(3);
            rndc.Remove(4);
            rndc.Remove(4);

            // Assert
        }

	}
}
