using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.DynamicProgramming
{
    public class JumpGame
    {
        // Source: https://www.interviewbit.com/problems/jump-game-array/

        /*
         * Given an array of non-negative integers, you are initially positioned
         * at the first index of the array.
         * 
         * Each element in the array represents your maximum jump length at that
         * position.
         * 
         * Determine if you are able to reach the last index.
         * 
         * For example:
         * A = [2,3,1,1,4], return 1 ( true ).
         * 
         * A = [3,2,1,0,4], return 0 ( false ).
         * 
         * Return 0/1 for this problem
        */

        // O(2^n)
        public static int Jump(int[] A, int index)
        {
            if (index >= A.Length)
                return 0;
            if (index == A.Length - 1)
                return 1;

            for (int i = 1; i <= A[index]; i++)
                if(Jump(A, index + i) == 1)
                    return 1;
            return 0;
        }

        /* Source: https://leetcode.com/problems/jump-game/solution/
         * 
         * From a given position, when we try to see if 
         * we can jump to a GOOD position, we only ever use one - the first one 
         * (see the break statement). In other words, the left-most one. If we 
         * keep track of this left-most GOOD position as a separate variable, 
         * we can avoid searching for it in the array. Not only that, but we 
         * can stop using the array altogether.
         * 
         * Iterating right-to-left, for each position we check if there is a 
         * potential jump that reaches a GOOD index (currPosition + 
         * nums[currPosition] >= leftmostGoodIndex). If we can reach a 
         * GOOD index, then our position is itself GOOD. Also, this new GOOD 
         * position will be the new leftmost GOOD index. Iteration continues 
         * until the beginning of the array. If first position is a GOOD index
         * then we can reach the last index from the first position.
         * 
         * To illustrate this scenario, we will use the diagram below, for input
         * array nums = [9, 4, 2, 1, 0, 2, 0]. We write G for GOOD, B for BAD 
         * and U for UNKNOWN. Let's assume we have iterated all the way to 
         * position 0 and we need to decide if index 0 is GOOD. Since index 1 
         * was determined to be GOOD, it is enough to jump there and then be 
         * sure we can eventually reach index 6. It does not matter that 
         * nums[0] is big enough to jump all the way to the last index. 
         * All we need is one way.
         * 
         * Index    0   1   2   3   4   5   6
         * nums     9   4   2   1   0   2   0
         * memo     U   G   B   B   B   G   G
        */
        // Greedy
        public static int JumpGreedy(int[] A, int index)
        {
            int last = A.Length - 1;
            for (int i = last; i >= 0; i++)
                if (i + A[i] >= last)
                    last = i;
            return last == 0 ? 1: 0;
        }
        // Driver program to test to pront printDups
        public static void Test()
        {
            var A = new[] {2, 3, 1, 1, 4};
            Console.WriteLine($"{Jump(A, 0)}");
            var B = new[] {3, 2, 1, 0, 4 };
            Console.WriteLine($"{Jump(B, 0)}");

        }
	}
}
