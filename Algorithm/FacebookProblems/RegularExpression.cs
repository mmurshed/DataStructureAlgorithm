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

            // 1. Empty string and empty pattern
            dp[0, 0] = true;

            // 2. Empty string and a pattern such as "***"
            for (int i = 0; i < p.Length; i++)
                if (p[i] == '*')
                    dp[0, i + 1] = dp[0, i - 1];

            // 3. Non empty string and empty pattern.
            // dp[i, 0] remains false.
            // Nothing to do.

            // 4. Build the table
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < p.Length; j++)
                {
                    char pch = p[j];
                    char sch = s[i];
                    bool match = false;

                    // Thee cases if we see a '*'
                    // 1. p[j] matches zero preceding element
                    // dp[i + 1, j + 1] = dp[i + 1, j – 1]
                    //
                    // 2. p[j] matches one preceding element
                    // dp[i + 1, j + 1] = (p[j – 1] == ‘.’ || p[j – 1] == s[j]) && dp[i + 1, j]
                    // The preceding element has to be ‘.’ or the same as B[j].
                    //
                    // 3. p[j] matches multiple preceding element
                    // dp[i + 1, j + 1] = (p[j – 1] == ‘.’ || p[j – 1] == s[j]) && dp[i, j + 1]
                    // When matching with multiple elements, preceding element has to be ‘.’ or the same as p[j].
                    if (pch == '*')
                    {
                        char prev = p[j - 1];
                        // a. Zero match: preceeding character don't match
                        if (prev != '.' && prev != sch)
                        {
                            match = dp[i + 1, j - 1];
                        }
                        else
                        {
                            // b. dp[i + 1, j]     - match one character
                            // c. dp[i, j + 1]     - match multiple character
                            // d. dp[i + 1, j - 1] - match empty character
                            match = dp[i + 1, j] || dp[i, j + 1] || dp[i + 1, j - 1];
                        }
                    }
                    // Current characters are considered as matching in two cases
                    // a. current character of pattern is '.'
                    // b. characters actually match
                    else if (pch == '.' || pch == sch)
                    {
                        match = dp[i, j];
                    }

                    dp[i + 1, j + 1] = match;
                }
            }

            return dp[s.Length, p.Length];
        }
    }
 
}
