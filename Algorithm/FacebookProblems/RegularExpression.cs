using System;
namespace Algorithm.FacebookProblems
{
    public class RegularExpression
    {
        public bool IsMatch(string s, string p)
        {
            return IsMatchNaive(s, 0, p, 0);
        }

        private bool IsMatchNaive(string s, int si, string p, int pi)
        {
            if (pi >= p.Length && si >= s.Length)
                return true;
            if (pi >= p.Length)
                return false;

            if (pi < p.Length - 1 && p[pi + 1] == '*')
                return IsMatchNaive(s, si, p, ++pi);
            else if (p[pi] == '.' || (si < s.Length && p[pi] == s[si]))
                return IsMatchNaive(s, ++si, p, ++pi);
            else if (p[pi] == '*')
            {
                if (pi == 0)
                    return false;
                char ch = p[pi - 1];
                int sj = si;
                int pj = pi + 1;
                bool match = IsMatchNaive(s, sj, p, pj);
                if (match)
                    return match;
                while (sj < s.Length && (ch == '.' || s[sj] == ch))
                {
                    sj++;
                    match = IsMatchNaive(s, sj, p, pj);
                    if (match)
                        return true;
                }
                return IsMatchNaive(s, sj, p, pj);
            }

            return false;
        }

        // https://xiaokangstudynotes.com/2017/01/21/dynamic-programming-regular-expression-matching/
        public bool IsMatchDP(string s, string p)
        {
            if ((p == null || p.Length == 0) && (s == null || s.Length == 0))
                return true;
            var dp = new bool[s.Length + 1, p.Length + 1];

            // Empty string and empty pattern
            dp[0, 0] = true;

            // Empty string and a pattern such as "***"
            for (int i = 1; i <= p.Length; i++)
                if (p[i - 1] == '*')
                    dp[0, i] = dp[0, i - 2];

            // Non empty string and empty pattern
            // dp[i,0] remains false

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= p.Length; j++)
                {
                    char pch = p[j - 1];
                    char sch = s[i - 1];

                    // Two cases if we see a '*'
                    // a) We ignore ‘*’ character and move to next  character
                    //    in the pattern, i.e., ‘*’ indicates an empty sequence.
                    // b) '*' character matches with ith character in input
                    if (pch == '*')
                    {
                        char prev = p[j - 2];
                        if (prev != '.' && prev != sch)
                        {
                            dp[i, j] = dp[i, j - 2];
                        }
                        else
                        {
                            dp[i, j] = dp[i, j - 1] || dp[i - 1, j] || dp[i, j - 2];
                        }
                    }
                    // Current characters are considered as matching in two cases
                    // (a) current character of pattern is '.'
                    // (b) characters actually match
                    else if (pch == '.' || pch == sch)
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = false;
                    }
                }
            }

            return dp[s.Length, p.Length];
        }
    }
 
}
