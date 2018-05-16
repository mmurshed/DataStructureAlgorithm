using System;
namespace Algorithm.DynamicProgramming
{
    /*
     * BUY AND SELL K-Transactions
     * 
In share trading, a buyer buys shares and sells on future date. Given stock price of n days, the trader is allowed to make at most k transactions, where new transaction can only start after previous transaction is complete, find out maximum profit that a share trader could have made.

Input:  
Price = [10, 22, 5, 75, 65, 80]
    K = 2
Output:  87
Trader earns 87 as sum of 12 and 75
Buy at price 10, sell at 22, buy at 
5 and sell at 80

Input:  
Price = [12, 14, 17, 10, 14, 13, 12, 15]
    K = 3
Output:  12
Trader earns 12 as sum of 5, 4 and 3
Buy at price 12, sell at 17, buy at 10 
and sell at 14 and buy at 12 and sell
at 15
 
Input:  
Price = [100, 30, 15, 10, 8, 25, 80]
    K = 3
Output:  72
Only one transaction. Buy at price 8 
and sell at 80.

Input:  
Price = [90, 80, 70, 60, 50]
    K = 1
Output:  0
Not possible to earn. 


There are various versions of the problem. If we are allowed to buy and sell only once, then we can use Maximum difference between two elements algorithm. If we are allowed to make at most 2 transactions, we can follow approach discussed here. If we are allowed to buy and sell any number of times, we can follow approach discussed here.

    */
    public class BuySellStocksKTimes
    {
        /*
         *
In this post, we are only allowed to make at max k transactions. The problem can be solve by using dynamic programming.

Let profit[t, i] represent maximum profit using at most t transactions up to day i (including day i). Then the relation is:

profit[t, i] = max(profit[t, i-1], max(price[i] – price[j] + profit[t-1, j]))
          for all j in range [0, i-1]

profit[t][i] will be maximum of –

profit[t][i-1] which represents not doing any transaction on the ith day.
Maximum profit gained by selling on ith day. In order to sell shares on ith day, we need to purchase it on any one of [0, i – 1] days. If we buy shares on jth day and sell it on ith day, max profit will be price[i] – price[j] + profit[t-1][j] where j varies from 0 to i-1. Here profit[t-1][j] is best we could have done with one less transaction till jth day.        */
        // O(k.n^2)
        public static int BuySellStocks(int[] price, int k)
        {
            int n = price.Length;
            // table to store results of subproblems profit[t, i] stores maximum
            // profit using atmost t transactions up to day i (including day i)
            int[,] profit = new int[k + 1, n + 1];

            // For day 0, you can't earn money irrespective of how many times you trade
            for (int d = 0; d <= k; d++)
                profit[d, 0] = 0;

            // profit is 0 if we don't do any transation (i.e. k =0)
            for (int t = 0; t <= n; t++)
                profit[0, t] = 0;
 
            // fill the table in bottom-up fashion
            // For each transaction
            for (int t = 1; t <= k; t++)
            {
                // For each day
                for (int d = 1; d < n; d++)
                {
                    int max_so_far = Int32.MinValue;

                    // For each day before today
                    for (int m = 0; m < d; m++)
                    {
                        var diff = price[d] - price[m];
                        max_so_far = Math.Max(max_so_far, diff + profit[t - 1, m]);
                    }
         
                    profit[t, d] = Math.Max(profit[t, d-1], max_so_far);
                }
            }
         
            return profit[k, n-1];
        }

        /*
Optimized Solution:
The above solution has time complexity of O(k.n2). It can be reduced if we are able to calculate maximum profit gained by selling shares on ith day in constant time.

profit[t, i] = max(profit [t, i-1], max(price[i] – price[j] + profit[t-1, j]))
                            for all j in range [0, i-1]

If we carefully notice,
max(price[i] – price[j] + profit[t-1, j])
for all j in range [0, i-1]

can be rewritten as,
= price[i] + max(profit[t-1, j] – price[j])
for all j in range [0, i-1]
= price[i] + max(prevDiff, profit[t-1, i-1] – price[i-1])
where prevDiff is max(profit[t-1, j] – price[j])
for all j in range [0, i-2]

So, if we have already calculated max(profit[t-1, j] – price[j]) for all j in range [0, i-2], we can calculate it for j = i – 1 in constant time. In other words, we don’t have to look back in range [0, i-1] anymore to find out best day to buy. We can determine that in constant time using below revised relation.

profit[t, i] = max(profit[t, i-1], price[i] + max(prevDiff, profit [t-1, i-1] – price[i-1])
where prevDiff is max(profit[t-1, j] – price[j]) for all j in range [0, i-2]
        */
        // O(n^2)
        public static int BuySellStocksOptimized(int[] price, int k)
        {
            int n = price.Length;
            // table to store results of subproblems profit[t, d] stores maximum
            // profit using atmost t transactions up to day d (including day d)
            int[,] profit = new int[k + 1, n + 1];

            // For day 0, you can't earn money irrespective of how many times you trade
            for (int i = 0; i <= k; i++)
                profit[i, 0] = 0;

            // profit is 0 if we don't do any transation (i.e. k =0)
            for (int j = 0; j <= n; j++)
                profit[0, j] = 0;

            // fill the table in bottom-up fashion
            // For each transaction t
            for (int t = 1; t <= k; t++)
            {
                int prevDiff = Int32.MinValue;
                // For each day d
                for (int d = 1; d < n; d++)
                {
                    // Profit for previous day with 1 less transaction
                    prevDiff = Math.Max(prevDiff, profit[t - 1, d - 1] - price[d - 1]);
                    // Profit for today is MAX of previous day and today
                    profit[t, d] = Math.Max(profit[t, d - 1], price[d] + prevDiff);
                }
            }

            return profit[k, n - 1];
        }
    }
}
