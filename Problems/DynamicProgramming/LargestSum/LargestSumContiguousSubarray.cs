using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm.DynamicProgramming
{
    public class LargestSumContiguousSubarray
    {
        // Source: https://www.geeksforgeeks.org/largest-sum-contiguous-subarray/

        /*
         * Write an efficient C program to find the sum of contiguous subarray 
         * within a one-dimensional array of numbers which has the largest sum.
         * 
         * _________________________
         * |-2|-3| 4|-1|-2| 1| 5|-3|
         * -------------------------
         *   0  1  2  3  4  5  6  7
         * 
         * Max contiguous subarray: 4, -1, -2, 1, 5 (From 2 to 6)
         * Sum: 7
         * 
         * 
         * Kadane’s Algorithm:
         * Initialize:
         * max = 0
         * current_max = 0
         * 
         * Loop for each element of the array
         * (a) current_max = max_ending_here + a[i]
         * (b) if(current_max < 0)
         *      current_max = 0
         * (c) if(max < current_max)
         *      max = currnet_max
         * 
         * return max
         * 
         * Explanation:
         * Simple idea of the Kadane's algorithm is to look for all positive 
         * contiguous segments of the array (current_max is used for this). 
         * And keep track of maximum sum contiguous segment among all positive 
         * segments (max is used for this). Each time we get a positive 
         * sum compare it with max and update current_max if it is greater
         * than current_max
         * 
         * Lets take the example:
         * {-2, -3, 4, -1, -2, 1, 5, -3}
         * 
         * max = current_max = 0
         * 
         * for i=0,  a[0] =  -2
         *      current_max += (-2)
         *      Set current_max = 0 because current_max < 0
         * 
         * for i=1,  a[1] =  -3
         *      max_ending_here = max_ending_here + (-3)
         *      Set max_ending_here = 0 because max_ending_here < 0
         * 
         * for i=2,  a[2] =  4
         *      max_ending_here = max_ending_here + (4)
         *      max_ending_here = 4
         *      max_so_far is updated to 4 because max_ending_here greater 
         *      than max_so_far which was 0 till now
         * 
         * for i=3,  a[3] =  -1
         *      max_ending_here = max_ending_here + (-1)
         *      max_ending_here = 3
         * 
         * for i=4,  a[4] =  -2
         *      max_ending_here = max_ending_here + (-2)
         *      max_ending_here = 1
         * 
         * for i=5,  a[5] =  1
         *      max_ending_here = max_ending_here + (1)
         *      max_ending_here = 2
         * 
         * for i=6,  a[6] =  5
         *      max_ending_here = max_ending_here + (5)
         *      max_ending_here = 7
         *      max_so_far is updated to 7 because max_ending_here is 
         *      greater than max_so_far
         * 
         * for i=7,  a[7] =  -3
         *      max_ending_here = max_ending_here + (-3)
         *      max_ending_here = 4
        */

        public static int MaxSubArraySum(int[] a)
        {
            int max = int.MinValue;
            int current_max = 0;

            foreach(var n in a)
            {
                current_max += n;

                max = Math.Max(max, current_max);

                // If current max is negative, reset to 0
                current_max = Math.Max(current_max, 0);
            }
            return max;
        }

        public static void Test()
        {
            var a = new int[]{ -2, -3, 4, -1, -2, 1, 5, -3 };
            Console.WriteLine($"Maximum contiguous sum is {MaxSubArraySum(a)}");
        }

        // The following implementation handles the case when all numbers in
        // array are negative.
        public static int MaxSubArraySumAllNegative(int[] a)
        {
            int max = a[0];
            int current_max = a[0];

            foreach(var n in a)
            {
                current_max = Math.Max(n, current_max + n);
                max = Math.Max(max, current_max);
            }
            return max;
        }
    }
}
