using System;
using System.Collections.Generic;

namespace Algorithm.DynamicProgramming
{
    /*
Given n balloons, indexed from 0 to n-1. Each balloon is painted with a number on it represented by array nums. You are asked to burst all the balloons. If the you burst balloon i you will get nums[left] * nums[i] * nums[right] coins. Here left and right are adjacent indices of i. After the burst, the left and right then becomes adjacent.

Find the maximum coins you can collect by bursting the balloons wisely.

Note: 
(1) You may imagine nums[-1] = nums[n] = 1. They are not real therefore you can not burst them.
(2) 0 ≤ n ≤ 500, 0 ≤ nums[i] ≤ 100

Example:

Given [3, 1, 5, 8]

Return 167

    nums = [3,1,5,8] --> [3,5,8] -->   [3,8]   -->  [8]  --> []
   coins =  3*1*5      +  3*5*8    +  1*3*8      + 1*8*1   = 167

    */
    public class BurstBalloons
    {
        public int MaxCoins(int[] nums)
        {
            var numse = new int[nums.Length + 2];
            numse[0] = numse[numse.Length - 1] = 1;
            int n = numse.Length;
            var m = new int[n, n];

            for (int i = 1; i < n; i++)
            {
                m[i, i] = 0;
                if (i <= nums.Length)
                    numse[i] = nums[i - 1];
            }

            for (int gap = 2; gap < n; gap++)
            {
                for (int i = 0; i < n - gap; i++)
                {
                    int j = i + gap;
                    for (int k = i + 1; k < j; k++)
                    {
                        // cost = cost/scalar multiplications
                        int cost = m[i, k] + m[k, j] + numse[i] * numse[k] * numse[j];
                        if (cost > m[i, j])
                            m[i, j] = cost;
                    }
                }
            }

            return m[0, n - 1];
        }

        private static void PrintMatrix(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write($"{m[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int MaxCoinsNaive(int[] nums)
        {
            var list = new LinkedList<int>();
            for (int i = 0; i < nums.Length; i++)
                list.AddLast(nums[i]);
            return MaxCoinsNaiveRecursive(list);
        }

        public int MaxCoinsNaiveRecursive(LinkedList<int> nums)
        {
            if (nums.Count == 0)
                return 1;
            else if (nums.Count == 1)
                return nums.First.Value;
            else if (nums.Count == 2)
            {
                int n1 = nums.First.Value;
                int n2 = nums.First.Next.Value;
                return Math.Max(n1, n2) * (Math.Min(n1, n2) + 1) ;
            }

            // at this point we have more than three items
            int max = 0;
            var it = nums.First;
            while(it != null)
            {
                int n1 = it.Value;
                int n2 = 1;
                int n3 = 1;

                var it2 = it.Next;
                if (it2 != null)
                {
                    n2 = it2.Value;
                    var it3 = it2.Next;
                    if (it3 != null)
                        n3 = it3.Value;
                }

                int val = n1 * n2 * n3;
                // Pop middle
                if(it2 != null)
                    nums.Remove(it2);
                val = val + MaxCoinsNaiveRecursive(nums);
                max = Math.Max(max, val);

                if (it.Next == null)
                    break;
                // Backtrack
                if (it2 != null)
                    nums.AddAfter(it, it2);
                it = it.Next;
            }
            return max;
        }
    }
}
