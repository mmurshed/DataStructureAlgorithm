using System;
using System.Linq;

namespace DynamicProramming
{
    public class MinInsertPalindrom
    {
        /*
         * Source: https://www.geeksforgeeks.org/dynamic-programming-set-28-minimum-insertions-to-form-a-palindrome/
         * 
         * Given a string, find the minimum number of characters to be inserted to convert it to palindrome.
         * 
         * Before we go further, let us understand with few examples:
         * ab: Number of insertions required is 1. bab
         * aa: Number of insertions required is 0. aa
         * abcd: Number of insertions required is 3. dcbabcd
         * abcda: Number of insertions required is 2. adcbcda
         * which is same as number of insertions in the substring bcd(Why?).
         * abcde: Number of insertions required is 4. edcbabcde
         * 
         * Let the input string be str[l...h]. The problem can be broken down into three parts:
         * 1. Find the minimum number of insertions in the substring str[l+1,...h].
         * 2. Find the minimum number of insertions in the substring str[l...h-1].
         * 3. Find the minimum number of insertions in the substring str[l+1...h-1].
         * 
         * Recursive Solution
         * The minimum number of insertions in the string str[l.....h] can be given as:
         * minInsertions (str[l+1.....h-1]) if str[l] is equal to str[h]
         * min (minInsertions(str[l.....h-1]), minInsertions(str[l+1.....h])) + 1 otherwise
        */

        // Recursive function to find minimum number of insertions
        public static int FindMinInsertionsNaive(string str, int l, int h)
        {
            // Base Cases
            if (l > h)
                return Int32.MaxValue;
            if (l == h)
                return 0;
            if (l == h - 1)
                return (str[l] == str[h]) ? 0 : 1;

            // Check if the first and last characters are
            // same. On the basis of the comparison result, 
            // decide which subrpoblem(s) to call
            return 
                str[l] == str[h] ?
                FindMinInsertionsNaive(str, l + 1, h - 1) :
                Math.Min(FindMinInsertionsNaive(str, l, h - 1), FindMinInsertionsNaive(str, l + 1, h)) + 1;
        }

        /*
         * Dynamic Programming based Solution
         * If we observe the above approach carefully, we can find that it 
         * exhibits overlapping subproblems. Suppose we want to find the 
         * minimum number of insertions in string “abcde”:
         *                   abcde
         *             /       |      \
         *            /        |        \
         *            bcde         abcd       bcd  <- case 3 is discarded as str[l] != str[h]
         *        /   |   \       /   |   \
         *       /    |    \     /    |    \
         *      cde   bcd  cd   bcd abc bc
         *    / | \  / | \ /|\ / | \
         *  de cd d cd bc c..........
         * 
         * The substrings in bold show that the recursion to be terminated and 
         * the recursion tree cannot originate from there. Substring in the same
         * color indicates overlapping subproblems.
         * 
         * How to reuse solutions of subproblems?
         * We can create a table to store results of subproblems so that they 
         * can be used directly if same subproblem is encountered again.
         * 
         * The below table represents the stored values for the string abcde.
         * 
         * a b c d e
         * ----------
         * 0 1 2 3 4
         * 0 0 1 2 3 
         * 0 0 0 1 2 
         * 0 0 0 0 1 
         * 0 0 0 0 0
         * 
         * How to fill the table?
         * The table should be filled in diagonal fashion. For the string abcde,
         * 0....4, the following should be order in which the table is filled:
         * 
         * Gap = 1:
         * (0, 1) (1, 2) (2, 3) (3, 4)
         * 
         * Gap = 2:
         * (0, 2) (1, 3) (2, 4)
         * 
         * Gap = 3:
         * (0, 3) (1, 4)
         * 
         * Gap = 4:
         * (0, 4)
         */
 
        // A DP function to find minimum number of insertions
        // O(n^2)
        public static int FindMinInsertionsDP(string str)
        {
            int n = str.Length;
            // Create a table of size n*n. table[i][j]
            // will store minimum number of insertions 
            // needed to convert str[i..j] to a palindrome.
            var table = new int[n, n];
            int l, h, gap;

            // Initialize all table entries as 0
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    table[i, j] = 0;

            // Fill the table
            for (gap = 1; gap < n; gap++)
            {
                for (l = 0, h = gap; h < n; l++, h++)
                {
                    table[l, h] = 
                        str[l] == str[h] ?
                        table[l + 1, h - 1] :
                        Math.Min(table[l, h - 1], table[l + 1, h]) + 1;
                }
            }
            // Return minimum number of insertions for str[0..n-1]
            return table[0, n - 1];
        }

        /*
         * The problem of finding minimum insertions can also be solved using 
         * Longest Common Subsequence (LCS) Problem. If we find out LCS of 
         * string and its reverse, we know how many maximum characters can form 
         * a palindrome. We need insert remaining characters. Following are the steps.
         * 
         * 1) Find the length of LCS of input string and its reverse. Let the length be ‘l’.
         * 
         * 2) The minimum number insertions needed is length of input string minus ‘l’.
        */

        // LCS based function to find minimum number of insertions
        public static int FindMinInsertionsLCS(string str)
        {
            // Reverse 'str'
            var rev = new string(str.ToCharArray().Reverse().ToArray());

            // Find Longest Common Sequence between the string and it's reverse
            int lcs = LongestCommonSubsequence.Generate(str, rev).Item1;

            // The output is length of string minus length of lcs of
            // str and it reverse
            return (str.Length - lcs);
        }
    }
}
