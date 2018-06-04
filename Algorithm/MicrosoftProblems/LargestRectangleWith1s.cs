using System;
namespace Algorithm.MicrosoftProblems
{
    public class LargestRectangleWith1s
    {
        // Returns area of the largest rectangle with all 1s in A[,]
        // O(R * C)
        public int MaxRectangle(int[,] A)
        {
            int R = A.GetLength(0);
            int C = A.GetLength(1);
            var largestHist = new LargestAreaUnderHistogram();

            // Calculate area for first row and initialize it as result
            int result = largestHist.FindLargestAreaUnderHistogram3(A, 0);

            // Find maximum rectangular area considering each row as a histogram
            for (int i = 1; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    // if A[i, j] is 1, add A[i -1, j]
                    if (A[i, j] == 1)
                        A[i, j] += A[i - 1, j];
                }

                // Update result if area with current row (as last row of rectangle) is more
                var hist = largestHist.FindLargestAreaUnderHistogram3(A, i);
                result = Math.Max(result, hist);
            }

            return result;
        }
    }
}
