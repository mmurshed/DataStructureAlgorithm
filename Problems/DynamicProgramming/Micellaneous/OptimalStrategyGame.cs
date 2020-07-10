using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.DynamicProgramming
{
    public class OptimalStrategyGame
    {
        // Source: https://www.geeksforgeeks.org/dynamic-programming-set-31-optimal-strategy-for-a-game/

        /*
         * Problem statement: Consider a row of n coins of values v1 . . . vn, 
         * where n is even. We play a game against an opponent by alternating 
         * turns. In each turn, a player selects either the first or last coin 
         * from the row, removes it from the row permanently, and receives the 
         * value of the coin. Determine the maximum possible amount of money we
         * can definitely win if we move first.
         * 
         * Note: The opponent is as clever as the user.
         * 
         * Let us understand the problem with few examples:
         * 1. 5, 3, 7, 10 : The user collects maximum value as 15 = (10 + 5)
         * 
         * 2. 8, 15, 3, 7 : The user collects maximum value as 22 = (7 + 15)
         * 
         * Does choosing the best at each move give an optimal solution?
         * 
         * No. In the second example, this is how the game can finish:
         * 
         * 1.
         * a) User chooses 8.
         * b) Opponent chooses 15.
         * c) User chooses 7.
         * d) Opponent chooses 3.
         * Total value collected by user is 15(8 + 7)
         * 
         * 2.
         * a) User chooses 7.
         * b) Opponent chooses 8.
         * c) User chooses 15.
         * d) Opponent chooses 3.
         * Total value collected by user is 22(7 + 15)
         * 
         * So if the user follows the second game state, maximum value can be 
         * collected although the first move is not the best.
         * 
         * There are two choices:
         * 1. The user chooses the ith coin with value Vi: The opponent either 
         * chooses (i+1)th coin or jth coin. The opponent intends to choose the 
         * coin which leaves the user with minimum value.
         * i.e. The user can collect the value Vi + min(F(i+2, j), F(i+1, j-1) )
         * 
         *       |----Opponent---|
         * Vi    Vi+1 Vi+2......Vj-1 Vj
         *            |--Opponent----|
         * User
         * 
         * 
         * 2. The user chooses the jth coin with value Vj: The opponent either 
         * chooses ith coin or (j-1)th coin. The opponent intends to choose the 
         * coin which leaves the user with minimum value.
         * i.e. The user can collect the value Vj + min(F(i+1, j-1), F(i, j-2) )
         * 
         * |----Opponent--|
         * Vi Vi+1......Vj-2 Vj-1   Vj
         *    |---Opponent---|
         *                         User
         * 
         * Following is recursive solution that is based on above two choices. 
         * We take the maximum of two choices.
         * 
         * F(i, j)  represents the maximum value the user can collect from 
         * i'th coin to j'th coin.
         * F(i, j)  = Max(Vi + min( F(i + 2, j    ), F(i + 1, j - 1) ), 
         *                Vj + min( F(i + 1, j - 1), F(i,     j - 2) )) 
         * 
         * Base Cases
         * F(i, j)  = Vi           If j == i
         * F(i, j)  = max(Vi, Vj)  If j == i+1
         * 
         * Why Dynamic Programming?
         * The above relation exhibits overlapping sub-problems. In the above 
         * relation, F(i+1, j-1) is calculated twice.
        */

        // Returns optimal value possible that a player can collect from
        // an array of coins of size n. Note than n must be even
        public static int OptimalStrategyOfGame(int[] a)
        {
            int n = a.Length;
            // Create a table to store solutions of subproblems
            var dp = new int[n, n];

            // Fill table using above recursive formula. Note that the table
            // is filled in diagonal fashion, similar to Min Insert to Form Palindrom
            // https://www.geeksforgeeks.org/minimum-insertions-to-form-a-palindrome-dp-28/
            // from diagonal elements to table[0, n-1] which is the result.
            for (int gap = 0; gap < n; ++gap)
            {
                for (int i = 0, j = gap; j < n; ++i, ++j)
                {
                    // x is F(i+2, j)
                    int x = (i + 2 <= j ? dp[i + 2, j]: 0);

                    // y is F(i+1, j-1)
                    int y = (i + 1 <= j - 1 ? dp[i + 1, j - 1] : 0);

                    // z is F(i, j-2)
                    int z = (i <= j - 2 ? dp[i,     j - 2] : 0);

                    dp[i, j] = Math.Max(a[i] + Math.Min(x, y),
                                        a[j] + Math.Min(y, z));
                }
            }

            return dp[0, n - 1];
        }

        public static void Test()
        {
            var arr1 = new []{ 8, 15, 3, 7 };
            Console.WriteLine($"{OptimalStrategyOfGame(arr1)}");

            var arr2 = new []{ 2, 2, 2, 2 };
            Console.WriteLine($"{OptimalStrategyOfGame(arr2)}");

            var arr3 = new []{ 20, 30, 2, 2, 2, 10 };
            Console.WriteLine($"{OptimalStrategyOfGame(arr3)}");
        }
	}
}
