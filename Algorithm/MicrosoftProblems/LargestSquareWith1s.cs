using System;
namespace Algorithm.MicrosoftProblems
{
    public class LargestSquareWith1s
    {
        // https://www.geeksforgeeks.org/maximum-size-sub-matrix-with-all-1s-in-a-binary-matrix/
        /*
1) Construct a sum matrix S[R, C] for the given M[R, C].
     a)    Copy first row and first columns as it is from M[,] to S[,]
     b)    For other entries, use following expressions to construct S[][]
         If M[i, j] is 1 then
            S[i, j] = min(S[i, j-1], S[i-1, j], S[i-1, j-1]) + 1
         Else If M[i][j] is 0 then
            S[i, j] = 0
2) Find the maximum entry in S[R][C]
3) Using the value and coordinates of maximum entry in S[i], print
   sub-matrix of M[][]
        */

        private int Min3(int i, int j, int k)
        {
            return Math.Min(Math.Min(i, j), k);
        }

        public void printMaxSubSquare(bool[,] M)
        {
            int R = M.GetLength(0);
            int C = M.GetLength(1);
            var S = new int[R, C];
            int max_of_s, max_i, max_j;

            // Set first column of S[,]
            for (int i = 0; i < R; i++)
                S[i, 0] = M[i, 0] ? 1 : 0;

            // Set first row of S[,]
            for (int j = 0; j < C; j++)
                S[0, j] = M[0, j] ? 1 : 0;

            // Construct other entries of S[,]
            for (int i = 1; i < R; i++)
            {
                for (int j = 1; j < C; j++)
                {
                    if (M[i, j])
                        S[i, j] = 1 + Min3(S[i, j - 1], S[i - 1, j], S[i - 1, j - 1]);
                    else
                        S[i, j] = 0;
                }
            }

            // Find the maximum entry, and indexes of maximum entry in S[,]
            max_of_s = S[0, 0];
            max_i = 0;
            max_j = 0;
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (max_of_s < S[i, j])
                    {
                        max_of_s = S[i, j];
                        max_i = i;
                        max_j = j;
                    }
                }
            }
        }
    }
}
