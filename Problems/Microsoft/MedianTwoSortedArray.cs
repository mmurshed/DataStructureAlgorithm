using System;
using System.Collections.Generic;

namespace Algorithm.MicrosoftProblems
{

    // https://leetcode.com/problems/median-of-two-sorted-arrays
    public class MedianTwoSortedArray
    {
        public double FindMedian(int[] A, int[] B)
        {
            return A.Length < B.Length ? FindMedianInternal(A, B) : FindMedianInternal(B, A);
        }

        /*
          left_part          |        right_part
    A[0], A[1], ..., A[i-1]  |  A[i], A[i+1], ..., A[m-1]
    B[0], B[1], ..., B[j-1]  |  B[j], B[j+1], ..., B[n-1]
        */
        private double FindMedianInternal(int[] A, int[] B)
        {
            int m = A.Length;
            int n = B.Length;
            int imin = 0;
            int imax = m;
            int i = 0;
            int j = 0;
            int halfLength = (m + n + 1) / 2;

            while (imin <= imax)
            {
                i = (imin + imax) / 2;
                j = halfLength - i;

                if (i < imax && B[j - 1] > A[i])
                {
                    // A[i] is too small.
                    // Adjust i to get B[j−1] <= A[i]
                    // When i is increased, j will be decreased.
                    // So B[j−1] is decreased and A[i] is increased.
                    // We will move closer to B[j−1] <= A[i]
                    // However, the opposit is not true.
                    // We must adjust the searching range to [imin + 1, imax].
                    imin++;
                }
                else if (i > imin && j < n && A[i - 1] > B[j])
                {
                    // A[i−1] is too big.
                    // We must decrease i to get A[i−1] <= B[j].
                    // We must adjust the searching range to [imin, imax − 1].
                    imax--;
                }
                else
                {
                    // Found
                    break;
                }
            }

            int leftMax = 0;
            if (i > 0 && j > 0)
                leftMax = Math.Max(A[i - 1], B[j - 1]);
            else if (i == 0 && j > 0)
                leftMax = B[j - 1];
            else if (i > 0 && j == 0)
                leftMax = A[i - 1];

            int rightMin = 0;
            if (i < m && j < n)
                rightMin = Math.Min(A[i], B[j]);
            else if (i == m && j < n)
                rightMin = B[j];
            else if (i < m && j == n)
                rightMin = A[i];

            double median = 0;
            if( (m + n) % 2 == 1)
            {
                median = leftMax;
            }
            else
            {
                median = (leftMax + rightMin) / 2.0;
            }

            return median;
        }
    }
}
