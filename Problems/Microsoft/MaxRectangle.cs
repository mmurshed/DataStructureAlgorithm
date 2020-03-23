using System;
namespace Algorithm.MicrosoftProblems
{
    // https://www.interviewbit.com/microsoft-interview-questions/
    public class MaxRectangle
    {
        int MaximumRectangle(int[,] a)
        {
            int m = a.GetLength(0);
            int n = a.GetLength(1);

            int rec = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int count = 0;
                    if (i >= 1 && j >= 1 && a[i - 1, j - 1] == 1)
                        count++;
                    if (j >= 0 && a[i, j - 1] == 1)
                        count++;
                    if (i < m - 1 && j >= 0 && a[i + 1, j - 1] == 1)
                        count++;
                    if (i < m - 1 && j < n - 1 && a[i + 1, j + 1] == 1)
                        count++;
                    if (i < m - 1 && j < n - 1 && a[i + 1, j + 1] == 1)
                        count++;
                }
            }
            return rec;
        }
    }
}
