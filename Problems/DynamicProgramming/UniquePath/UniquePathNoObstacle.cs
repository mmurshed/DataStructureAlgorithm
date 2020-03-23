using System;
namespace Algorithm.DynamicProgramming.UniquePath
{
	// https://www.geeksforgeeks.org/print-all-possible-paths-from-top-left-to-bottom-right-of-a-mxn-matrix/
	// https://leetcode.com/problems/unique-paths/description/
    /*
The problem is to print all the possible paths from top left to bottom right of a mXn matrix with the constraints that from each cell you can either move only to right or down.

Examples :

Input : 1 2 3
        4 5 6
Output : 1 4 5 6
         1 2 5 6
         1 2 3 6

Input : 1 2 
        3 4
Output : 1 2 4
         1 3 4
The algorithm is a simple recursive algorithm, from each cell first print all paths by going down and then print all paths by going right. Do this recursively for each cell encountered.
        */
    public class UniquePathNoObstacle
    {
		/* mat:  Pointer to the starting of mXn matrix
           i, j: Current position of the robot (For the first call use 0,0)
           m, n: Dimentions of given the matrix
           pi:   Next index to be filed in path array
           *path[0..pi-1]: The path traversed by robot till now (Array to hold the
                          path need to have space for at least m+n elements) */
        private void printAllPathsUtil(int[,] mat, int i, int j, int[,] path, int pi)
        {
			int m = mat.GetLength(0);
			int n = mat.GetLength(1);

            // Reached the bottom of the matrix so we are left with
            // only option to move right
            if (i == m - 1)
            {
                for (int k = j; k < n; k++)
                    path[pi, k - j] = mat[m, k];
    //            for (int l = 0; l < pi + n - j; l++)
				//	Console.Write(path[pi, l] + " ");
				//Console.WriteLine();
                return;
            }

            // Reached the right corner of the matrix we are left with
            // only the downward movement.
            if (j == n - 1)
            {
                for (int k = i; k < m; k++)
                    path[pi, k - i] = mat[m, j];
    //            for (int l = 0; l < m - i; l++)
				//	Console.Write(path[pi, l] + " ");
				//Console.WriteLine();
                return;
            }
            
            // Add the current cell to the path being generated
            path[pi, 0] = mat[i, j];

            // Print all the paths that are possible after moving down
            printAllPathsUtil(mat, i + 1, j, path, pi + 1);

            // Print all the paths that are possible after moving right
            printAllPathsUtil(mat, i, j + 1, path, pi + 1);

            // Print all the paths that are possible after moving diagonal
            // printAllPathsUtil(mat, i+1, j+1, m, n, path, pi + 1);
        }

        // The main function that prints all paths from top left to bottom right
        // in a matrix 'mat' of size mXn
        public void printAllPaths(int[,] mat)
        {
			int m = mat.GetLength(0);
            int n = mat.GetLength(1);

			var path = new int[m, n];
            printAllPathsUtil(mat, 0, 0, path, 0);
        }


		// http://codesniper.blogspot.com/2015/03/62-unique-paths-leetcode.html
        /*
Clearly, for the top row, res[0][j]=res[0][j-1], because there is only one 
possible path which is from left to right. Similarly for the left column, 
res[i][0]=res[i-1][0]. All other points in the grid hold res[i][j]=res[i-1][j]+ res[i][j-1].

According to this recursion analysis, we can calculate the unique paths to any point in the grid. 

As we only need to find the the unique paths to the "Finish" point, we can use
one dimension array to iterativly update the information. Eg. res[i][j]=res[i-1][j]+ 
res[i][j-1] => res[j](current loop with i)=res[j](last loop with i-1)+res[j-1],.

Time complexity O(m*n) Extra space: O(n)
        */
		public int uniquePaths(int m, int n)
        {
            int[] res = new int[n];
            res[0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    res[j] += res[j - 1];
                }
            }
            return res[n - 1];
        }
	}
}
