using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Backtracking
{
    public class Sudoku
    {
        /*
         * Source: https://www.geeksforgeeks.org/backtracking-set-7-suduku/
         * 
         * Given a partially filled 9×9 2D array ‘grid[9][9]’, the goal is to 
         * assign digits (from 1 to 9) to the empty cells so that every row, 
         * column, and subgrid of size 3×3 contains exactly one instance of the 
         * digits from 1 to 9.
         * 
         * Naive Algorithm
         * The Naive Algorithm is to generate all possible configurations of 
         * numbers from 1 to 9 to fill the empty cells. Try every configuration 
         * one by one until the correct configuration is found.
         * 
         * Backtracking Algorithm
         * Like all other Backtracking problems, we can solve Sudoku by one by 
         * one assigning numbers to empty cells. Before assigning a number, we 
         * check whether it is safe to assign. We basically check that the same
         * number is not present in current row, current column and current 3X3
         * subgrid. After checking for safety, we assign the number, and 
         * recursively check whether this assignment leads to a solution or not.
         * If the assignment doesn’t lead to a solution, then we try next number
         * for current empty cell. And if none of number (1 to 9) lead to 
         * solution, we return false.
         * 
         * Find row, col of an unassigned cell
         *      If there is none, return true
         * 
         * For digits from 1 to 9
         * 
         *      a) If there is no conflict for digit at row,col
         *      assign digit to row,col and recursively try fill in rest of grid
         * 
         *      b) If recursion successful, return true
         * 
         *      c) Else, remove digit and try another
         *      If all digits have been tried and nothing worked, return false
        */

        private const int SIZE = 9; // size of Sudoku grid
        private const int UNASSIGNED = 0;

        /// <summary>
        /// Takes a partially filled-in grid and attempts to assign values to
        /// all unassigned locations in such a way to meet the requirements
        /// for Sudoku solution(non-duplication across rows, columns, and boxes)
        /// </summary>
        bool SolveSudoku(int[,] grid)
        {
            // If there is no unassigned location, we are done
            var unassignedLoc = FindUnassignedLocation(grid);
            if (!unassignedLoc.Item1)
            {
                return true; // success!
            }

            int row = unassignedLoc.Item2;
            int col = unassignedLoc.Item3;

            // consider digits 1 to 9
            for (int num = 1; num <= SIZE; num++)
            {
                // if looks promising
                if (IsValid(grid, row, col, num))
                {
                    // make tentative assignment
                    grid[row, col] = num;

                    // return, if success, yay!
                    if (SolveSudoku(grid))
                        return true;

                    // failure, unmake & try again
                    grid[row, col] = UNASSIGNED;
                }
            }
            return false; // this triggers backtracking
        }


        /// <summary>
        /// Searches the grid to find an entry that is still unassigned. If
        /// found, the reference parameters row, col will be set the location
        /// that is unassigned, and true is returned.If no unassigned entries
        /// remain, false is returned.
        /// </summary>
        /// <returns><c>true</c>, if unassigned location was found, <c>false</c> otherwise.</returns>
        Tuple<bool, int, int> FindUnassignedLocation(int[,] grid)
        {
            for (int row = 0; row < SIZE; row++)
                for (int col = 0; col < SIZE; col++)
                    if (grid[row, col] == UNASSIGNED)
                        return new Tuple<bool, int, int>(true, row, col);
            return new Tuple<bool, int, int>(false, -1, -1);
        }

        /// <summary>
        /// Returns a boolean which indicates whether any assigned entry
        /// in the specified row matches the given number.
        /// </summary>
        /// <returns><c>true</c>, if in row was used, <c>false</c> otherwise.</returns>
        /// <param name="grid">Grid.</param>
        /// <param name="row">Row.</param>
        /// <param name="num">Number.</param>
        bool UsedInRow(int[,] grid, int row, int num)
        {
            for (int col = 0; col < SIZE; col++)
                if (grid[row, col] == num)
                    return true;
            return false;
        }

        /// <summary>
        /// Returns a boolean which indicates whether any assigned entry
        /// in the specified column matches the given number.
        /// </summary>
        /// <returns><c>true</c>, if in col was used, <c>false</c> otherwise.</returns>
        /// <param name="grid">Grid.</param>
        /// <param name="col">Col.</param>
        /// <param name="num">Number.</param>
        bool UsedInCol(int[,] grid, int col, int num)
        {
            for (int row = 0; row < SIZE; row++)
                if (grid[row, col] == num)
                    return true;
            return false;
        }

        /// <summary>
        /// Returns a boolean which indicates whether any assigned entry
        /// within the specified 3x3 box matches the given number.
        /// </summary>
        /// <returns><c>true</c>, if in box was used, <c>false</c> otherwise.</returns>
        /// <param name="grid">Grid.</param>
        /// <param name="boxStartRow">Box start row.</param>
        /// <param name="boxStartCol">Box start col.</param>
        /// <param name="num">Number.</param>
        bool UsedInBox(int[,] grid, int boxStartRow, int boxStartCol, int num)
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    if (grid[row + boxStartRow, col + boxStartCol] == num)
                        return true;
            return false;
        }

        /// <summary>
        /// Returns a boolean which indicates whether it will be legal to assign
        /// num to the given row,col location.
        /// </summary>
        /// <returns><c>true</c>, if safe, <c>false</c> otherwise.</returns>
        /// <param name="grid">Grid.</param>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
        /// <param name="num">Number.</param>
        bool IsValid(int[,] grid, int row, int col, int num)
        {
            // Check if 'num' is not already placed in current row,
            // current column and current 3x3 box
            return !UsedInRow(grid, row, num) &&
                   !UsedInCol(grid, col, num) &&
                   !UsedInBox(grid, row - row % 3, col - col % 3, num);
        }

        /// <summary>
        /// A utility function to print grid
        /// </summary>
        /// <param name="grid">Grid.</param>
        void printGrid(int[,] grid)
        {
            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                    Console.Write($"{grid[row, col]}");
                Console.WriteLine();
            }
        }

        /* Driver Program to test above functions */
        public void Test()
        {
            // 0 means unassigned cells
            var grid = new[,]
            {
                {3, 0, 6, 5, 0, 8, 4, 0, 0},
                {5, 2, 0, 0, 0, 0, 0, 0, 0},
                {0, 8, 7, 0, 0, 0, 0, 3, 1},
                {0, 0, 3, 0, 1, 0, 0, 8, 0},
                {9, 0, 0, 8, 6, 3, 0, 0, 5},
                {0, 5, 0, 0, 9, 0, 6, 0, 0},
                {1, 3, 0, 0, 0, 0, 2, 5, 0},
                {0, 0, 0, 0, 0, 0, 0, 7, 4},
                {0, 0, 5, 2, 0, 6, 3, 0, 0}
            };
            if (SolveSudoku(grid) == true)
                printGrid(grid);
            else
                Console.WriteLine("No solution exists");

        }

    }
}
