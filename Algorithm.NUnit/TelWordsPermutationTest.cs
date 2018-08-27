using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
	public class TelWordsPermutationTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(string perm, Dictionary<string, List<char>> dict, IList<string> expected)
        {
            // Arrange
            var sp = new Algorithm.FacebookProblems.TelWordsPermutation();

            // Act
            var result = sp.GenTelWordsPermutation2(dict, perm);

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
                "123",
                new Dictionary<string, List<char>> {
                    {"1", new List<char> {'A', 'B', 'C'}},
                    {"2", new List<char> {'D', 'E'}},
                    {"12", new List<char> {'X'}},
                    {"3", new List<char> {'P', 'Q'}}
                },
                new List<string> {
                    "ADP", "ADQ", "AEP", "AEQ", "BDP", "BDQ", "BEP", "BEQ", "CDP", "CDQ", "CEP", "CEQ", "XP", "XQ"
                }
            }
        };

    }
}
