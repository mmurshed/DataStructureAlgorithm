using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.DynamicProgramming
{
    public class LongestPalindromicSubsequence
    {
        // Source: https://www.geeksforgeeks.org/dynamic-programming-set-12-longest-palindromic-subsequence/

        /* Given a sequence, find the length of the longest palindromic subsequence in it.
         * 
         * Input: GEEKSFORGEEKS
         * Output: 5
         * EEKEE, EESEE, EEFEE, ...
         * 
         * As another example, if the given sequence is “BBABCBCAB”, then the 
         * output should be 7 as “BABCBAB” is the longest palindromic subseuqnce
         * in it. “BBBBB” and “BBCBB” are also palindromic subsequences of the 
         * given sequence, but not the longest ones.
         * 
         * The naive solution for this problem is to generate all subsequences 
         * of the given sequence and find the longest palindromic subsequence. 
         * This solution is exponential in term of time complexity. Let us see 
         * how this problem possesses both important properties of a Dynamic 
         * Programming (DP) Problem and can efficiently solved using Dynamic 
         * Programming.
         * 
         * 1) Optimal Substructure: 
         * Let X[0..n-1] be the input sequence of length n and L(0, n-1) 
         * be the length of the longest palindromic subsequence of X[0..n-1].
         * 
         * If last and first characters of X are same, 
         * then L(0, n-1) = L(1, n-2) + 2.
         * Else L(0, n-1) = MAX (L(1, n-1), L(0, n-2)).
         * 
         * Following is a general recursive solution with all cases handled.
         * 1. Every single character is a palindrome of length 1
         *      L(i, i) = 1 for all indexes i in given sequence
         * 
         * 2. IF first and last characters are not same
         *      If (X[i] != X[j])  L(i, j) =  max{L(i + 1, j),L(i, j - 1)} 
         * 
         * 3. If there are only 2 characters and both are same
         *      Else if (j == i + 1) L(i, j) = 2  
         * 
         * 4. If there are more than two characters, and first and 
         * last characters are same
         * Else L(i, j) =  L(i + 1, j - 1) + 2 
         * 
         * 2) Overlapping Subproblems
         * Following is simple recursive implementation of the LPS problem. 
         * The implementation simply follows the recursive structure mentioned above.
         * 
         * For the naive implementation, following is a partial recursion tree 
         * for a sequence of length 6 with all different characters.

               L(0, 5)
             /        \ 
            /          \  
        L(1,5)          L(0,4)
       /    \            /    \
      /      \          /      \
  L(2,5)    L(1,4)  L(1,4)  L(0,3)
        */

        int GenerateNaive(char[] seq, int i, int j)
        {
            // Base Case 1: If there is only 1 character
            if (i == j)
                return 1;

            // Base Case 2: If there are only 2 characters and both are same
            if (seq[i] == seq[j] && i + 1 == j)
                return 2;

            // If the first and last characters match
            if (seq[i] == seq[j])
                return GenerateNaive(seq, i + 1, j - 1) + 2;

            // If the first and last characters do not match
            return Math.Max(GenerateNaive(seq, i, j - 1), GenerateNaive(seq, i + 1, j));
        }


        public static string Generate(string S)
        {
            int n = S.Length;
            var table = new bool[n, n];
            int max = 1;
            int start = 0;
            for (int i = 0; i < n; i++)
            {
                table[i, i] = true;
                if(i < n-1 && S[i] == S[i+1])
                {
                    table[i, i + 1] = true;
                    start = i;
                    max = 2;
                }
            } 

            for (int k = 3; k <= n; k++)
            {
                for (int i = 0; i < n - k + 1; i++)
                {
                    int j = i + k - 1;
                    if (table[i + 1, j - 1] && S[i] == S[j])
                    {
                        table[i, j] = true;
                        if(k > max)
                        {
                            start = i;
                            max = k;
                        }
                    }
                }
            }
            return S.Substring(start, max);
        }

        // Returns the length of the longest palindromic subsequence in seq
        public static int lps(string str)
        {
            int n = str.Length;
            var L = new int[n, n];  // Create a table to store results of subproblems


            // Strings of length 1 are palindrome of lentgh 1
            for (int i = 0; i < n; i++)
                L[i, i] = 1;

            // Build the table. Note that the lower diagonal values of table are
            // useless and not filled in the process. The values are filled in a
            // manner similar to Matrix Chain Multiplication DP solution (See
            // https://www.geeksforgeeks.org/archives/15553). cl is length of
            // substring
            for (int k = 2; k <= n; k++)
            {
                for (int i = 0; i < n - k + 1; i++)
                {
                    int j = i + k - 1;
                    if (str[i] == str[j] && k == 2)
                        L[i, j] = 2;
                    else if (str[i] == str[j])
                        L[i, j] = L[i + 1, j - 1] + 2;
                    else
                        L[i, j] = Math.Max(L[i, j - 1], L[i + 1, j]);
                }
            }

            return L[0, n - 1];
        }

        public static void Test()
        {
            string seq = "GEEKS FOR GEEKS";
            Console.WriteLine($"The lnegth of the LPS is {lps(seq)}");
        }
	}
}
