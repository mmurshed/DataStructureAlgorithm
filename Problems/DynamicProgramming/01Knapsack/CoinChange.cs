using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm.DynamicProgramming
{
    public class CoinChange
    {
        // Source: https://www.geeksforgeeks.org/dynamic-programming-set-7-coin-change/

        /*
         * Given a value N, if we want to make change for N cents, and we have 
         * infinite supply of each of S = { S1, S2, .. , Sm} valued coins, 
         * how many ways can we make the change? The order of coins doesn’t matter.
         * 
         * For example, for N = 4 and S = {1,2,3}, there are four solutions: 
         * {1,1,1,1},{1,1,2},{2,2},{1,3}. So output should be 4. For N = 10 
         * and S = {2, 5, 3, 6}, there are five solutions: {2,2,2,2,2}, 
         * {2,2,3,3}, {2,2,6}, {2,3,5} and {5,5}. So the output should be 5.
         * 
         * 1. Optimal Substructure
         * To count total number solutions, we can divide all set solutions in two sets.
         * 1. Solutions that do not contain mth coin (or Sm).
         * 2. Solutions that contain at least one Sm.
         * 
         * Let count(S[], m, n) be the function to count the number of solutions,
         * then it can be written as sum of count(S[], m-1, n) and count(S[], m, n-Sm).
         * 
         * Therefore, the problem has optimal substructure property as the 
         * problem can be solved using solutions to subproblems.
         * 
         * 2. Overlapping Subproblems
         * Following is a simple recursive implementation of the Coin Change 
         * problem. The implementation simply follows the recursive structure 
         * mentioned above.
         * 
         * It should be noted that the above function computes the same 
         * subproblems again and again. See the following recursion tree for 
         * S = {1, 2, 3} and n = 5.
         * 
         * The function C({1}, 3) is called two times. If we draw the complete 
         * tree, then we can see that there are many subproblems being called 
         * more than once.
         * 
         * C() --> count()
                             C({1,2,3}, 5)
                            --------------
                           /             \    
                         /                 \                  
             C({1,2,3}, 2)                 C({1,2}, 5)
            /       \                      /      \         
           /         \                    /         \   
C({1,2,3}, -1)  C({1,2}, 2)        C({1,2}, 3)    C({1}, 5)
               /     \             /     \           /     \
              /       \           /       \         /        \
     C({1,2},0)  C({1},2)   C({1,2},1) C({1},3)    C({1}, 4)  C({}, 5)
                   / \     / \        / \         /     \         
                  /   \   /   \      /   \       /       \  
                .      .  .     .   .     .   C({1}, 3) C({}, 4)
                                               / \ 
                                              /   \   
                                             .      .
         * Since same suproblems are called again, this problem has Overlapping 
         * Subprolems property. So the Coin Change problem has both properties 
         * (see this and this) of a dynamic programming problem. Like other 
         * typical Dynamic Programming(DP) problems, recomputations of same 
         * subproblems can be avoided by constructing a temporary array 
         * table[][] in bottom up manner.
        */

        // Returns the count of ways we can 
        // sum S[0...m-1] coins to get sum n
        // Naive: O(n!)
        int CoinChangeCount(int[] S, int m, int n)
        {
            // If n is 0 then there is 1 solution 
            // (do not include any coin)
            if (n == 0)
                return 1;

            // If n is less than 0 then no 
            // solution exists
            if (n < 0)
                return 0;

            // If there are no coins and n 
            // is greater than 0, then no
            // solution exist
            if (m <= 0 && n >= 1)
                return 0;

            // count is sum of solutions
            // 1. including S[m-1]
            // 2. excluding S[m-1]
            return 
                CoinChangeCount(S, m - 1, n) +  // Excluding S[m-1]
                CoinChangeCount(S, m, n - S[m - 1]); // Including S[m-1]
        }

        // Dynamic: O(n^2)
        int CoinChangeCountDynamic(int[] coins, int m, int n)
        {
            // We need n+1 rows as the table is constructed in bottom up 
            // manner using the base case 0 value case (n = 0)
            var table = new int[n + 1, m];

            // Fill the enteries for 0 value case (n = 0)
            for (int i = 0; i < m; i++)
                table[0, i] = 1;

            // Fill rest of the table entries in bottom up manner  
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // Count of solutions including coins[j]
                    int x = (i - coins[j] >= 0) ? table[i - coins[j], j] : 0;
                    // Count of solutions excluding S[j]
                    int y = (j >= 1) ? table[i, j - 1] : 0;
                    // total count
                    table[i, j] = x + y;
                }
            }
            return table[n, m - 1];
        }
	}
}
