using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProramming
{
    public class LongestRepeatingSubsequence
    {
        /* Source: https://www.geeksforgeeks.org/longest-repeated-subsequence/
         * 
         * Given a string, print the longest repeating subseequence such that 
         * the two subsequence don’t have same string character at same 
         * position, i.e., any i’th character in the two subsequences shouldn’t 
         * have the same index in the original string.
         * 
         * More Examples:
         * 
         * Input: str = "aabb"
         * Output: "ab"
         * 
         * Input: str = "aab"
         * Output: "a"
         * The two subssequence are 'a'(first) and 'a' (second). Note that 'b' 
         * cannot be considered as part of subsequence as it would be at same 
         * index in both.

         * This problem is just the modification of Longest Common Subsequence 
         * problem. The idea is to find the LCS(str, str) where str is the 
         * input string with the restriction that when both the characters are 
         * same, they shouldn’t be on the same index in the two strings.
        */
        public static string GetString(string X, int[,] lcs)
		{
			int m = X.Length;

			int i = m, j = m;
			int index = lcs[m, m];
			var strb = new StringBuilder(new string(' ', index + 1));
			while (i > 0 && j > 0)
			{
				if (lcs[i, j] == lcs[i - 1, j - 1])
				{
					strb[index - 1] = X[i - 1];
					i--;
					j--;
					index--;
				}
				else if (lcs[i, j] == lcs[i - 1, j])
					i--;
				else
					j--;
			}
			return strb.ToString();
		}

		public static Tuple<int, string> Generate(string X)
		{
			int m = X.Length;
			var lcs = new int[m + 1, m + 1];
			for (int i = 0; i <= m; i++)
			{
				for (int j = 0; j <= m; j++)
				{
					if (i == 0 || j == 0)
						lcs[i, j] = 0;
                    else if (X[i - 1] == X[j - 1] && i != j)
                        lcs[i, j] = 1 + lcs[i - 1, j - 1];
                    else
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                }
            }
			
			string str = GetString(X, lcs);
			return new Tuple<int, string>(lcs[m, m], str);
		}
	}
}
