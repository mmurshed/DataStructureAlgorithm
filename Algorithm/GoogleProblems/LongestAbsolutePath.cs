using System;
namespace DataStructure.GoogleProblems
{
    // https://leetcode.com/problems/longest-absolute-file-path/description/
    public class LongestAbsolutePath
    {
        public int LengthLongestPath(string input)
        {
            int[] len = new int[input.Length];
            int sum = 0;
            int curLen = 0;
            int idx = 0;
            int max = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (ch == '\n')
                {
                    len[idx] = curLen;
                    sum = 0;
                    curLen = 0;
                    idx = 0;
                }
                else if (ch == '\t')
                {
                    sum += len[idx];
                    idx++;
                    if (curLen == 0)
                    {
                        sum++;
                        curLen = 1;
                    }
                }
                else if (ch == '.')
                {
                    while (i < input.Length && input[i] != '\n')
                    {
                        sum++;
                        curLen++;
                        i++;
                    }
                    max = Math.Max(max, sum);
                    if (i < input.Length && input[i] == '\n')
                    {
                        sum = 0;
                        curLen = 0;
                        idx = 0;
                    }
                }
                else
                {
                    sum++;
                    curLen++;
                }
            }

            return max;
        }
    }
}
