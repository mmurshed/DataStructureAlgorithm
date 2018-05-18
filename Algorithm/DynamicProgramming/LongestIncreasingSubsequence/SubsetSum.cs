using System;
namespace Algorithm.DynamicProgramming
{
    public class SubsetSum
    {
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
