using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Backtracking
{
    public class NQueenII
    {
        
        public IList<IList<string>> SolveNQueens(int n)
        {
            var cs = new int[n];

            var grid = new char[n][];
            for (int i = 0; i < n; i++)
            {
                grid[i] = new char[n];
                for (int j = 0; j < n; j++)
                {
                    grid[i][j] = '.';
                }
            }

            var results = new List<IList<string>>();

            PlaceQueens(grid, n, 0, cs, results);

            return results;
        }

        private void PlaceQueens(char[][] grid, int n, int r, int[] cs, IList<IList<string>> results)
        {
            if(r == cs.Length)
            {
                var result = new List<string>();
                for (int i = 0; i < n; i++)
                {
                    result.Add(new string(grid[i]));
                }
                results.Add(result);

                return;
            }

            for (int c = 0; c < n; c++)
            {
                if(CheckValid(cs, r, c))
                {
                    cs[r] = c;
                    grid[r][c] = 'Q';
                    PlaceQueens(grid, n, r + 1, cs, results);
                    // Backtrack
                    grid[r][c] = '.';
                }
            }
        }

        private bool CheckValid(int[] cs, int cr, int cc)
        {
            for (int r = 0; r < cr; r++)
            {
                int c = cs[r];

                // Queens in the same column
                if (cc == c)
                    return false;

                // Diagonal position
                // Column distance == Row distance
                int cd = Math.Abs(c - cc);
                int rd = cr - r;
                if (cd == rd)
                    return false;
            }
            return true;
        }

        /*

.Q..
...Q
Q...
..Q.

.QQ.
Q..Q
Q..Q
.QQ.

.Q..
...Q
Q...
..Q.

..Q.
Q...
...Q
.Q..
           */
    }
}
