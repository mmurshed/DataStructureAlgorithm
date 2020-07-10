using System;
namespace Algorithm.DynamicProgramming
{
    /* BUY AND SELL AT MOST ONCE
     * 
     * Given an array arr[] of integers, find out the difference between any two
     * elements such that larger element appears after the smaller number in arr[].
     * 
     * Examples: If array is [2, 3, 10, 6, 4, 8, 1] then returned value should 
     * be 8 (Diff between 10 and 2). If array is [ 7, 9, 5, 6, 3, 2 ] then 
     * returned value should be 2 (Diff between 7 and 9)
     * 
    */
    public class BuySellStocksOnce
    {
        // O(n^2)
        public static int BuySellStocksA(int[] a)
        {
            int min = int.MaxValue;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    int diff = a[j] - a[i];
                    if (diff < min)
                        min = diff;
                }
            }

            return min;
        }

        // O(n)
        public static int BuySellStocksB(int[] prices)
        {
            if (prices.Length == 0)
                return 0;
            int min = prices[0];
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                min = Math.Min(min, prices[i]);
                profit = Math.Max(prices[i] - min, profit);
            }
            return profit;
        }


    }
}
