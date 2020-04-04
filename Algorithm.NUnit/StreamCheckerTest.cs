using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithm.NUnit
{
    [TestFixture()]
    public class StreamCheckerTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(string[] words, string stream, bool[] expected)
        {
            // Arrange
            var obj = new Problems.Facebook.StreamChecker(words);
            var results = new bool[stream.Length];

            // Act
            for(int i = 0; i < stream.Length; i++)
                results[i] = obj.Query(stream[i]);

            // Assert
            CollectionAssert.AreEquivalent(expected, results);
        }


        static object[] TestCases =
        {
            //new object[] {
            //    new [] { "cd","f","kl"},
            //    "abcdefghijkl",
            //    new [] {false,false,false,true,false,true,false,false,false,false,false,true}
            //}
            new object[] {
                new [] { "ab","ba","aaab","abab","baa" },
                "aaaaabababbbababbbbababaaabaaa",
                new [] {false,false,false,false,false,true,true,true,true,true,false,false,true,true,true,true,false,false,false,true,true,true,true,true,true,false,true,true,true,false}
            }
                /*
                                            a      a      a      a      a      b     a     b     a     b     b      b      a     b      a     b     b      b      b      a     b      a     b     a     a     a      b     a     a     a
                  Expected: equivalent to < False, False, False, False, False, True, True, True, True, True, False, False, True, True,  True, True, False, False, False, True, True,  True, True, True, True, False, True, True, True, False >
                                But was:  < False, False, False, False, False, True, True, True, True, True, False, False, True, False, True, True, False, False, False, True, False, True, True, True, True, False, True, True, True, False >
                                */

        };
    }
}
