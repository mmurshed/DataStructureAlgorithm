using System;
namespace DataStructurePractice.DynamicProgramming.BuySellStocks
{
    /* BUY AND SELL ANYTIME
     * 
     * The cost of a stock on each day is given in an array, find the max profit that you can make by buying and selling in those days. For example, if the given array is {100, 180, 260, 310, 40, 535, 695}, the maximum profit can earned by buying on day 0, selling on day 3. Again buy on day 4 and sell on day 6. If the given array of prices is sorted in decreasing order, then profit cannot be earned at all.
     * 
     * Following is algorithm for this problem.
     * 1. Find the local minima and store it as starting index. If not exists, return.
     * 2. Find the local maxima. and store it as ending index. If we reach the end, set the end as ending index.
     * 3. Update the solution (Increment count of buy sell pairs)
     * 4. Repeat the above steps if end is not reached.
     * 
     * Approach #2 (Peak Valley Approach) [Accepted]

Algorithm

Say the given array is:

[7, 1, 5, 3, 6, 4].

If we plot the numbers of the given array on a graph, we get:

Profit Graph
|
|\         peakj
| \ peaki B/\ C
|  \A /\  /  \
|   \/  \/
|valleyi valleyj
|------------------

If we analyze the graph, we notice that the points of interest are the consecutive valleys and peaks.

Mathematically speaking:

TotalProfit= i∑(height(peak_i) − height(valley_i))

The key point is we need to consider every peak immediately following a valley to maximize the profit. In case we skip one of the peaks (trying to obtain more profit), we will end up losing the profit over one of the transactions leading to an overall lesser profit.

For example, in the above case, if we skip peak_i and valley_j trying to obtain more profit by considering points with more difference in heights, the net profit obtained will always be lesser than the one obtained by including them, since C will always be lesser than A+B.
    */
    public class BuySellStocksAnytime
    {
        // O(n)
        public static int BuySellStocks2A(int[] prices)
        {
            int i = 0;
            int valley = prices[0];
            int peak = prices[0];
            int maxprofit = 0;
            while (i < prices.Length - 1)
            {
                // Find valley
                while (i < prices.Length - 1 && prices[i] >= prices[i + 1])
                    i++;
                valley = prices[i];
                // Find peak
                while (i < prices.Length - 1 && prices[i] <= prices[i + 1])
                    i++;
                peak = prices[i];
                maxprofit += peak - valley;
            }
            return maxprofit;
        }

        /*
         * Approach #3 (Simple One Pass) [Accepted]

Algorithm

This solution follows the logic used in Approach 2 itself, but with only a slight variation. In this case, instead of looking for every peak following a valley, we can simply go on crawling over the slope and keep on adding the profit obtained from every consecutive transaction. In the end,we will be using the peaks and valleys effectively, but we need not track the costs corresponding to the peaks and valleys along with the maximum profit, but we can directly keep on adding the difference between the consecutive numbers of the array if the second number is larger than the first one, and at the total sum we obtain will be the maximum profit. This approach will simplify the solution. This can be made clearer by taking this example:

[1, 7, 2, 3, 6, 7, 6, 7]

The graph corresponding to this array is:

|                   C  --/\
|                   --/    \D /
|      /\       B -/        \/
|     /  \      -/
|    /    \    /
|   /      \ A/
|  /        \/
| /
|--------------------------

From the above graph, we can observe that the sum A+B+C is equal to the difference D corresponding to the difference between the heights of the consecutive peak and valley.


        */
        // O(n)
        public static int BuySellStocks2B(int[] prices)
        {
            int maxprofit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    maxprofit += prices[i] - prices[i - 1];
            }
            return maxprofit;
        }


    }
}
