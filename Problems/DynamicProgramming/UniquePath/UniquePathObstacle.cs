using System;
namespace Algorithm.DynamicProgramming.UniquePath
{
	// https://www.geeksforgeeks.org/unique-paths-in-a-grid-with-obstacles/
	/*
Given a grid of size m * n, let us assume you are starting at (1, 1) and your goal is to reach (m, n). At any instance, if you are on (x, y), you can either go to (x, y + 1) or (x + 1, y).

Now consider if some obstacles are added to the grids. How many unique paths would there be?

An obstacle and empty space are marked as 1 and 0 respectively in the grid.

Examples:

Input: [[0, 0, 0],
        [0, 1, 0],
        [0, 0, 0]]
Output : 2
There is only one obstacle in the middle.

We have discussed a problem to count the number of unique paths in a Grid when no obstacle was present in the grid. But here the situation is quite different. While moving through the grid, we can get some obstacles which we can not jump and that way to reach the bottom right corner is blocked.
The most efficient solution to this problem can be achieved using dynamic programming. Like every dynamic problem concept, we will not recompute the subproblems. A temporary 2D matrix will be constructed and value will be stored using the bottom up approach.

Approach
- Create a 2D matrix of same size of the given matrix to store the results.
- Traverse through the created array row wise and start filling the values in it.
- If an obstacle is found, set the value to 0.
- For the first row and column, set the value to 1 if obstacle is not found.
- Set the sum of the right and the upper values if obstacle is not present at that corresponding position in the given matirx
- Return the last value of the created 2d matrix
    */
	public class UniquePathObstacle
	{
		public int UniquePathsWithObstacles(int[,] A)
		{
			int m = A.GetLength(0);
			int n = A.GetLength(1);

			// create a 2D-matrix and initializing with value 0
			var paths = new int[m, n];

			// initializing the left corner if no obstacle there
			if (A[0, 0] == 0)
				paths[0, 0] = 1;

			// initializing first column of the 2D matrix
			for (int i = 1; i < m; i++)
			{
				// If not obstacle
				if (A[i, 0] == 0)
					paths[i, 0] = paths[i - 1, 0];
			}


			// initializing first row of the 2D matrix
			for (int j = 1; j < n; j++)
			{
				// If not obstacle
				if (A[0, j] == 0)
					paths[0, j] = paths[0, j - 1];
			}

			for (int i = 1; i < m; i++)
			{
				for (int j = 1; j < n; j++)
				{
					// If current cell is not obstacle
					if (A[i, j] == 0)
						paths[i, j] = paths[i - 1, j] + paths[i, j - 1];
				}
			}


			// returning the corner value of the matrix
			return paths[m - 1, n - 1];
		}

		// http://codesniper.blogspot.com/2015/03/63-unique-paths-ii-leetcode.html
        /*
This problem add a little twist to the previous one. 62. Unique Path
But clearly, it is not hard to know, that at the obstacle points, the possible paths would be 0, and nothing else need to be changed in the code.
Time complexity: O(m*n), Extra space: O(n)
        */
		public int uniquePathsWithObstacles(int[,] obstacleGrid)
		{
			if (obstacleGrid == null || obstacleGrid.GetLength(0) == 0 || obstacleGrid.GetLength(1) == 0) return 0;
			int m = obstacleGrid.GetLength(0);
			int n = obstacleGrid.GetLength(1);

			int[] res = new int[n];
			res[0] = 1;

			for (int i = 0; i < m; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (obstacleGrid[i, j] == 1)
					{
						res[j] = 0;
					}
					else if (j != 0)
					{
                        res[j] += res[j - 1];
					}
				}
			}

			return res[n - 1];
		}
	}
           
}
