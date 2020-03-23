using System;
using System.Collections.Generic;

namespace DataStructure.GoogleProblems
{
    /*
     * Given an unsorted array of integers, find the length of the longest consecutive elements sequence.

For example,
Given [100, 4, 200, 1, 3, 2],
The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.

Your algorithm should run in O(n) complexity.
    */
    public class LongestConsecutiveSeq
    {
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            HashSet<int> hs = new HashSet<int>();
            foreach (int num in nums)
                hs.Add(num);
            int max = 1;
            foreach (int num in hs)
            {
                if (hs.Contains(num + 1) && !hs.Contains(num - 1))
                {
                    int i = num;
                    while (hs.Contains(i))
                    {
                        // hs.Remove(i);
                        i++;
                    }
                    max = Math.Max(max, i - num);
                }
            }
            return max;
        }
    }
}
