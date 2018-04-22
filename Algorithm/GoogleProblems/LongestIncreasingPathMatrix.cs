using System;
namespace DataStructure.GoogleProblems
{
    /*
Given an integer matrix, find the length of the longest increasing path.

From each cell, you can either move to four directions: left, right, up or down. You may NOT move diagonally or move outside of the boundary (i.e. wrap-around is not allowed).

Example 1:

nums = [
  [9,9,4],
  [6,6,8],
  [2,1,1]
]
Return 4
The longest increasing path is [1, 2, 6, 9].

Example 2:

nums = [
  [3,4,5],
  [3,2,6],
  [2,2,1]
]
Return 4
The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.
    */
    public class LongestIncreasingPathMatrix
    {
        private int n, m; // Matrix dimension
        private int[,] matrix;
        private int[,] dp;
        // Return the length of LIP in 2D matrix
        private int Generate(int i, int j)
        {
            int result = 1;

            if (dp[i, j] >= 0)
                return dp[i, j];

            // Below
            if (i < n - 1 && matrix[i, j] < matrix[i + 1, j])
                result = Math.Max(result, 1 + Generate(i + 1, j));

            // Right
            if (j < m - 1 && matrix[i, j] < matrix[i, j + 1])
                result = Math.Max(result, 1 + Generate(i, j + 1));

            // Above
            if (i > 0 && matrix[i, j] < matrix[i - 1, j])
                result = Math.Max(result, 1 + Generate(i - 1, j));

            // Left
            if (j > 0 && matrix[i, j] < matrix[i, j - 1])
                result = Math.Max(result, 1 + Generate(i, j - 1));

            // Save
            dp[i, j] = result;

            return result;
        }

        public int LongestIncreasingPath(int[,] mat)
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

            int max = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    max = Math.Max(max, Generate(i, j));
                }
            }
            return max;
        }


    }
}
