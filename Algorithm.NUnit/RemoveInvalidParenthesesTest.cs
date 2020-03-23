using NUnit.Framework;
using System;
using System.Collections.Generic;
using Algorithm.DynamicProgramming;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class RemoveInvalidParenthesesTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(string s, IList<string> expected)
        {
            // Arrange
			var sp = new Facebook.RemoveInvalidParenthesesProblem();

            // Act
			var result = sp.RemoveInvalidParentheses(s);

            // Assert
			CollectionAssert.AreEquivalent(expected, result);
        }

        static object[] TestCases =
        {
            new object[] {
                "()())()",
                new List<string> {
                    "()()()",
                    "(())()"
                }
            },
            new object[] {
                "(a)())()",
                new List<string> {
                    "(a)()()",
                    "(a())()"
                }
            },
            new object[] {
                ")(",
                new List<string> {
                    ""
                }
            }
        };

    }
}
