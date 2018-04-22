using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.DynamicProgramming
{
    public class LongestIncreasingSubsequence
    {
        // Source: https://www.geeksforgeeks.org/longest-increasing-subsequence/
        //         https://leetcode.com/problems/longest-increasing-subsequence/solution/

        /*
         * The Longest Increasing Subsequence (LIS) problem is to find the 
         * length of the longest subsequence of a given sequence such that all 
         * elements of the subsequence are sorted in increasing order. 
         * For example, the length of LIS for {10, 22, 9, 33, 21, 50, 41, 60, 80}
         * is 6 and LIS is {10, 22, 33, 50, 60, 80}.
         * 
         *  _________________________________________
         * |arr[] | 10 | 22 | 9 | 33 | 50 | 60 | 80 |
         * |LIS   | 1  | 2  |   | 3  | 4  | 5  | 6  |
         *  -----------------------------------------
         * 
         * 
         * Optimal Substructure:
         * Let arr[0..n-1] be the input array and L(i) be the length of the 
         * LIS ending at index i such that arr[i] is the last element of the LIS.
         * 
         * Then, L(i) can be recursively written as:
         * L(i) = 1 + max( L(j) ) where 0 < j < i and arr[j] < arr[i]; or
         * 
         * L(i) = 1, if no such j exists.
         * 
         * To find the LIS for a given array, we need to return max(L(i)) where 0 < i < n.
         * 
         * Thus, we see the LIS problem satisfies the optimal substructure 
         * property as the main problem can be solved using solutions 
         * to subproblems.
        */

        public static int RecursiveNaiveGenerate(int[] A, int n, ref int max)
		{
			if (n == 1) return 1;
			int max_ending_here = 1;
			for (int i = 1; i < n; i++)
			{
				int res = RecursiveNaiveGenerate(A, i, ref max);
				if (A[i - 1] < A[n - 1] && res + 1 > max_ending_here)
					max_ending_here = res + 1;
				max = Math.Max(max, max_ending_here);
			}
			return max_ending_here;
		}

		public static int GenerateNaive(int[] A)
		{
			int max = 1;
			RecursiveNaiveGenerate(A, A.Length, ref max);
			return max;
		}

        // Dynamic Programming O(n^2)
        public int GenerateDynamic(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int[] dp = new int[nums.Length];
            dp[0] = 1;
            int maxans = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                int maxval = 0;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        maxval = Math.Max(maxval, dp[j]);
                    }
                }
                dp[i] = maxval + 1;
                maxans = Math.Max(maxans, dp[i]);
            }
            return maxans;
        }

        //Dynamic Programming with Binary Search
        /*
         * In this approach, we scan the array from left to right. 
         * We also make use of a dp array initialized with all 0's. This dp 
         * array is meant to store the increasing subsequence formed by 
         * including the currently encountered element. While traversing 
         * the nums array, we keep on filling the dp array with the elements 
         * encountered so far. For the element corresponding to the j th index 
         * (nums[j]), we determine its correct position in the dp array
         * (say i th index) by making use of Binary Search (which can be used 
         * since the dp array is storing increasing subsequence) and also insert
         * it at the correct position. An important point to be noted is that 
         * for Binary Search, we consider only that portion of the dp array in 
         * which we have made the updations by inserting some elements at their 
         * correct positions(which remains always sorted).
         * 
         * Thus, only the elements upto the i th index in the dp array can 
         * determine the position of the current element in it. Since, the 
         * element enters its correct position(i) in an ascending order in the 
         * dp array, the subsequence formed so far in it is surely an increasing
         * subsequence. Whenever this position index i becomes equal to the 
         * length of the LIS formed so far(len), it means, we need to update 
         * the len as len = len+1.
         * 
         * Note: dp array does not result in longest increasing subsequence, but
         * length of dp array will give you length of LIS.
         * 
         * Consider the example:
         * input: [0, 8, 4, 12, 2]
         * dp: [0]
         * dp: [0, 8]
         * dp: [0, 4]
         * dp: [0, 4, 12]
         * dp: [0, 2, 12] which is not the longest increasing subsequence, but
         * length of dp array results in length of Longest Increasing Subsequence.
        */
        public int GenerateDynamicBinary(int[] nums)
        {
            var dp = new int[nums.Length];
            int len = 0;
            foreach (int num in nums)
            {
                int i = Array.BinarySearch(dp, 0, len, num);
                // BinarySearch returns the index of the specified value in the
                // specified array, if value is found; otherwise, a negative 
                // number.
                //
                // If value is not found and value is less than one or 
                // more elements in array, the negative number returned is the 
                // bitwise complement of the index of the first element that is 
                // larger than value.
                // 
                // If value is not found and value is greater 
                // than all elements in array, the negative number returned is 
                // the bitwise complement of (the index of the last element plus 1).

                if (i < 0) // Not found
                {
                    i = ~i; // bitwise complement of the index
                }
                dp[i] = num;
            }
            return len;
        }
	}
}
