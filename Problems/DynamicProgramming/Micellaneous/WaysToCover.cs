using System;
namespace Algorithm.DynamicProgramming.Micellaneous
{
    // https://www.geeksforgeeks.org/count-number-of-ways-to-cover-a-distance/
    /*
Given a distance ‘dist, count total number of ways to cover the distance with 1, 2 and 3 steps.

Examples :

Input:  n = 3
Output: 4
Below are the four ways
 1 step + 1 step + 1 step
 1 step + 2 step
 2 step + 1 step
 3 step

Input:  n = 4
Output: 7
    */
    public class WaysToCover
    {
        // Returns count of ways to cover 'dist'
        public int CountToCoverNaive(int dist)
        {
            // Base cases
            if (dist < 0) return 0;
            if (dist == 0) return 1;

            // Recur for all previous 3 and add the results
            return CountToCoverNaive(dist - 1) +
                   CountToCoverNaive(dist - 2) +
                   CountToCoverNaive(dist - 3);
        }
        /*
The time complexity of above solution is exponential, a close upper bound is 
O(3^n). If we draw the complete recursion tree, we can observer that many 
subproblems are solved again and again. For example, when we start from n = 6,
we can reach 4 by subtracting one 2 times and by subtracting 2 one times. So
the subproblem for 4 is called twice.

Since same suproblems are called again, this problem has Overlapping Subprolems
property. So min square sum problem has both properties (see this and this) of 
a dynamic programming problem. Like other typical Dynamic Programming(DP) 
problems, recomputations of same subproblems can be avoided by constructing
a temporary array count[] in bottom up manner.
        */
        int CountToCoverDP(int dist)
        {
            var count = new int[dist + 1];

            // Initialize base values. There is one way to cover 0 and 1
            // distances and two ways to cover 2 distance
            count[0] = 1;
            count[1] = 1;
            count[2] = 2;

            // Fill the count array in bottom up manner
            for (int i = 3; i <= dist; i++)
                count[i] = count[i - 1] + count[i - 2] + count[i - 3];

            return count[dist];
        }
    }
}
