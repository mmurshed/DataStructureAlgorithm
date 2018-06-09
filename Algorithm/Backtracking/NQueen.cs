using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Backtracking
{
    public class NQueen
    {
        /*
         * Source: https://www.geeksforgeeks.org/backtracking-set-3-n-queen-problem/
         * The N Queen is the problem of placing N chess queens on an N×N 
         * chessboard so that no two queens attack each other. For example, 
         * following is a solution for 4 Queen problem.
         * 
         * The expected output is a binary matrix which has 1s for the blocks 
         * where queens are placed. For example following is the output matrix
         * for above 4 queen solution.
         * { 0,  1,  0,  0}
         * { 0,  0,  0,  1}
         * { 1,  0,  0,  0}
         * { 0,  0,  1,  0}
         * 
         * Naive Algorithm
         * Generate all possible configurations of queens on board and print a configuration that satisfies the given constraints.
         * 
         * while there are untried conflagrations
         * {
         *      generate the next configuration
         *      if queens don't attack in this configuration then
         *      {
         *          print this configuration;
         *      }
         * }
         * 
         * Backtracking Algorithm
         * The idea is to place queens one by one in different columns, starting
         * from the leftmost column. When we place a queen in a column, we check
         * for clashes with already placed queens. In the current column, if we 
         * find a row for which there is no clash, we mark this row and column 
         * as part of the solution. If we do not find such a row due to clashes
         * then we backtrack and return false.
         * 
         * 1) Start in the leftmost column
         * 
         * 2) If all queens are placed return true
         * 
         * 3) Try all rows in the current column.  Do following for every tried row.
         * 
         * a) If the queen can be placed safely in this row then mark this [row, 
         * column] as part of the solution and recursively check if placing  
         * queen here leads to a solution.
         * 
         * b) If placing queen in [row, column] leads to a solution then return 
         * true.
         * 
         * c) If placing queen doesn't lead to a solution then umark this [row, 
         * column] (Backtrack) and go to step (a) to try other rows.
         * 
         * 4) If all rows have been tried and nothing worked, return false to 
         * trigger backtracking.
        */

        private static int[,] results;

        public static int[,] PlaceQueens(int grid)
        {
            int[] cols = Enumerable.Repeat(0, grid).ToArray();
            results = new int[grid, grid];
            PlaceQueens(0, cols);
            return results;
        }

        private static void PlaceQueens(int row, int[] cols)
        {
            if(row == cols.Length)
            {
                for (int i = 0; i < cols.Length; i++)
                    results[row, i] = cols[i];
                return;
            }

            for (int col = 0; col < cols.Length; col++)
            {
                if(CheckValid(cols, row, col))
                {
                    cols[row] = col;
                    PlaceQueens(row + 1, cols);
                }
            }
        }

        private static bool CheckValid(int[] cols, int row, int col)
        {
            for (int row2 = 0; row2 < row; row2++)
            {
                int col2 = cols[row2];

                // Queens in the same column
                if (col == col2)
                    return false;

                // Diagonal position
                // Column distance == Row distance
                int colDist = Math.Abs(col2 - col);
                int rowDist = row - row2;
                if (colDist == rowDist)
                    return false;
            }
            return true;
        }

        public static void Test()
        {
            var rs = PlaceQueens(4);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(rs[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
