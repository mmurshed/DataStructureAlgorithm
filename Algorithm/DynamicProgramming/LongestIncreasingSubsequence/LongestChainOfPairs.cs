using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.DynamicProgramming
{
    public class LongestChainOfPairs
    {
        // Source: https://www.geeksforgeeks.org/dynamic-programming-set-20-maximum-length-chain-of-pairs/

        /*
         * You are given n pairs of numbers. In every pair, the first number is 
         * always smaller than the second number. A pair (c, d) can follow 
         * another pair (a, b) if b < c. Chain of pairs can be formed in this 
         * fashion. Find the longest chain which can be formed from a given set 
         * of pairs.
         * 
         * For example, if the given pairs are {{5, 24}, {39, 60}, {15, 28}, 
         * {27, 40}, {50, 90} }, then the longest chain that can be formed is 
         * of length 3, and the chain is {{5, 24}, {27, 40}, {50, 90}}
         * 
         * 
         * This problem is a variation of standard Longest Increasing 
         * Subsequence problem. Following is a simple two step process.
         * 
         * 1) Sort given pairs in increasing order of first (or smaller) element.
         * 
         * 2) Now run a modified LIS process where we compare the second element
         * of already finalized LIS with the first element of new LIS being constructed.
        */

        // Structure for a pair
        public struct Pair
        {
            public int a;
            public int b;
            public Pair(int a, int b)
            {
                this.a = a;
                this.b = b;
            }
        }

        // This function assumes that arr[] is sorted in increasing order
        // according the first (or smaller) values in pairs.
        public static int MaxChainLength(Pair[] arr)
        {
            // Initialize MCL (max chain length) values for all indexes
            var mcl = Enumerable.Repeat(1, arr.Length).ToArray(); 

            // Compute optimized chain length values in bottom up manner
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i].a > arr[j].b)
                    {
                        mcl[i] = Math.Max(mcl[i], mcl[j] + 1);
                    }
                }
            }

            // mcl now stores the maximum chain length ending with pair i
            return mcl.Max();
        }


        // Driver program to test above function
        public static void Test()
        {
            Pair[] arr = new []
            {
                new Pair(5, 24),
                new Pair(15, 25),
                new Pair(27, 40),
                new Pair(50, 60)
            };
            Console.WriteLine($"Length of maximum size chain is {MaxChainLength(arr)}");

        }
	}
}
