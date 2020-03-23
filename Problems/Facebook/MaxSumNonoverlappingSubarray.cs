using System;
namespace Algorithm.Facebook
{
    // Maximum Sum of 3 Non-Overlapping Subarrays
    // https://leetcode.com/problems/maximum-sum-of-3-non-overlapping-subarrays/description/

/*
Intuition
It is natural to consider an array W of each interval's sum, where each interval
is the given length K. To create W, we can either use prefix sums, or manage 
the sum of the interval as a window slides along the array.

From there, we approach the reduced problem: Given some array W and an integer 
K, what is the lexicographically smallest tuple of indices 
(i, j, k) with i + K <= j and j + K <= k that maximizes W[i] + W[j] + W[k]?

Algorithm
Suppose we fixed j. We would like to know on the intervals i ∈ [0,j−K] and
k ∈ [j+K, len(W)−1], where the largest value of W[i] (and respectively W[k]) 
occurs first. (Here, first means the smaller index.)

We can solve these problems with dynamic programming. For example, if we 
know that i is where the largest value of W[i] occurs first on [0,5], then 
on [0,6] the first occurrence of the la rgest W[i] must be either i or 6. 

If say, 6 is better, then we set best = 6.

At the end, left[z] will be the first occurrence of the largest value of W[i] 
on the interval i ∈ [0,z], and right[z] will be the same but on the 
interval i ∈ [z,len(W)−1]. This means that for some choice j, the candidate 
answer must be (left[j-K], j, right[j+K]). We take the candidate that 
produces the maximum W[i] + W[j] + W[k].
*/
    public class MaxSumNonoverlappingSubarray
    {
        public int[] MaxSumOfThreeSubarrays(int[] nums, int K)
        {
            var sums = GetSums(nums, K);

            return MaxSumOfSubarrays(sums, K);
        }

        // Sliding window sum
        // [3 4 5 2 3 1], k = 3
        // [0 0 0 0]
        // Sum of 0 thru k-1 = [12 0 0 0]
        // Sum of k thru len-1 = [12 11 10 6]
        private int[] GetSums(int[] nums, int K)
        {
            var sums = new int[nums.Length - K + 1];
            sums[0] = 0;
            for (int i = 0; i < K; i++)
            {
                sums[0] += nums[i];
            }

            for (int i = K; i < nums.Length; i++)
            {
                sums[i - K + 1] = sums[i - K] - nums[i - K] + nums[i];
            }

            return sums;
        }

        // Given [12 11 10 6]
        // Max of range from left  = [0 0 0 0]
        // Max of range from right = [0 1 2 3]
        private int[] MaxOfRange(int[] nums, int start, int end, int step, Func<int, int, bool> greater)
        {
            var max = new int[nums.Length];
            int best = start;
            for (int i = start; i != end; i += step)
            {
                if (greater(nums[i], nums[best]))
                    best = i;
                max[i] = best;
            }
            return max;
        }

        private int[] MaxSumOfSubarrays(int[] W, int K)
        {
            // left[z] will be the first occurrence of the largest value 
            // of W[i] on the interval i ∈ [0, z]
            var leftMax = MaxOfRange(W, 0, W.Length - 1, 1, (x, y) => x > y);

            // right[z] will be the same but on the interval i ∈ [z, len(W)−1]
            var rightMax = MaxOfRange(W, W.Length - 1, 0, -1, (x, y) => x >= y);


            var ans = new int[] { -1, -1, -1 };
            var sum = -1;
            // For some choice j, the candidate answer must be (left[j-K], j, right[j+K]).
            // We take the candidate that produces the maximum W[i] + W[j] + W[k].
            for (int j = K; j < W.Length - K; j++)
            {
                int i = leftMax[j - K];
                int k = rightMax[j + K];
                int newSum = W[i] + W[j] + W[k];
                if (newSum > sum)
                {
                    sum = newSum;
                    ans[0] = i;
                    ans[1] = j;
                    ans[2] = k;
                }
            }

            return ans;
        }

    }
}
