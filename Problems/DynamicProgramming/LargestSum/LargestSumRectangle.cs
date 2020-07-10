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

        public static (int, int, int) MaxSumArrayAllNegative(int[] a)
        {
            // Special Case: When all numbers in arr[] are negative
            int maxSum = a[0];
            int start = 0, finish = 0;

            // Find the maximum element in array
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > maxSum)
                {
                    maxSum = a[i];
                    start = finish = i;
                }
            }

            return (maxSum, start, finish);
        }
        // Implementation of Kadane's algorithm for 1D array. The function 
        // returns the maximum sum and stores starting and ending indexes of the 
        // maximum sum subarray at addresses pointed by start and finish pointers 
        // respectively.
        public static (int, int, int) MaxSumArray(int[] a)
        {
            int sum = 0;
            int maxSum = int.MinValue;

            // Just some initial value to check for all negative values case
            int start = -1, finish = -1;
            // local variable
            int local_start = 0;

            for (int i = 0; i < a.Length; ++i)
            {
                sum += a[i];
                if (sum < 0)
                {
                    sum = 0;
                    local_start = i + 1;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    start = local_start;
                    finish = i;
                }
            }

            // There is at-least one non-negative number
            if (finish != -1)
                return (maxSum, start, finish);

            // Special Case: When all numbers in arr[] are negative
            return MaxSumArrayAllNegative(a);
        }

        // The main function that finds maximum sum rectangle in M[,]
        public static (int, int, int, int, int) MaxSum(int[,] M)
        {
            // Variables to store the final output
            int max = int.MinValue;
            int left = -1, right = -1, top = -1, bottom = -1;

            int m = M.GetLength(0);
            int n = M.GetLength(1);

            // Set the left column
            for (int l = 0; l < n; ++l)
            {
                var col = new int[m];

                // Set the right column for the left column set by outer loop
                for (int r = l; r < n; ++r)
                {
                    // Calculate sum between current left and right for every row 'i'
                    for (int i = 0; i < m; ++i)
                    {
                        col[i] += M[i, r];
                    }

                    // Find the maximum sum subarray in temp[]. The kadane() 
                    // function also sets values of start and finish.  So 'sum' is 
                    // sum of rectangle between (start, left) and (finish, right) 
                    //  which is the maximum sum with boundary columns strictly as
                    //  left and right.
                    var (sum, start, end) = MaxSumArray(col);

                    // Compare sum with maximum sum so far. If sum is more, then 
                    // update maxSum and other output values
                    if (sum > max)
                    {
                        max = sum;
                        left = l;
                        right = r;
                        top = start;
                        bottom = end;
                    }
                }
            }

            return (max, top, left, bottom, right);
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
            var (sum, top, left, bottom, right) = MaxSum(M);
            Console.WriteLine($"Max: {sum} Top: {top} Left: {left} Bottom: {bottom} Right: {right}.");
        }
    }
}
