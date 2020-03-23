using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class AccountsMergeTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(IList<IList<string>> accounts, IList<IList<string>> expected)
        {
            // Arrange
            var obj = new Facebook.AccountsMergeProblem();

            // Act
            var result = obj.AccountsMerge(accounts);

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }


        static object[] TestCases =
        {
            //new object[] {
            //    new List<IList<string>> {
            //        new List<string> {"John","johnsmith@mail.com","john_newyork@mail.com" },
            //        new List<string> {"John","johnsmith@mail.com","john00@mail.com" },
            //        new List<string> {"Mary","mary@mail.com" },
            //        new List<string> {"John","johnnybravo@mail.com"}
            //    },
            //    new List<IList<string>> {
            //        new List<string> {"John", "john00@mail.com","johnsmith@mail.com","john_newyork@mail.com" },
            //        new List<string> {"Mary","mary@mail.com" },
            //        new List<string> {"John","johnnybravo@mail.com"}
            //    }
            //},
            new object[] {
                new List<IList<string>> {
                    new List<string> { "David","David0@m.co","David1@m.co" },
                    new List<string> { "David","David3@m.co","David4@m.co" },
                    new List<string> { "David","David4@m.co","David5@m.co" },
                    new List<string> { "David","David2@m.co","David3@m.co" },
                    new List<string> { "David","David1@m.co","David2@m.co" }
                },
                new List<IList<string>> {
                    new List<string> { "David","David0@m.co","David1@m.co","David2@m.co","David3@m.co","David4@m.co","David5@m.co" }
                }
            }
        };
    }
}
