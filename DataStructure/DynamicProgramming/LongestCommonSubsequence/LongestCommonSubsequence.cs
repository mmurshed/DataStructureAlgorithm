using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProramming
{
    public class LongestCommonSubsequence
    {
        /*
        Source: https://www.geeksforgeeks.org/longest-common-subsequence/

        LCS Problem Statement: Given two sequences, find the length of longest 
        subsequence present in both of them. A subsequence is a sequence that 
        appears in the same relative order, but not necessarily contiguous. 
        For example, “abc”, “abg”, “bdf”, “aeg”, ‘”acefg”, .. etc are 
        subsequences of “abcdefg”. So a string of length n has 2^n different 
        possible subsequences.

        It is a classic computer science problem, the basis of diff (a file 
        comparison program that outputs the differences between two files), 
        and has applications in bioinformatics.

        Examples:
        LCS for input Sequences “ABCDGH” and “AEDFHR” is “ADH” of length 3.
        LCS for input Sequences “AGGTAB” and “GXTXAYB” is “GTAB” of length 4.

        The naive solution for this problem is to generate all subsequences of 
        both given sequences and find the longest matching subsequence. This 
        solution is exponential in term of time complexity. Let us see how this 
        problem possesses both important properties of 
        a Dynamic Programming (DP) Problem.

        1) Optimal Substructure: 
        Let the input sequences be X[0..m-1] and Y[0..n-1] of lengths m and n 
        respectively. And let L(X[0..m-1], Y[0..n-1]) be the length of LCS of 
        the two sequences X and Y. Following is the recursive definition 
        of L(X[0..m-1], Y[0..n-1]).

        If last characters of both sequences match (or X[m-1] == Y[n-1]) then
            L(X[0..m-1], Y[0..n-1]) = 1 + L(X[0..m-2], Y[0..n-2])

        If last characters of both sequences do not match (or X[m-1] != Y[n-1]) then
            L(X[0..m-1], Y[0..n-1]) = MAX ( L(X[0..m-2], Y[0..n-1]), L(X[0..m-1], Y[0..n-2])

        Examples:
        1) Consider the input strings “AGGTAB” and “GXTXAYB”.
        Last characters match for the strings. So length of LCS can be written as:
        L(“AGGTAB”, “GXTXAYB”) = 1 + L(“AGGTA”, “GXTXAY”)

        _______________
        | |A|G|G|T|A|B|
        |G| | |4| | | |
        |X| | | | | | |
        |T| | | |3| | |
        |X| | | | | | |
        |A| | | | |2| |
        |Y| | | | | | |
        |B| | | | | |1|
        ---------------

        2) Consider the input strings “ABCDGH” and “AEDFHR.
        Last characters do not match for the strings. So length of LCS can be written as:
        L(“ABCDGH”, “AEDFHR”) = MAX ( L(“ABCDG”, “AEDFHR”), L(“ABCDGH”, “AEDFH”) )

        So the LCS problem has optimal substructure property as the main 
        problem can be solved using solutions to subproblems.

        2) Overlapping Subproblems:
        Following is simple recursive implementation of the LCS problem. The 
        implementation simply follows the recursive structure mentioned above.
        */



        // Naive: O(2^n)
        /* For the Naive implementation, following is a partial recursion tree 
         * for input strings “AXYT” and “AYZX”

                         lcs("AXYT", "AYZX")
                       /                 
         lcs("AXY", "AYZX")            lcs("AXYT", "AYZ")
         /                              /               
lcs("AX", "AYZX") lcs("AXY", "AYZ")   lcs("AXY", "AYZ") lcs("AXYT", "AY")
        */
        public static int GenerateNaive(string X, string Y)
        {
            return GenerateNaive(X, Y, X.Length, Y.Length);
        }

        public static int GenerateNaive(string X, string Y, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;
            /* If last characters of both sequences match (or X[m-1] == Y[n-1]) then
             *      L(X[0..m-1], Y[0..n-1]) =
             *          1 + L(X[0..m-2], Y[0..n-2])
             */
            if (X[m - 1] == Y[n - 1])
                return 1 + GenerateNaive(X, Y, m - 1, n - 1);
            /* If last characters of both sequences do not match (or X[m-1] != Y[n-1]) then
             *      L(X[0..m-1], Y[0..n-1]) 
             *          = MAX ( L(X[0..m-2], Y[0..n-1]), L(X[0..m-1], Y[0..n-2])
            */
            else
                return Math.Max(GenerateNaive(X, Y, m, n - 1), GenerateNaive(X, Y, m - 1, n));

 
        }

        // Dynamic Programming O(n^2)
        public static Tuple<int, string> Generate(string X, string Y)
        {
            int m = X.Length;
            int n = Y.Length;
            var lcs = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        lcs[i, j] = 0;
                    /* If last characters of both sequences match (or X[m-1] == Y[n-1]) then
                     *      L(X[0..m-1], Y[0..n-1]) =
                     *          1 + L(X[0..m-2], Y[0..n-2])
                     */
                    else if (X[i - 1] == Y[j - 1])
                        lcs[i, j] = 1 + lcs[i - 1, j - 1];
                    /* If last characters of both sequences do not match (or X[m-1] != Y[n-1]) then
                     *      L(X[0..m-1], Y[0..n-1]) 
                     *          = MAX ( L(X[0..m-2], Y[0..n-1]), L(X[0..m-1], Y[0..n-2])
                    */
                    else
                        lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
                }
            }
            string str = GetString(X, Y, lcs);
            return new Tuple<int, string>(lcs[m, n], str);
        }

    
        public static string GetString(string X, string Y, int[,] lcs)
        {
            int m = X.Length;
            int n = Y.Length;

            int i = m, j = n;
            int index = lcs[m, n];
            var strb = new StringBuilder(new string(' ', index + 1));
            while (i > 0 && j > 0)
            {
                if (X[i - 1] == Y[j - 1])
                {
                    strb[index - 1] = X[i - 1];
                    i--;
                    j--;
                    index--;
                }
                else if (lcs[i - 1, j] > lcs[i, j - 1])
                    i--;
                else
                    j--;
            }
            return strb.ToString();
        }

    }
}
