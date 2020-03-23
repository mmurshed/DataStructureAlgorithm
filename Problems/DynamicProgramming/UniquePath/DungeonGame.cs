using System;
namespace Algorithm.DynamicProgramming.UniquePath
{
	public class DungeonGame
    {
		// https://www.geeksforgeeks.org/minimum-positive-points-to-reach-destination/
		int minInitialPoints(int[,] points)
        {
			int m = points.GetLength(0);
			int n = points.GetLength(1);
            // dp[i][j] represents the minimum initial points player
            // should have so that when starts with cell(i, j) successfully
            // reaches the destination cell(m-1, n-1)
            var dp = new int[m, n];

            // Base case
            dp[m - 1, n - 1] = points[m - 1, n - 1] > 0 ? 1 : Math.Abs(points[m - 1, n - 1]) + 1;

			// Fill last row and last column as base to fill entire table
			for (int i = m - 2; i >= 0; i--)
			{
				dp[i, n - 1] = Math.Max(dp[i + 1, n - 1] - points[i, n - 1], 1);
			}

			for (int j = n - 2; j >= 0; j--)
			{
				dp[m - 1, j] = Math.Max(dp[m - 1, j + 1] - points[m - 1, j], 1);
			}

			// fill the table in bottom-up fashion
			for (int i = m - 2; i >= 0; i--)
			{
				for (int j = n - 2; j >= 0; j--)
				{
					int min_points_on_exit = Math.Min(dp[i + 1, j], dp[i, j + 1]);
					dp[i, j] = Math.Max(min_points_on_exit - points[i, j], 1);
				}
			}

			return dp[0, 0];
		}
		// http://codesniper.blogspot.com/2015/03/174-dungeon-game-leetcode.html
        /*
Using the example given above, obviously, the knight must be at least 6 hp before 
he enter the princess grid,if the knight came from the upside grid[1][2], 
he must have at least 5 hp to ensure he can save the princess, while if the 
knight came from the left side grid[1][2], the knight need to have at least 1 
hp to save the princess. For grid[1][1], it has two options, either go to its 
right, or go downwards, if it moves to right, the minimum hp is max(5+10,1)=15,
on the other hand if it move downwards, the minimum hp is max(1+10,1)=11, so 
the minimum hp before he enter this grid and can still save the princess is Math.min(15,11)=11. 

Summary:The minimum hp for right column is hp[i-1][j]= max(hp[i][j]-dungeon[i-1][j], 1).

For bottom row, hp[i][j-1]=max(hp[i][j]-dungeon[i][j-1], 1).
For all others, hp[i-1][j-1]= min(max(hp[i][j-1]-dungeon[i-1][j-1], 1), max(hp[i-1][j]-dungeon[i-1][j-1]));

Similarly, we can use one dimensional array instead of 2-d to calculate the final minimum hp.
Time complexity: O(m*n), extra space used: O(m)
        */
		public int calculateMinimumHP(int[,] dungeon)
		{
			if (dungeon == null || dungeon.GetLength(0) == 0 || dungeon.GetLength(1) == 0) return 1;
			int m = dungeon.GetLength(0);
			int n = dungeon.GetLength(1);

			var hp = new int[n];

			hp[n - 1] = Math.Max(1, 1 - dungeon[m - 1, n - 1]);

			for (int j = n - 2; j >= 0; j--)
			{
				hp[j] = Math.Max(1, hp[j + 1] - dungeon[m - 1, j]);
			}

			for (int i = m - 2; i >= 0; i--)
			{
				hp[n - 1] = Math.Max(1, hp[n - 1] - dungeon[i, n - 1]);
				for (int j = n - 2; j >= 0; j--)
				{
					hp[j] = Math.Max(1, Math.Min(hp[j], hp[j + 1]) - dungeon[i, j]);
				}
			}
			return hp[0];
		}  

		public int calculateMinimumHP2(int[,] dungeon)
        {
            if (dungeon == null || dungeon.GetLength(0) == 0 || dungeon.GetLength(1) == 0) return 1;
            int m = dungeon.GetLength(0);
            int n = dungeon.GetLength(1);

            var hp = new int[m, n];

			hp[m - 1, n - 1] = Math.Max(1, 1 - dungeon[m - 1, n - 1]);

			for (int i = n - 2; i >= 0; i--)
            {
                hp[i, 0] = Math.Max(1, hp[i + 1, 0] - dungeon[m - 1, i]);
            }

            for (int j = n - 2; j >= 0; j--)
            {
                hp[0, j] = Math.Max(1, hp[0, j + 1] - dungeon[m - 1, j]);
            }

            for (int i = m - 2; i >= 0; i--)
            {
                hp[i, n - 1] = Math.Max(1, hp[i, n - 1] - dungeon[i, n - 1]);
                for (int j = n - 2; j >= 0; j--)
                {
					int min_on_exit = Math.Min(hp[i + 1, j], hp[i, j + 1]);
					hp[i, j] = Math.Max(1, min_on_exit - dungeon[i, j]);
                }
            }
            return hp[0, 0];
        }  
	
	}
}
