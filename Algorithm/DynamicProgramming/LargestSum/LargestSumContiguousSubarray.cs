using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm.DynamicProgramming
{
    public class LargestSumRectangle
    {
        // Source: https://www.geeksforgeeks.org/dynamic-programming-set-27-max-sum-rectangle-in-a-2d-matrix/

        /*
         * Given a 2D array, find the maximum sum subarray in it. For example, 
         * in the following 2D array, the maximum sum subarray is highlighted 
         * with blue rectangle and sum of this subarray is 29.
         * 
         * _____________________
         * | 1 | 2 |-1 |-4 |-20|
         * ----▄▄▄▄▄▄▄▄▄▄▄▄▄----
         * |-8 █-3 | 4 | 2 █ 1 |
         * ----█-----------█----
         * | 3 █ 8 |10 | 1 █ 3 |
         * ----█-----------█----
         * |-4 █-1 | 1 | 7 █-6 |
         * ----█▄▄▄▄▄▄▄▄▄▄▄█----
         * 
         * This problem is mainly an extension of Largest Sum Contiguous
         * Subarray for 1D array.
         * 
         * The naive solution for this problem is to check every possible 
         * rectangle in given 2D array. This solution requires 4 nested 
         * loops and time complexity of this solution would be O(n^4).
         * 
         * Kadane’s algorithm for 1D array can be used to reduce the time 
         * complexity to O(n^3). The idea is to fix the left and right columns 
         * one by one and find the maximum sum contiguous rows for every left 
         * and right column pair. We basically find top and bottom row numbers 
         * (which have maximum sum) for every fixed left and right column pair. 
         * To find the top and bottom row numbers, calculate sun of elements in 
         * every row from left to right and store these sums in an array say 
         * temp[]. So temp[i] indicates sum of elements from left to right in 
         * row i. If we apply Kadane’s 1D algorithm on temp[], and get the 
         * maximum sum subarray of temp, this maximum sum would be the maximum 
         * possible sum with left and right as boundary columns. To get the 
         * overall maximum sum, we compare this sum with the maximum sum so far.
        */

        // Implementation of Kadane's algorithm for 1D array. The function 
        // returns the maximum sum and stores starting and ending indexes of the 
        // maximum sum subarray at addresses pointed by start and finish pointers 
        // respectively.
        public static Tuple<int, int, int> kadane(int[] arr)
        {
            // initialize sum, maxSum and
            int sum = 0, maxSum = Int32.MinValue, i;

            // Just some initial value to check for all negative values case
            int start = -1, finish = -1;
            // local variable
            int local_start = 0;

            for (i = 0; i < arr.Length; ++i)
            {
                sum += arr[i];
                if (sum < 0)
                {
                    sum = 0;
                    local_start = i + 1;
                }
                else if (sum > maxSum)
                {
                    maxSum = sum;
                    start = local_start;
                    finish = i;
                }
            }

            // There is at-least one non-negative number
            if (finish != -1)
                return new Tuple<int, int, int>(maxSum, start, finish);

            // Special Case: When all numbers in arr[] are negative
            maxSum = arr[0];
            start = finish = 0;

            // Find the maximum element in array
            for (i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxSum)
                {
                    maxSum = arr[i];
                    start = finish = i;
                }
            }
            return new Tuple<int, int, int>(maxSum, start, finish);
        }

        // The main function that finds maximum sum rectangle in M[,]
        public static Tuple<int, int, int, int, int> findMaxSum(int[,] M)
        {
            // Variables to store the final output
            int maxSum = Int32.MinValue;
            int finalLeft = -1, finalRight = -1, finalTop = -1, finalBottom = -1;

            int left, right, i;

            int row = M.GetLength(0);
            int col = M.GetLength(1);
            var temp = new int[row];
                

            // Set the left column
            for (left = 0; left < col; ++left)
            {
                // Initialize all elements of temp as 0
                for (i = 0; i < row; ++i)
                    temp[i] = 0;

                // Set the right column for the left column set by outer loop
                for (right = left; right < col; ++right)
                {
                    // Calculate sum between current left and right for every row 'i'
                    for (i = 0; i < row; ++i)
                    {
                        temp[i] += M[i, right];
                    }

                    // Find the maximum sum subarray in temp[]. The kadane() 
                    // function also sets values of start and finish.  So 'sum' is 
                    // sum of rectangle between (start, left) and (finish, right) 
                    //  which is the maximum sum with boundary columns strictly as
                    //  left and right.
                    var ret = kadane(temp);
                    int sum = ret.Item1;
                    int start = ret.Item2;
                    int finish = ret.Item3;

                    // Compare sum with maximum sum so far. If sum is more, then 
                    // update maxSum and other output values
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        finalLeft = left;
                        finalRight = right;
                        finalTop = start;
                        finalBottom = finish;
                    }
                }
            }

            // Print final values
            // printf("(Top, Left) (%d, %d)n", finalTop, finalLeft);
            // printf("(Bottom, Right) (%d, %d)n", finalBottom, finalRight);
            // printf("Max sum is: %dn", maxSum);
            return new Tuple<int, int, int, int, int>(maxSum, finalTop, finalLeft, finalBottom, finalRight);
        }

        // Driver program to test above functions
        public static void Test()
        {
            var M = new int[,]
            {
                {1, 2, -1, -4, -20},
                {-8, -3, 4, 2, 1},
                {3, 8, 10, 1, 3},
                {-4, -1, 1, 7, -6}
            };
            var result = findMaxSum(M);
            Console.WriteLine($"Max: {result.Item1} Top: {result.Item2} Left: {result.Item3} Bottom: {result.Item4} Right: {result.Item5}.");
        }
    }
}
