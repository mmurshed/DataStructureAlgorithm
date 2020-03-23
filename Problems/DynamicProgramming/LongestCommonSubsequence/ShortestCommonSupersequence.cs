using System;
using System.Text;

namespace Algorithm.DynamicProgramming
{
    /*
Given two strings str1 and str2, find the shortest string that has both str1 
and str2 as subsequences.

Examples :

Input:   str1 = "geek",  str2 = "eke"
Output: "geeke"

Input:   str1 = "AGGTAB",  str2 = "GXTXAYB"
Output:  "AGXGTXAYB"

This problem is closely related to longest common subsequence problem.
Below are steps.

1) Find Longest Common Subsequence (lcs) of two given strings. For example, 
lcs of “geek” and “eke” is “ek”.

2) Insert non-lcs characters (in their original order in strings) to the lcs 
found above, and return the result. So “ek” becomes “geeke” which is shortest 
common supersequence.

Let us consider another example, str1 = “AGGTAB” and str2 = “GXTXAYB”. LCS of 
str1 and str2 is “GTAB”. Once we find LCS, we insert characters of both 
strings in order and we get “AGXGTXAYB”

How does this work?
We need to find a string that has both strings as subsequences and is 
shortest such string. If both strings have all characters different, then 
result is sum of lengths of two given strings. If there are common characters, 
then we don’t want them multiple times as the task is to minimize length. 
Therefore, we fist find the longest common subsequence, take one occurrence 
of this subsequence and add extra characters.


Length of the shortest supersequence  = (Sum of lengths of given two strings) -
                                        (Length of LCS of two given strings) 

Below is the implementation of above idea. The below implementation only finds
length of the shortest supersequence.
    */
    public class ShortestCommonSupersequence
    {
        // Function to find length of the
        // shortest supersequence of X and Y.
        int ShortestSuperSequence(string X, string Y)
        {
            int m = X.Length;
            int n = Y.Length;

            // find lcs
            int l = LCS(X, Y, m, n);

            // Result is sum of input string
            // lengths - length of lcs
            return (m + n - l);
        }

        // Returns length of LCS
        // for X[0..m - 1], Y[0..n - 1]
        int LCS(string X, string Y, int m, int n)
        {
            var L = new int[m + 1, n + 1];
            int i, j;

            // Following steps build L[m + 1][n + 1] 
            // in bottom up fashion. Note that 
            // L[i][j] contains length of LCS of 
            // X[0..i - 1] and Y[0..j - 1]
            for (i = 0; i <= m; i++)
            {
                for (j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        L[i, j] = 0;
                    else if (X[i - 1] == Y[j - 1])
                        L[i, j] = L[i - 1, j - 1] + 1;
                    else
                        L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                }
            }

            // L[m, n] contains length of LCS
            // for X[0..n - 1] and Y[0..m - 1]
            return L[m, n];
        }

        /*
Below is Another Method to solve the above problem.
A simple analysis yields below simple recursive solution.

Let X[0..m - 1] and Y[0..n - 1] be two strings and m and n be respective
lengths.

  if (m == 0) return n;
  if (n == 0) return m;

  // If last characters are same, then add 1 to result and
  // recur for X[]
  if (X[m - 1] == Y[n - 1])
     return 1 + SCS(X, Y, m - 1, n - 1);

  // Else find shortest of following two
  //  a) Remove last character from X and recur
  //  b) Remove last character from Y and recur
  else return 1 + min( SCS(X, Y, m - 1, n), SCS(X, Y, m, n - 1) );
        */

        int SuperSeqNaive(string X, string Y, int m, int n)
        {
            if (m == 0)
                return n;
            if (n == 0)
                return m;

            if (X[m - 1] == Y[n - 1])
                return 1 + SuperSeqNaive(X, Y, m - 1, n - 1);

            return 1 + Math.Min(SuperSeqNaive(X, Y, m - 1, n),
                        SuperSeqNaive(X, Y, m, n - 1));
        }

        /*
Time complexity of the above solution exponential O(2min(m, n)). Since there are
overlapping subproblems, we can efficiently solve this recursive problem using 
Dynamic Programming. Below is Dynamic Programming based implementation. Time
complexity of this solution is O(mn).
        */

        // Returns length of the shortest 
        // supersequence of X and Y
        int SuperSeqDP(string X, string Y, int m, int n)
        {
            var dp = new int[m + 1, n + 1];

            // Fill table in bottom up manner
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    // Below steps follow above recurrence
                    if (i == 0)
                        dp[i, j] = j;
                    else if (j == 0)
                        dp[i, j] = i;
                    else if (X[i - 1] == Y[j - 1])
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    else
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return dp[m, n];
        }

        // https://www.geeksforgeeks.org/shortest-possible-combination-two-strings/
        string SuperSeqString(string a, string b, int[,] dp, int m, int n)
        {
            int index = dp[m, n];
            // Create a string of size index+1 to store the result
            var res = new StringBuilder(index + 1);

            // Start from the right-most-bottom-most corner and
            // one by one store characters in res[]
            int i = m;
            int j = n;
            while (i > 0 && j > 0)
            {
                // If current character in a[] and b are same,
                // then current character is part of LCS
                if (a[i - 1] == b[j - 1])
                {
                    // Put current character in result
                    res[index - 1] = a[i - 1];

                    // reduce values of i, j and indexs
                    i--;
                    j--;
                    index--;
                }
                // If not same, then find the larger of two and
                // go in the direction of larger value
                else if (dp[i - 1, j] < dp[i, j - 1])
                {
                    res[index - 1] = a[i - 1];
                    i--;
                    index--;
                }
                else
                { 
                    res[index - 1] = b[j - 1]; 
                    j--; 
                    index--; 
                }
            }

            // Copy remaining characters of string 'a'
            while (i > 0)
            {
                res[index - 1] = a[i - 1];
                i--;
                index--;
            }

            // Copy remaining characters of string 'b'
            while (j > 0)
            {
                res[index - 1] = b[j - 1];
                j--; 
                index--;
            }

            return res.ToString();
        }
    }
}
