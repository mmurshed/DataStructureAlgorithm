using System;
using System.Collections.Generic;

namespace Algorithm.DynamicProgramming
{
    // https://www.interviewbit.com/problems/length-of-longest-subsequence/

    /*
     * 
     * Given an array of integers, find the length of longest subsequence which is first increasing then decreasing.

**Example: **

For the given array [1 11 2 10 4 5 2 1]

Longest subsequence is [1 2 10 4 2 1]

Return value 6

 NOTE: You only need to implement the given function. Do not read input, instead use the arguments to the function. Do not print the output, instead return values as specified. Still have a doubt? Checkout Sample Codes for more details. 
    */
    public class LongestIncreasingDecreasingSubsequence
    {
        public int longestSubsequenceLength(List<int> A)
        {
            if(A == null || A.Count == 0)
                return 0;
            int n = A.Count;
            int[] inc = new int[n];
            int[] dec = new int[n];

            inc[0] = 1;
            int max = 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (A[j] < A[i])
                        inc[i] = Math.Max(inc[i], inc[j] + 1);
                }
                max = Math.Max(max, inc[i]);
            }

            dec[n - 1] = 1;
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (A[j] < A[i])
                        dec[i] = Math.Max(dec[i], dec[j] + 1);
                }
                max = Math.Max(max, inc[i]);
                max = Math.Max(max, dec[i+1]);
                max = Math.Max(max, inc[i] + dec[i] - 1);
            }

            return max;
        }
    }
}
