using System;
namespace Algorithm.DynamicProgramming.Micellaneous
{
    public class CuttingRod
    {
        int CutRodNaive(int[] values, int n)
        {
            if (n <= 0)
                return 0;

            int maxValue = Int32.MinValue;
            for (int i = 1; i <= n; i++)
            {
                maxValue = Math.Max(maxValue, values[i] + CutRodNaive(values, n - i));
            }

            return maxValue;
        }

        int CutRodMemo(int[] values, int n)
        {
            int[] maxValues = new int[n];

            return CutRodMemo(values, n, maxValues);
        }

        int CutRodMemo(int[] values, int n, int[] maxValues)
        {
            if (n <= 0)
                return 0;
            if (maxValues[n] != 0)
                return maxValues[n];

            maxValues[n] = Int32.MinValue;

            for (int i = 1; i <= n; i++)
            {
                maxValues[n] = Math.Max(maxValues[n], values[i] + CutRodMemo(values, n - i, maxValues));
            }

            return maxValues[n];
        }

        // O(n^2)
        int CutRodDP(int[] values, int n)
        {
            if (n <= 0)
                return 0;
            int[] maxValues = new int[n + 1];
            maxValues[0] = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    maxValues[n] = Math.Max(maxValues[n], values[i] + maxValues[i - j - 1]);
                }
            }

            return maxValues[n];
        }
    
    }
}
