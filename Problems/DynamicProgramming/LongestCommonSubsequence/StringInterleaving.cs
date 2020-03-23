using System;
namespace Algorithm.DynamicProgramming
{
    //https://www.geeksforgeeks.org/check-whether-a-given-string-is-an-interleaving-of-two-other-given-strings-set-2/

    /*
Given three strings A, B and C. Write a function that checks whether C is an 
interleaving of A and B. C is said to be interleaving A and B, if it contains 
all characters of A and B and order of all characters in individual strings is 
preserved.

We have discussed a simple solution of this problem here. The simple solution 
doesn’t work if strings A and B have some common characters. For example 
A = “XXY”, string B = “XXZ” and string C = “XXZXXXY”. To handle all cases, 
two possibilities need to be considered.

a) If first character of C matches with first character of A, we move one 
character ahead in A and C and recursively check.

b) If first character of C matches with first character of B, we move one 
character ahead in B and C and recursively check.

If any of the above two cases is true, we return true, else false. Following is 
simple recursive implementation of this approach

Dynamic Programming
The worst case time complexity of recursive solution is O(2^n). The above 
recursive solution certainly has many overlapping subproblems. For example, 
if wee consider A = “XXX”, B = “XXX” and C = “XXXXXX” and draw recursion tree,
there will be many overlapping subproblems.

Therefore, like other typical Dynamic Programming problems, we can solve it by
creating a table and store results of subproblems in bottom up manner.

    */
    public class StringInterleaving
    {
        public bool IsInterLeaving(string a, string b, string c)
        {
            return IsInterLeaving(a, 0, b, 0, c, 0);
        }

        private bool IsInterLeaving(string a, int ia, string b, int ib, string c, int ic)
        {
            // all string empty
            if (ia == a.Length && ib == b.Length && ic == c.Length)
                return true;

            // if only the interleaving string is empty
            if (ic == c.Length)
                return false;

            // if both strings are empty but interleaving is not
            if (ia == a.Length && ib == b.Length)
                return false;

            bool first = false;
            bool second = false;

            if (a[ia] == c[ic])
                first = IsInterLeaving(a, ia + 1, b, ib, c, ic + 1);
            if (b[ib] == c[ic])
                second = IsInterLeaving(a, ia, b, ib + 1, c, ic + 1);

            return first || second;
        }

        public bool IsInterLeavingDP(string a, string b, string c)
        {
            if (c.Length != a.Length + b.Length)
                return false;

            var dp = new bool[a.Length + 1, b.Length + 1];
            dp[0, 0] = true;

            // First row
            for (int j = 1; j <= b.Length; j++)
            {
                if (b[j - 1] != c[j - 1])
                    dp[0, j] = false;
                else
                    dp[0, j] = dp[0, j - 1];
            }

            // First col
            for (int i = 1; i <= a.Length; i++)
            {
                if (a[i - 1] != c[i - 1])
                    dp[i, 0] = false;
                else
                    dp[i, 0] = dp[i - 1, 0];
            }

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    int k = i + j - 1;
                    // Current char of c is same as a, but not b
                    if (a[i - 1] == c[k] && b[j - 1] != c[k])
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    // Current char of c is same as b, but not a
                    else if (a[i - 1] != c[k] && b[j - 1] == c[k])
                    {
                        dp[i, j] = dp[i, j - 1];
                    }
                    // Current char of c is same as a and b
                    else if (a[i - 1] == c[k] && b[j - 1] == c[k])
                    {
                        dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
                    }
                    // Current char of c is doesn't match either a or b
                    else
                    {
                        dp[i, j] = false;
                    }
                }
            }

            return dp[a.Length, b.Length];
        }
    }
}
