using System;
namespace Algorithm.DynamicProgramming
{
    // https://www.geeksforgeeks.org/find-the-longest-path-in-a-matrix-with-given-constraints/
    /*
Given a n*n matrix where all numbers are distinct, find the maximum length 
path (starting from any cell) such that all cells along the path are in 
increasing order with a difference of 1.

We can move in 4 directions from a given cell (i, j), i.e., we can move to 
(i+1, j) or (i, j+1) or (i-1, j) or (i, j-1) with the condition that the 
adjacent cells have a difference of 1.

Example:

Input:  mat[][] = {{1, 2, 9}
                   {5, 3, 8}
                   {4, 6, 7}}
Output: 4
The longest path is 6-7-8-9. 

The idea is simple, we calculate longest path beginning with every cell. Once 
we have computed longest for all cells, we return maximum of all longest paths.
One important observation in this approach is many overlapping subproblems.
Therefore this problem can be optimally solved using Dynamic Programming.
    */
    public class LongestPathInMatrix
    {
        // Returns length of the longest path beginning with mat[i][j].
        // This function mainly uses lookup table dp[n][n]
        int FindLongestFromACell(int i, int j, int[,] mat, int[,] dp)
        {
            int n = mat.GetLength(0);
            // Base case
            if (i < 0 || i >= n || j < 0 || j >= n)
                return 0;

            // If this subproblem is already solved
            if (dp[i, j] != -1)
                return dp[i, j];

            // Since all numbers are unique and in range from 1 to n*n,
            // there is atmost one possible direction from any cell
            if (j < n - 1 && ((mat[i, j] + 1) == mat[i, j + 1]))
            {
                dp[i, j] = 1 + FindLongestFromACell(i, j + 1, mat, dp);
                return dp[i, j];
            }

            if (j > 0 && (mat[i, j] + 1 == mat[i, j - 1]))
            {
                dp[i, j] = 1 + FindLongestFromACell(i, j - 1, mat, dp);
                return dp[i, j];
            }

            if (i > 0 && (mat[i, j] + 1 == mat[i - 1, j]))
            {
                dp[i, j] = 1 + FindLongestFromACell(i - 1, j, mat, dp);
                return dp[i, j];
            }

            if (i < n - 1 && (mat[i, j] + 1 == mat[i + 1, j]))
            {
                dp[i, j] = 1 + FindLongestFromACell(i + 1, j, mat, dp);
                return dp[i, j];
            }

            // If none of the adjacent fours is one greater
            dp[i, j] = 1;
            return dp[i, j];
        }

        // Returns length of the longest path beginning with any cell
        int FindLongestOverAll(int[,] mat)
        {
            int result = 1;  // Initialize result

            // Create a lookup table and fill all entries in it as -1
            int n = mat.GetLength(0);
            var dp = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    dp[i, j] = -1;

            // Compute longest path beginning from all cells
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dp[i, j] == -1)
                        FindLongestFromACell(i, j, mat, dp);

                    //  Update result if needed
                    result = Math.Max(result, dp[i, j]);
                }
            }

            return result;
        }
    }
}
