using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Backtracking
{
    public class KnightsTour
    {
        /*
         * Source: https://www.geeksforgeeks.org/backtracking-set-1-the-knights-tour-problem/
         *
         * Backtracking is an algorithmic paradigm that tries different 
         * solutions until finds a solution that “works”. Problems which are 
         * typically solved using backtracking technique have following property
         * in common. These problems can only be solved by trying every possible
         * configuration and each configuration is tried only once. A Naive 
         * solution for these problems is to try all configurations and output
         * a configuration that follows given problem constraints. Backtracking
         * works in incremental way and is an optimization over the Naive 
         * solution where all possible configurations are generated and tried.
         * 
         * For example, consider the following Knight’s Tour problem.
         * The knight is placed on the first block of an empty board and, moving
         * according to the rules of chess, must visit each square exactly once.
         * 
         * Path followed by Knight to cover all the cells
         * 
         * Following is chessboard with 8 x 8 cells. Numbers in cells indicate
         * move number of Knight.
         * 
         * _________________________
         * | 0|59|38|33|30|17| 8|63|
         * -------------------------
         * |37|34|31|60| 9|62|29|16|
         * -------------------------
         * |58| 1|36|39|32|27|18| 7|
         * -------------------------
         * |35|48|41|26|61|10|15|28|
         * -------------------------
         * |42|57| 2|49|40|23| 6|19|
         * -------------------------
         * |47|50|45|54|25|20|11|14|
         * -------------------------
         * |56|43|52| 3|22|13|24| 5|
         * -------------------------
         * |51|46|55|44|53| 4|21|12|
         * -------------------------
         * 
         * Let us first discuss the Naive algorithm for this problem and then 
         * the Backtracking algorithm.
         * 
         * Naive Algorithm for Knight’s tour
         * The Naive Algorithm is to generate all tours one by one and check if 
         * the generated tour satisfies the constraints.
         * 
         * while there are untried tours
         * { 
         *      generate the next tour 
         *      if this tour covers all squares 
         *      { 
         *          print this path;
         *      }
         * }
         * 
         * Backtracking works in an incremental way to attack problems. 
         * Typically, we start from an empty solution vector and one by one add 
         * items (Meaning of item varies from problem to problem. In context of
         * Knight’s tour problem, an item is a Knight’s move). When we add an 
         * item, we check if adding the current item violates the problem 
         * constraint, if it does then we remove the item and try other 
         * alternatives. If none of the alternatives work out then we go to 
         * previous stage and remove the item added in the previous stage. If 
         * we reach the initial stage back then we say that no solution exists.
         * If adding an item doesn’t violate constraints then we recursively add
         * items one by one. If the solution vector becomes complete then we 
         * print the solution.
         * 
         * Backtracking Algorithm for Knight’s tour
         * Following is the Backtracking algorithm for Knight’s tour problem.
         * 
         * If all squares are visited 
         *      print the solution
         * Else
         *      a) Add one of the next moves to solution vector and recursively 
         *      check if this move leads to a solution. (A Knight can make maximum 
         *      eight moves. We choose one of the 8 moves in this step).
         * 
         *      b) If the move chosen in the above step doesn't lead to a solution
         *      then remove this move from the solution vector and try other 
         *      alternative moves.
         * 
         *      c) If none of the alternatives work then return false (Returning false 
         *      will remove the previously added item in recursion and if false is 
         *      returned by the initial call of recursion then "no solution exists" )
         * 
         * Following are implementations for Knight’s tour problem. It prints 
         * one of the possible solutions in 2D matrix form. Basically, the 
         * output is a 2D 8*8 matrix with numbers from 0 to 63 and these numbers
         * show steps made by Knight. 
        */

        private const int SIZE = 8;

        /// <summary>
        /// A utility function to check if i,j are valid indexes for N* N chessboard
        /// </summary>
        /// <returns><c>true</c>, if safe was ised, <c>false</c> otherwise.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="solution">Sol.</param>
        bool IsValid(int x, int y, int[,] solution)
        {
            return (x >= 0 && x < SIZE && y >= 0 && y < SIZE && solution[x, y] == -1);
        }

        /// <summary>
        /// A utility function to print solution matrix sol[N, N]
        /// </summary>
        /// <param name="solution">Sol.</param>
        void printSolution(int[,] solution)
        {
            for (int x = 0; x < SIZE; x++)
            {
                for (int y = 0; y < SIZE; y++)
                    Console.Write($" {solution[x, y]} ");
                Console.WriteLine();
            }
        }

        // xMove[] and yMove[] define next move of Knight.
        // xMove[] is for next value of x coordinate
        // yMove[] is for next value of y coordinate

        /*
         * As we know The Knight moves in an L shape in any direction. We can 
         * say that it either moves two squares sideways and then one square up
         * or down, or two squares up or down, and then one square sideways.
         * 
         * Based on that knight can move up to max 8 directions thats why we 
         * have taken xMove[8] yMove[8].
         * int xMove[8] = { 2, 1, -1, -2, -2, -1, 1, 2 };
         * int yMove[8] = { 1, 2, 2, 1, -1, -2, -2, -1 };
         * 
         * Value of these array depends upon that which direction Knight can move 
         * like 
         * 1. go down and right // row + 2, column + 1
         * 2. go right and down // row + 1, column + 2
         * 3. go right and up // row - 1, column + 2 
         * 4. go up and right //row - 2, column + 1
         * 5. go up and left // row - 2, column - 1
         * 6. go left and up //row - 1, column - 2
         * 7. go left and down //row + 1, column - 2
         * 8. go down and left //row + 2, column - 1
         * 
         * It is optimized moves/values sequence otherwise it will take more 
         * than an half hour (based on the computer speed) to solve this puzzle.
        */
        private readonly int[] xMove = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };
        private readonly int[] yMove = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };


        /// <summary>
        /// This function solves the Knight Tour problem using
        /// Backtracking.This function mainly uses solveKTUtil()
        /// to solve the problem.It returns false if no complete
        /// tour is possible, otherwise return true and prints the tour.
        /// 
        /// Please note that there may be more than one solutions,
        /// this function prints one of the feasible solutions.
        /// </summary>
        /// <returns><c>true</c>, if kt was solved, <c>false</c> otherwise.</returns>
        bool SolveKingsTour()
        {
            var solution = new int[SIZE, SIZE];

            // Initialization of solution matrix
            for (int x = 0; x < SIZE; x++)
                for (int y = 0; y < SIZE; y++)
                    solution[x, y] = -1;

            // Since the Knight is initially at the first block
            solution[0, 0] = 0;

            // Start from 0,0 and explore all tours using solveKTUtil()
            if (SolveKingsTour(0, 0, 1, solution) == false)
            {
                Console.Write("Solution does not exist");
                return false;
            }
            else
                printSolution(solution);

            return true;
        }

        /// <summary>
        /// A recursive utility function to solve Knight Tour problem
        /// </summary>
        /// <returns><c>true</c>, if KTU til was solved, <c>false</c> otherwise.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="movei">Movei.</param>
        /// <param name="solution">Sol.</param>
        /// <param name="xMove">X move.</param>
        /// <param name="yMove">Y move.</param>
        bool SolveKingsTour(int x, int y, int movei, int[,] solution)
        {
            int k, next_x, next_y;
            if (movei == SIZE * SIZE)
                return true;

            // Try all next moves from the current coordinate x, y
            for (k = 0; k < xMove.Length; k++)
            {
                next_x = x + xMove[k];
                next_y = y + yMove[k];
                if (IsValid(next_x, next_y, solution))
                {
                    solution[next_x, next_y] = movei;
                    if (SolveKingsTour(next_x, next_y, movei + 1, solution) == true)
                        return true;
                    else
                        solution[next_x, next_y] = -1;// backtracking
                }
            }

            return false;
        }

    }
}
