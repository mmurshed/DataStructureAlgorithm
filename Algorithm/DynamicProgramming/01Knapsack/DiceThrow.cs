using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm.DynamicProgramming
{
    public class DiceThrow
    {
        // Source: https://www.geeksforgeeks.org/dice-throw-problem/

        /*
         * Given n dice each with m faces, numbered from 1 to m, find the number
         * of ways to get sum X. X is the summation of values on each face when 
         * all the dice are thrown.
         * 
         * The Naive approach is to find all the possible combinations of values
         * from n dice and keep on counting the results that sum to X.
         * 
         * This problem can be efficiently solved using Dynamic Programming (DP).
         * 
         * Let the function to find X from n dice is: Sum(m, n, X)
         * The function can be represented as:
         * Sum(m, n, X) = Finding Sum (X - 1) from (n - 1) dice plus 1 from nth dice
         *              + Finding Sum (X - 2) from (n - 1) dice plus 2 from nth dice
         *              + Finding Sum (X - 3) from (n - 1) dice plus 3 from nth dice
         *              ...................................................
         *              ...................................................
         *              ...................................................
         *              + Finding Sum (X - m) from (n - 1) dice plus m from nth dice
         * 
         * So we can recursively write Sum(m, n, x) as following
         * Sum(m, n, X) =   Sum(m, n - 1, X - 1) + 
         *                  Sum(m, n - 1, X - 2) +
         *                  .................... + 
         *                  Sum(m, n - 1, X - m)
         * 
         * Why DP approach?
         * The above problem exhibits overlapping subproblems. See the below 
         * diagram. Also, see this recursive implementation. Let there be 3 
         * dice, each with 6 faces and we need to find the number of ways to 
         * get sum 8:
         * 
         * Sum(6, 3, 8) =   Sum(6, 2, 7) + Sum(6, 2, 6) + Sum(6, 2, 5) + 
         *                  Sum(6, 2, 4) + Sum(6, 2, 3) + Sum(6, 2, 2)
         * 
         * To evaluate Sum(6, 3, 8), we need to evaluate Sum(6, 2, 7) which can 
         * recursively written as following:
         * Sum(6, 2, 7) =   Sum(6, 1, 6) + Sum(6, 1, 5) + Sum(6, 1, 4) + 
         *                  Sum(6, 1, 3) + Sum(6, 1, 2) + Sum(6, 1, 1)
         * 
         * We also need to evaluate Sum(6, 2, 6) which can recursively written
         * as following:
         * Sum(6, 2, 6) = Sum(6, 1, 5) + Sum(6, 1, 4) + Sum(6, 1, 3) +
         *              Sum(6, 1, 2) + Sum(6, 1, 1)
         *              ...................................................
         *              ...................................................
         *              Sum(6, 2, 2) = Sum(6, 1, 1)
         * 
         * Please take a closer look at the above recursion. The sub-problems 
         * in RED are solved first time and sub-problems in BLUE are solved 
         * again (exhibit overlapping sub-problems). Hence, storing the results 
         * of the solved sub-problems saves time.
        */

        public static int GenerateNaive(int m, int n, int x)
        {
            if (n == 1)
                return 1;
            if (x == 0)
                return 0;
            int sum = 0;

            // for each face value k
            for (int k = 1; k <= m; k++)
            {
                // Find value x - k from n - 1 dice
                sum += GenerateNaive(m, n - 1, x - k);
            }
            return sum;
        }

        // The main function that returns number of ways to get sum 'x'
        // with 'n' dice and 'm' with m faces.
        // O(n^3)
        public static int Generate(int m, int n, int x)
        {
            // Create a table to store results of subproblems.  One extra 
            // row and column are used for simpilicity (Number of dice
            // is directly used as row index and sum is directly used
            // as column index).  The entries in 0th row and 0th column
            // are never used.
            var table = new int[n + 1, x + 1]; // Initialize all entries as 0
 
            // Table entries for only one dice
            for (int j = 1; j <= m && j <= x; j++)
                table[1, j] = 1;

            // Fill rest of the entries in table using recursive relation
            // i: number of dice, j: sum
            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j <= x; j++)
                {
                    for (int k = 1; k <= m && k < j; k++)
                    {
                        table[i, j] += table[i - 1, j - k];
                    }
                }
            }
 
            return table[n, x];
        }

        public void Test()
        {
            Console.WriteLine(Generate(4, 2, 1));
        }

	}
}
