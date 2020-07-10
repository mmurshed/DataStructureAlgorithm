﻿using System;
namespace Algorithm.DynamicProgramming.Knapsack.PartitionProblem
{
    // https://www.geeksforgeeks.org/partition-a-set-into-two-subsets-such-that-the-difference-of-subset-sums-is-minimum/
    /* 
     * Given a set of integers, the task is to divide it into two sets S1 and 
     * S2 such that the absolute difference between their sums is minimum.
     * 
     * If there is a set S with n elements, then if we assume Subset1 has m 
     * elements, Subset2 must have n-m elements and the value of 
     * abs(sum(Subset1) – sum(Subset2)) should be minimum.
     * 
     * Example:
     * 
     * Input:  arr[] = {1, 6, 11, 5} 
     * Output: 1
     * 
     * Explanation:
     * Subset1 = {1, 5, 6}, sum of Subset1 = 12 
     * Subset2 = {11}, sum of Subset2 = 11
     * 
     * This problem is mainly an extension to the Dynamic Programming.
     * 
     * Recursive Solution
     * The recursive approach is to generate all possible sums from all the
     * values of array and to check which solution is the most optimal one.
     * 
     * To generate sums we either include the i’th item in set 1 or don’t 
     * include, i.e., include in set 2.
    */
    public class MinimumPartition
    {
        // Function to find the minimum sum
        int FindMinRecNaive(int[] arr, int i, int sumCalculated, int sumTotal)
        {
            // If we have reached last element.  Sum of one
            // subset is sumCalculated, sum of other subset is
            // sumTotal-sumCalculated.  Return absolute difference
            // of two sums.
            if (i == 0)
                return Math.Abs((sumTotal - sumCalculated) - sumCalculated);


            // For every item arr[i], we have two choices
            // (1) We do not include it first set
            // (2) We include it in first set
            // We return minimum of two choices
            return Math.Min(
                FindMinRecNaive(arr, i - 1, sumCalculated + arr[i - 1], sumTotal),
                FindMinRecNaive(arr, i - 1, sumCalculated,              sumTotal));
        }

        // Returns minimum possible difference between sums
        // of two subsets
        int FindMinNaive(int[] arr, int n)
        {
            // Compute total sum of elements
            int sumTotal = 0;
            for (int i = 0; i < n; i++)
                sumTotal += arr[i];

            // Compute result using recursive function
            return FindMinRecNaive(arr, n, 0, sumTotal);
        }

        /*
         * Time Complexity:
         * All the sums can be generated by either
         * 
         * (1) including that element in set 1.
         * (2) without including that element in set 1.
         * 
         * So possible combinations are :-  
         * arr[0]    (1 or 2)  -> 2 values
         * arr[1]    (1 or 2)  -> 2 values
         * .
         * .
         * arr[n]     (2 or 2)  -> 2 values
         * 
         * So time complexity will be 2*2*..... *2 (For n times), that is O(2^n).
         * 
         * Dynamic Programming
         * The problem can be solved using dynamic programming when the sum of 
         * the elements is not too big. We can create a 2D array dp[n+1][sum+1] 
         * where n is number of elements in given set and sum is sum of all 
         * elements. We can construct the solution in bottom up manner.
         * 
         * The task is to divide the set into two parts. 
         * We will consider the following factors for dividing it. 
         * 
         * Let sum of all the elements is S
         * 
         * Let 
         * 
         * dp[n+1, S+1] = |True, if some subset from 1 to i has sum equal to j
         *                |False, otherwise
         * 
         * i ranges from [1..n]
         * j ranges from [0..(sum of all elements)]
         * 
         * dp[n+1, S+1]  will be True iff
         * 
         * 1) The sum j is achieved including i'th item
         * 2) The sum j is achieved excluding i'th item
         * 
         * To find Minimum sum difference, d, we have to find j
         * such that 
         * Min (S - j*2  : dp[n, j]  == True)
         * 
         * where j varies from 0 to S/2
         * 
         * The idea is, sum of S1 is j and it should be closest to S/2
         * i.e., 2*j should be closest to sum.
        */

        // Returns the minimum value of the difference of the two sets.
        int FindMinDP(int[] a, int n)
        {
            // Calculate sum of all elements
            int S = 0;
            for (int i = 0; i < n; i++)
                S += a[i];

            // Create an array to store results of subproblems
            var dp = new bool[n + 1, S+1];
 
            // Initialize first column as true.
            // 0 sum is possible with all elements.
            for (int i = 0; i <= n; i++)
                dp[i, 0] = true;
         
            // Initialize top row, except dp[0,0], as false.
            // With 0 element, no other sum except 0 is possible
            for (int i = 1; i <= S; i++)
                dp[0, i] = false;
         
            // Fill the partition table in bottom up manner
            for (int i=1; i<=n; i++)
            {
                for (int j=1; j<=S; j++)
                {
                    // If i'th element is excluded
                    dp[i, j] = dp[i - 1, j];

                    // If i'th element is included
                    if (a[i - 1] <= j)
                        dp[i, j] |= dp[i - 1, j - a[i - 1]];
                }
            }

            // Initialize difference of two sums. 
            int d = int.MaxValue;

            // Find the largest j such that dp[n][j]
            // is true where j loops from sum/2 t0 0
            for (int j = S / 2; j >= 0; j--)
            {
                // Find the 
                if (dp[n, j])
                {
                    d = S - 2 * j;
                    break;
                }
            }
            return d;
        }
    }
}
