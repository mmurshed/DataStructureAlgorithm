using System;
namespace Algorithm.DynamicProgramming.Micellaneous
{
    // https://www.geeksforgeeks.org/dynamic-programming-set-13-cutting-a-rod/
    /*
     * Given a rod of length n inches and an array of prices that contains 
     * prices of all pieces of size smaller than n. Determine the maximum value
     * obtainable by cutting up the rod and selling the pieces. For example, if
     * length of the rod is 8 and the values of different pieces are given as 
     * following, then the maximum obtainable value is 22 (by cutting in two 
     * pieces of lengths 2 and 6)
     * 
     * length   | 1   2   3   4   5   6   7   8  
     * -----------------------------------------
     * price    | 1   5   8   9  10  17  17  20
     * 
     * And if the prices are as following, then the maximum obtainable value is 
     * 24 (by cutting in eight pieces of length 1)
     * 
     * length   | 1   2   3   4   5   6   7   8  
     * -----------------------------------------
     * price    | 3   5   8   9  10  17  17  20
     * 
     * A naive solution for this problem is to generate all configurations of 
     * different pieces and find the highest priced configuration. This solution
     * is exponential in term of time complexity. Let us see how this problem 
     * possesses both important properties of a Dynamic Programming (DP) 
     * Problem and can efficiently solved using Dynamic Programming.
     * 
     * 1) Optimal Substructure: 
     * We can get the best price by making a cut at different positions and 
     * comparing the values obtained after a cut. We can recursively call the 
     * same function for a piece obtained after a cut.
     * 
     * Let cutRoad(n) be the required (best possible price) value for a rod of 
     * length n. cutRod(n) can be written as following.
     * 
     * cutRod(n) = max(price[i] + cutRod(n-i-1)) for all i in {0, 1 .. n-1}
     * 
     * 2) Overlapping Subproblems
     * Following is simple recursive implementation of the Rod Cutting problem.
     * The implementation simply follows the recursive structure mentioned above.
     * 
     * Considering the above implementation, following is recursion tree for a 
     * Rod of length 4.
     * 
     * cR() ---> cutRod()
     * 
     *                        cR(4)
     *             _____________|__________________
     *            /             |          |       |
     *          cR(3)           cR(2)    cR(1)   cR(0)
     *          /_______        |____      |
     *         /    |   \       |    \     |
     *      cR(2) cR(1) cR(0)  cR(1) cR(0) cR(0)
     *     /   |    |           |   
     *  cR(1) cR(0) cR(0)      cR(0)
     *  /
     * cR(0)
     * 
     * In the above partial recursion tree, cR(2) is being solved twice. We can
     * see that there are many subproblems which are solved again and again. 
     * Since same suproblems are called again, this problem has Overlapping 
     * Subprolems property. So the Rod Cutting problem has both properties 
     * (see this and this) of a dynamic programming problem. Like other typical 
     * Dynamic Programming(DP) problems, recomputations of same subproblems can 
     * be avoided by constructing a temporary array val[] in bottom up manner.
    */
    public class CuttingRod
    {
        int CutRodNaive(int[] values, int n)
        {
            if (n <= 0)
                return 0;

            int maxValue = Int32.MinValue;
            for (int i = 1; i <= n; i++)
            {
                maxValue = Math.Max(maxValue, values[i] + CutRodNaive(values, n - i));
            }

            return maxValue;
        }

        int CutRodMemo(int[] values, int n)
        {
            int[] maxValues = new int[n];

            return CutRodMemo(values, n, maxValues);
        }

        int CutRodMemo(int[] values, int n, int[] maxValues)
        {
            if (n <= 0)
                return 0;
            if (maxValues[n] != 0)
                return maxValues[n];

            maxValues[n] = Int32.MinValue;

            for (int i = 1; i <= n; i++)
            {
                maxValues[n] = Math.Max(maxValues[n], values[i] + CutRodMemo(values, n - i, maxValues));
            }

            return maxValues[n];
        }

        // O(n^2)
        int CutRodDP(int[] price, int n)
        {
            if (n <= 0)
                return 0;
            int[] dp = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    dp[n] = Math.Max(dp[n], price[i] + dp[i - j - 1]);
                }
            }

            return dp[n];
        }
    
    }
}
