using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm.DynamicProgramming
{
    public class ZeroOneKnapsack
    {
        // Source: https://www.geeksforgeeks.org/knapsack-problem/

        /* 
         * Given weights and values of n items, put these items in a knapsack 
         * of capacity W to get the maximum total value in the knapsack. 
         * 
         * In other words, given two integer arrays val[0..n-1] and wt[0..n-1] 
         * which represent values and weights associated with n items 
         * respectively.
         * 
         * Also given an integer W which represents knapsack 
         * capacity.
         * 
         * Find out the maximum value subset of val[] such that sum 
         * of the weights of this subset is smaller than or equal to W. You 
         * cannot break an item, either pick the complete item, or don’t pick 
         * it (0-1 property).
         * 
         * Example:
         * value = {60, 100, 120}
         * weight = {10, 20, 30}
         * W = 50
         * 
         * Weight = 20 + 10, Value = 100 +  60 = 160
         * Weight = 30 + 10, Value = 120 +  60 = 180
         * Weight = 30 + 20, Value = 120 + 100 = 220
         * Weight = 30 + 20 + 10 > 50
         * 
         * Solution: 220
         * 
         * A simple solution is to consider all subsets of items and calculate 
         * the total weight and value of all subsets. Consider the only subsets 
         * whose total weight is smaller than W. From all such subsets, 
         * pick the maximum value subset.
         * 
         * 1) Optimal Substructure:
         * To consider all subsets of items, there can be two cases for every 
         * item the item is,
         *      1. included in the optimal subset.
         *      2. NOT included in the optimal set.
         * 
         * Therefore, the maximum value that can be obtained from n items is 
         * max of following two values.
         * 1. Maximum value obtained by n-1 items and W weight (excluding nth item).
         * 2. Value of nth item plus maximum value obtained by n-1 items and 
         *  W minus weight of the nth item (including nth item).
         * 
         * If weight of nth item is greater than W, then the nth item cannot be
         * included and case 1 is the only possibility.
         * 
         * 2) Overlapping Subproblems
         * Following is recursive implementation that simply follows the 
         * recursive structure mentioned above.
         * 
         * It should be noted that the naive function computes the same 
         * subproblems again and again. See the following recursion tree, 
         * K(1, 1) is being evaluated twice. Time complexity of this naive 
         * recursive solution is exponential (2^n).
         * 
         * In the following recursion tree, K() refers to knapSack().  The two 
         * parameters indicated in the following recursion tree are n and W.  
         * The recursion tree is for following sample inputs.
         * wt[] = {1, 1, 1}, W = 2, val[] = {10, 20, 30}
         * 
         * K(n, W)
                       K(3, 2)
                   --------------
                  /              \ 
                 /                \               
            K(2,2)                  K(2,1)
          /       \                  /    \ 
         /         \                /      \
       K(1,2)      K(1,1)        K(1,1)     K(1,0)
      /    \       /     \         /   \
     /      \     /       \       /     \
K(0,2)  K(0,1)  K(0,1)  K(0,0)  K(0,1)   K(0,0)

         * Recursion tree for Knapsack capacity 2 units and 3 items of 1 unit weight.
         * 
         * Since suproblems are evaluated again, this problem has Overlapping 
         * Subprolems property. So the 0-1 Knapsack problem has both properties 
         * of a dynamic programming problem. Like other typical Dynamic 
         * Programming(DP) problems, recomputations of same subproblems can 
         * be avoided by constructing a temporary array K[][] in bottom up 
         * manner.
        */

        // Naive O(2^n)
        int KnapSackNaive(int W, int[] wt, int[] val, int n)
        {
            // Base Case
            if (n == 0 || W == 0)
                return 0;

            // If weight of the nth item is more than Knapsack capacity W, then
            // this item cannot be included in the optimal solution
            if (wt[n - 1] > W)
                return KnapSackNaive(W, wt, val, n - 1);

            // Return the maximum of two cases: 
            // 1. nth item included 
            // 2. not included
            return
            Math.Max(
                val[n - 1] + KnapSackNaive(W - wt[n - 1], wt, val, n - 1), // 1. nth item included 
                KnapSackNaive(W, wt, val, n - 1) // 2. not included
            );
        }

        // Returns the maximum value that can be put in a knapsack of capacity W
        // Dynamic O(n^2)
        int KnapSackDynamic(int W, int[] wt, int[] val)
        {
            int n = val.Length;
            var dp = new int[n + 1, W + 1];

            // Build table K[,] in bottom up manner
            for (int i = 0; i <= n; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if (i==0 || w==0)
                        dp[i, w] = 0;
                    else if (wt[i - 1] > w)
                        dp[i, w] = dp[i - 1, w]; // Weight exceeded
                    else
                        dp[i, w] = Math.Max(
                            val[i - 1] + dp[i - 1, w - wt[i - 1]], // 1. nth Item included
                            dp[i - 1, w]); // 2. not included
                }
            }
            return dp[n, W];
        }
	}
}
