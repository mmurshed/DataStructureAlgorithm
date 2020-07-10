using System;
namespace Algorithm.DynamicProgramming.UniquePath
{
	public class DungeonGame
    {
		// https://www.geeksforgeeks.org/minimum-positive-points-to-reach-destination/
		/*
		 * Given a grid with each cell consisting of positive, negative or no 
		 * points i.e, zero points. We can move across a cell only if we have 
		 * positive points ( > 0 ). Whenever we pass through a cell, points in 
		 * that cell are added to our overall points. We need to find minimum 
		 * initial points to reach cell (m-1, n-1) from (0, 0).
		 * 
		 * Constraints :
		 * - From a cell (i, j) we can move to (i+1, j) or (i, j+1).
		 * - We cannot move from (i, j) if your overall points at (i, j) is <= 0.
		 * - We have to reach at (n-1, m-1) with minimum positive points i.e., > 0.
		 * 
		 * Example:
		 * 
		 * Input: points[m, n] = { {-2, -3,   3}, 
		 *                         {-5, -10,  1},
		 *                         {10,  30, -5} };
		 * Output: 7
		 * Explanation: 
		 * 7 is the minimum value to reach destination with positive throughout
		 * the path. Below is the path.
		 * 
		 *     (0,0) -> (0,1) -> (0,2) -> (1, 2) -> (2, 2)
		 *  7 +  -2  -> 5-3   ->  2+3  ->  5+1   ->  6-5  = 1 (Win)     
		 * 
		 * We start from (0, 0) with 7, we reach(0, 1) 
		 * with 5, (0, 2) with 2, (1, 2) with 5, (2, 2)
		 * with and finally we have 1 point.
		 * We needed greater than 0 points at the end.
		 * 
		 * We can solve this problem through bottom-up table filling dynamic 
		 * programing technique.
		 * 
		 * To begin with, we should maintain a 2D array dp of the same size as 
		 * the grid, where dp[i, j] represents the minimum points that 
		 * guarantees the continuation of the journey to destination before 
		 * entering the cell (i, j). It’s but obvious that dp[0, 0] is our 
		 * final solution. Hence, for this problem, we need to fill the table 
		 * from the bottom right corner to left top.
		 * 
		 * Now, let us decide minimum points needed to leave cell (i, j) 
		 * (remember we are moving from bottom to up). There are only two paths
		 * to choose: (i+1, j) and (i, j+1). Of course we will choose the cell 
		 * that the player can finish the rest of his journey with a smaller 
		 * initial points.
		 * 
		 * Therefore we have: min_points = min(dp[i+1, j], dp[i, j+1])
		 * 
		 * Now we know how to compute min_points, but we need to fill 
		 * the table dp[,] to get the solution in dp[0, 0].
		 * 
		 * How to compute dp[i, j]?
		 * The value of dp[i, j] can be written as below.
		 * 
		 * dp[i, j] = max(min_points – p[i, j], 1)
		 * 
		 * Let us see how above expression covers all cases.
		 * 
		 * If points[i, j] == 0, then nothing is gained in this cell;
		 * the player can leave the cell with the same points as he enters the 
		 * room with, i.e. dp[i, j] = min_points.
		 * 
		 * If points[i, j] < 0, then the player must have points greater than 
		 * min_points before entering (i, j) in order to compensate for
		 * the points lost in this cell. The minimum amount of compensation is 
		 * –p[i, j], so we have 
		 * 
		 * dp[i, j] = min_points – p[i, j].
		 * 
		 * If p[i, j] > 0, then the player could enter (i, j) with points
		 * as little as min_points – p[i, j]. since he could gain 
		 * p[i, j] points in this cell. However, the value of 
		 * min_points - p[i, j] might drop to 0 or below in 
		 * this situation. When this happens, we must clip the value to 1 in 
		 * order to make sure dp[i, j] stays positive:
		 * 
		 * dp[i, j] = max(min_points – p[i, j], 1).
		 * 
		 * Finally return dp[0, 0] which is our answer.
		 */
		int minInitialPoints(int[,] p)
        {
			int m = p.GetLength(0);
			int n = p.GetLength(1);
            // dp[i, j] represents the minimum initial points player
            // should have so that when starts with cell(i, j) successfully
            // reaches the destination cell(m-1, n-1)
            var dp = new int[m, n];

            // Base case
            dp[m - 1, n - 1] = p[m - 1, n - 1] > 0 ? 1 : 1-p[m - 1, n - 1];

			// last column must have 1 pt if next cell is positive
			// at least the value otherwise
			for (int i = m - 2; i >= 0; i--)
			{
				dp[i, n - 1] = Math.Max(dp[i + 1, n - 1] - p[i, n - 1], 1);
			}

			// last row must have 1 pt if next cell is positive
			// at least the value otherwise
			for (int j = n - 2; j >= 0; j--)
			{
				dp[m - 1, j] = Math.Max(dp[m - 1, j + 1] - p[m - 1, j], 1);
			}

			// fill the table in bottom-up fashion
			for (int i = m - 2; i >= 0; i--)
			{
				for (int j = n - 2; j >= 0; j--)
				{
					int min_points = Math.Min(dp[i + 1, j], dp[i, j + 1]);
					dp[i, j] = Math.Max(min_points - p[i, j], 1);
				}
			}

			return dp[0, 0];
		}
		// http://codesniper.blogspot.com/2015/03/174-dungeon-game-leetcode.html
        /* 
         * Using the example given above, obviously, the knight must be at least
         * 6 hp before he enter the princess grid,if the knight came from the 
         * upside grid[1, 2], he must have at least 5 hp to ensure he can save 
         * the princess, while if the knight came from the left side grid[1, 2],
         * the knight need to have at least 1 hp to save the princess. 
         * 
         * For grid[1, 1], it has two options, either go to its right, or go d
         * ownwards, if it moves to right, the minimum hp is max(5+10,1)=15,
         * on the other hand if it move downwards, the minimum hp is 
         * max(1+10,1)=11, so the minimum hp before he enter this grid and can 
         * still save the princess is Math.min(15,11)=11. 
         * 
         * Summary: The minimum hp for right column is
         * hp[i-1, j] = max(hp[i, j] - dungeon[i-1, j], 1).
         * 
         * For bottom row, hp[i, j-1] = max(hp[i, j] - dungeon[i, j-1], 1).
         * 
         * For all others, hp[i-1, j-1] = min(
         *      max(hp[i, j-1] - dungeon[i-1, j-1], 1),
         *      max(hp[i-1, j] - dungeon[i-1, j-1]))
         *      
         * Similarly, we can use one dimensional array instead of 2-d to 
         * calculate the final minimum hp.
         * 
         * Time complexity: O(mn), extra space used: O(m)
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
