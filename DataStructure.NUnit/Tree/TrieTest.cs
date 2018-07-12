using NUnit.Framework;
using System;
using DataStructure.Tree;
using System.Collections.Generic;

namespace DataStructure.NUnit.Tree
{
    [TestFixture()]
    public class TrieTest
    {
        [TestCaseSource(nameof(RemoveTestCases))]
        public void RemoveTest(string[] data, string[] rems, string[] expected)
        {
            // Arrange
            var tree = new Trie();

            foreach(string str in data)
            {
                tree.Insert(str);
            }

            // Act
            foreach (string rem in rems)
            {
                tree.Remove(rem);
            }

            var result = tree.GetAll();

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        static readonly object[] RemoveTestCases =
        {
            new object[] {
                new string[] {"SAN", "SANFRANCISCO", "SANTAMONICA"},
                new string[] {"SAN"},
                new string[] {"SANFRANCISCO", "SANTAMONICA"}
            },
            new object[] {
                new string[] {"SAN", "SANFRANCISCO", "SANTAMONICA"},
                new string[] {"SAP"},
                new string[] {"SAN", "SANFRANCISCO", "SANTAMONICA"}
            },
            new object[] {
                new string[] {"SAN", "SANFRANCISCO", "SANTAMONICA"},
                new string[] {"SANF"},
                new string[] {"SAN", "SANFRANCISCO", "SANTAMONICA"}
            },
            new object[] {
                new string[] {"SAN", "SANFRANCISCO", "SANTAMONICA"},
                new string[] {"SANFRANCISCO"},
                new string[] {"SAN", "SANTAMONICA"}
            },
            new object[] {
                new string[] {"SAN", "SANFRANCISCO", "SANTAMONICA"},
                new string[] {"SANTAMONICA", "SANFRANCISCO", "SAN"},
                new string[] {}
            },
            new object[] {
                new string[] {"SAN", "SANFRANCISCO", "SANTAMONICA"},
                new string[] {"SANTAMONICA", "SANFRANCISCO", "SAP"},
                new string[] {"SAN"}
            },
            new object[] {
                new string[] {},
                new string[] {"SANTAMONICA", "SANFRANCISCO", "SAN"},
                new string[] {}
            }
        };

        [TestCaseSource(nameof(InsertTestCases))]
        public void InsertTest(string[] data)
        {
            // Arrange
            var tree = new Trie();

            var expected = new List<string>();
            foreach (string str in data)
            {
                // Act
                expected.Add(str);
                tree.Insert(str);
                var results = tree.GetAll();
                // Assert
                CollectionAssert.AreEqual(expected, results);
            }

        }

        static readonly object[] InsertTestCases =
        {
            new object[] {
                new string[] {"SAN", "SANFRANCISCO", "SANTAMONICA"},
            }
        };

        [TestCaseSource(nameof(FindTestCases))]
        public void FindTest(string[] data, string[] finds, bool[] expected)
        {
            // Arrange
            var tree = new Trie();

            foreach (string str in data)
            {
                tree.Insert(str);
            }

            for (int i = 0; i < finds.Length; i++)
            {
                // Act
                var result = tree.Find(finds[i]); 
                // Assert
                Assert.AreEqual(expected[i], result);
            }


        }

        static readonly object[] FindTestCases =
        {
            new object[] {
                new string[] {"SAN", "SANFRANCISCO", "SANTAMONICA"},
                new string[] {"SAN", "SANFRAN", "SANTA"},
                new bool[]   {true, false, false},
            }
        };

    }
}
