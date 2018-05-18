using System;
namespace Algorithm.DynamicProgramming.Micellaneous
{
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
