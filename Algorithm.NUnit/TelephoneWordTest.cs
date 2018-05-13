using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
	public class TelephoneWordTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(int perm, IList<string> expected)
        {
            // Arrange
			var sp = new Algorithm.Recursion.TelephoneWords();

            // Act
			var result = sp.GenerateTelephoneWords(perm);

            // Assert
			CollectionAssert.AreEquivalent(expected, result);
        }

		//[TestCaseSource(nameof(TestCases))]
   //     public void TestNoRec(int perm, IList<string> expected)
   //     {
   //         // Arrange
   //         var sp = new Algorithm.Recursion.TelephoneWords();

   //         // Act
			//var result = sp.GenerateTelephoneWordsNoRecursion(perm);

        //    // Assert
        //    CollectionAssert.AreEquivalent(expected, result);
        //}

        static object[] TestCases =
        {
            new object[] {
                123,
                new List<string> {
					"1AD",
                    "1AE",
                    "1AF",
                    "1BD",
                    "1BE",
                    "1BF",
                    "1CD",
                    "1CE",
                    "1CF"
                }
            }
        };

    }
}
