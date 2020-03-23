using System;
namespace Algorithm.DynamicProgramming
{
    public class SubsetSum
    {
        // https://www.geeksforgeeks.org/dynamic-programming-subset-sum-problem/

        /*
Given a set of non-negative integers, and a value sum, determine if there is a 
subset of the given set with sum equal to given sum.

Examples: set[] = {3, 34, 4, 12, 5, 2}, sum = 9
Output:  True  //There is a subset (4, 5) with sum 9.

Let isSubSetSum(int set[], int n, int sum) be the function to find whether 
there is a subset of set[] with sum equal to sum. n is the number of elements 
in set[].

The isSubsetSum problem can be divided into two subproblems
   a) Include the last element, recur for n = n-1, sum = sum – set[n-1]
   b) Exclude the last element, recur for n = n-1.
If any of the above the above subproblems return true, then return true.

Following is the recursive formula for isSubsetSum() problem.

isSubsetSum(set, n, sum) = isSubsetSum(set, n-1, sum) || 
                           isSubsetSum(set, n-1, sum-set[n-1])
Base Cases:
isSubsetSum(set, n, sum) = false, if sum > 0 and n == 0
isSubsetSum(set, n, sum) = true, if sum == 0 

The above solution may try all subsets of given set in worst case. Therefore 
time complexity of the above solution is exponential. The problem is in-fact 
NP-Complete (There is no known polynomial time solution for this problem).

We can solve the problem in Pseudo-polynomial time using Dynamic programming.
We create a boolean 2D table subset[][] and fill it in bottom up manner. The 
value of subset[i][j] will be true if there is a subset of set[0..j-1] with 
sum equal to i., otherwise false. Finally, we return subset[sum, n]
        */
        public bool IsSubsetSum(int[] array, int i, int x)
        {
            if (x == 0)
                return true;
            if (i == array.Length)
                return false;

            // If first element is greater than x, ignore it
            if (array[i] > x)
                return IsSubsetSum(array, i + 1, x);

            // Otherwise
            // 1. Check excluding the element
            // 2. Check including the element
            return IsSubsetSum(array, i + 1, x) || IsSubsetSum(array, i + 1, x - array[i]);;
        }

        public bool IsSubsetSumDP(int[] array, int x)
        {
            // The value of dp[i, j] is true if there is a
            // dp of arr[0..j-1] with x equal to i
            var dp = new bool[x + 1, array.Length + 1];

            // if x = 0 then the answer is true
            for (int j = 0; j <= array.Length; j++)
                dp[0, j] = true;

            // if x is not 0 but array is empty, answer is false
            for (int i = 1; i <= x; i++)
                dp[i, 0] = false;

            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= array.Length; j++)
                {
                    if (i >= array[j - 1])
                        dp[i, j] = dp[i, j - 1] || dp[i - array[j - 1], j - 1];
                    else
                        dp[i, j] = dp[i, j - 1];
                }
            }

            return dp[x, array.Length];
        }
    }
}
