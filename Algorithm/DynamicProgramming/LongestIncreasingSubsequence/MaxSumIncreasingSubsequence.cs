using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm.DynamicProgramming
{
    public class MaxSumIncreasingSubsequence
    {
        // Source: https://www.geeksforgeeks.org/dynamic-programming-set-14-maximum-sum-increasing-subsequence/

        /*
         * Given an array of n positive integers. Write a program to find the 
         * sum of maximum sum subsequence of the given array such that the 
         * intgers in the subsequence are sorted in increasing order. For 
         * example, if input is {1, 101, 2, 3, 100, 4, 5}, then output should 
         * be 106 (1 + 2 + 3 + 100), if the input array is {3, 4, 5, 10}, then 
         * output should be 22 (3 + 4 + 5 + 10) and if the input array is 
         * {10, 5, 4, 3}, then output should be 10
         * 
         * This problem is a variation of standard Longest Increasing 
         * Subsequence (LIS) problem. We need a slight change in the Dynamic 
         * Programming solution of LIS problem. All we need to change is to use 
         * sum as a criteria instead of length of increasing subsequence.
        */

        // Dynamic Programming O(n^2)
        int GenerateDynamic(int[] arr)
        {
            var msis = new int[arr.Length];


            // Initialize msis values for all indexes
            arr.CopyTo(msis, 0);

            // Compute maximum sum values in bottom up manner
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        msis[i] = Math.Max(msis[i], msis[j] + arr[i]);
                    }
                }
            }

            // Pick maximum of all msis values
            return msis.Max();
        }
	}
}
