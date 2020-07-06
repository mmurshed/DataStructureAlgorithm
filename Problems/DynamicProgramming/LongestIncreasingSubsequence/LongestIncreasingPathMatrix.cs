using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.DynamicProgramming
{
    public class LongestIncreasingPathMatrix
    {
        // Source: https://www.geeksforgeeks.org/longest-increasing-path-matrix/

        /* Given a matrix of N rows and M columns. From m[i, j], we can move to
         * m[i+1, j], if m[i+1, j] > m[i, j], or can move to m[i, j+1] 
         * if m[i, j+1] > m[i, j]. 
         * 
         * The task is print longest path length if we start from (0, 0).
         * 
         * Examples:
         * 
         * Input : N = 4, M = 4
         * m[,] = { { 1, 2, 3, 4 },
         *          { 2, 2, 3, 4 },
         *          { 3, 2, 3, 4 },
         *          { 4, 5, 6, 7 } };
         * 
         * Output : 7
         * 
         * Longest path is 1 2 3 4 5 6 7.
         * 
         * Input : N = 2, M =2
         * m[,] = { { 1, 2 },
         *          { 3, 4 } };
         * 
         * Output :3
         * 
         * Longest path is either 1 2 4 or 1 3 4.
         * 
         * The idea is to use dynamic programming. Maintain the 2D matrix, 
         * dp[,], where dp[i, j] store the value of length of longest 
         * increasing sequence for sub matrix starting from ith row and 
         * j-th column.
         * 
         * Let the longest increasing sub sequence values for m[i+1, j] and 
         * m[i, j+1] be known already as v1 and v2 respectively. Then the value 
         * for m[i, j] will be max(v1, v2) + 1.
         * 
         * We can start from m[n-1, m-1] as base case with length of longest 
         * increasing sub sequence be 1, moving upwards and leftwards updating 
         * the value of cells. Then the LIP value for cell m[0, 0] will be 
         * the answer.     
         * 
         * Optimal Substructure:
         * 1. LIP(i, j) = 1 if i or j is out of bounds
         * 2. LIP(i, j) = max (1, 1 + LIP (i + 1, j), 1 + LIP (i, j + 1)
         *              when mat[i, j] < mat[i + 1, j]
         *              and  mat[i, j] < mat[i, j + 1] respectively
        */

        private int n, m; // Matrix dimension
        private int[,] matrix;
        private int[,] dp;
        // Return the length of LIP in 2D matrix
        private int Generate(int i, int j)
        {
            // If value is already calculated.
            if (dp[i, j] >= 0)
                return dp[i, j];

            int result = 0;

            // If reach bottom left cell, return 1.
            if (i == n - 1 && j == m - 1)
            {
                dp[i, j] = 1;
                return dp[i, j];
            }

            // If value greater than the cell below.
            if (matrix[i, j] < matrix[i + 1, j])
                result = Math.Max(result, 1 + Generate(i + 1, j));

            // If value greater than the right cell.
            if (matrix[i, j] < matrix[i, j + 1])
                result = Math.Max(result, 1 + Generate(i, j + 1));

            // save
            dp[i, j] = result;

            return dp[i, j];
        }

        public int Generate(int[,] mat)
        {
            n = mat.GetLength(0);
            m = mat.GetLength(1);
            this.matrix = mat;
            dp = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dp[i, j] = -1;
                }
            }
   
            return Generate(0, 0);
        }
	}
}
