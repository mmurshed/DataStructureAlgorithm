﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.DynamicProgramming
{
    public class JumpGame2
    {
        // Source: https://leetcode.com/problems/jump-game-ii/description/
        //         https://www.geeksforgeeks.org/minimum-number-of-jumps-to-reach-end-of-a-given-array/

        /*
         * Given an array of non-negative integers, you are initially positioned
         * at the first index of the array.
         * 
         * Each element in the array represents your maximum jump length at that
         * position.
         * 
         * Your goal is to reach the last index in the minimum number of jumps.
         * 
         * For example:
         * Given array A = [2,3,1,1,4]
         * 
         * The minimum number of jumps to reach the last index is 2. (Jump 1 
         * step from index 0 to 1, then 3 steps to the last index.)
         * 
         * Note:
         * You can assume that you can always reach the last index.
        */

        private const int MAX = 99999;
        // O(2^n)
        public static int Jump(int[] A, int index)
        {
            if (index >= A.Length)
                return MAX;
            if (index == A.Length - 1)
                return 0;

            int min = MAX;
            for (int i = 1; i <= A[index]; i++)
            {
                min = Math.Min(min, Jump(A, index + i) + 1);
            }
            return min;
        }

        /* Source: https://leetcode.com/problems/jump-game/solution/
         * 
         * In this method, we build jumps[] array from right to left such that 
         * jumps[i] indicates the minimum number of jumps needed to reach 
         * arr[n-1] from arr[i]. Finally, we return arr[0].
        */
        // Dynamic O(n^2)
        public static int JumpGreedy(int[] A)
        {
            int n = A.Length;
            int[] jumps = new int[n];

            for (int i = n - 2; i >= 0; i--)
            {
                if (A[i] == 0) // Can't reach end from 0
                    jumps[i] = MAX;
                else if (i + A[i] >= n - 1)
                    jumps[i] = 1; // Greedy: we can jump directly from here
                else
                {
                    // Find minimum
                    int min = MAX;
                    int last = Math.Min(n - 1, A[i]);

                    for (int j = i + 1; j <= last; j++)
                    {
                        min = Math.Min(min, jumps[j]);
                    }

                    jumps[i] = Math.Min(MAX, min + 1);
                }
            }
            return jumps[0];
        }
        // Driver program to test to pront printDups
        public static void Test()
        {
            var A = new[] { 1, 3, 6, 3, 2, 3, 6, 8, 9, 5 };
            Console.WriteLine($"{JumpGreedy(A)}");
        }
	}
}
