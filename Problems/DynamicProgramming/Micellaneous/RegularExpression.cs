using System;
namespace Algorithm.Facebook
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

        private bool IsMatchNaive2(string s, int si, string p, int pi)
        {
            if (pi >= p.Length && si >= s.Length)
                return true;
            if (pi >= p.Length)
                return false;

            if (p[pi] == '.' || (si < s.Length && p[pi] == s[si]))
                return IsMatchNaive(s, ++si, p, ++pi);
            else if (p[pi] == '*')
            {
                char prev = p[pi - 1];
                if (prev != '.' || prev != s[si])
                    return IsMatchNaive(s, si + 1, p, pi - 1); // Zero match

                return
                    IsMatchNaive(s, si + 1, p, pi) || // One match
                    IsMatchNaive(s, si, p, pi + 1) || // multiple match
                    IsMatchNaive(s, si + 1, p, pi - 1); // Zero match
            }

            return false;
        }

        // https://xiaokangstudynotes.com/2017/01/21/dynamic-programming-regular-expression-matching/
        // https://www.geeksforgeeks.org/wildcard-pattern-matching/

        /*
         * Given a text and a wildcard pattern, implement wildcard pattern matching algorithm 
         * that finds if wildcard pattern is matched with text. The matching should cover the 
         * entire text (not partial text).
         * 
         * The wildcard pattern can include the characters ‘?’ and ‘*’
         * ‘?’ – matches any single character
         * ‘*’ – Matches any sequence of characters (including the empty sequence)
         * 
         * For example,
         * 
         * Text = "baaabab",
         * Pattern = "*****ba*****ab", output : true
         * Pattern = "a*ab", output : false
         * Pattern = "ba*a?", output : true
         * Pattern = "baaa?ab", output : true
         * 
         *          
         * Text    = |     |ba| aab |ab|
         * Pattern = |*****|ba|*****|ab|
         * Output  = true
         * 
         * 
         *              no matching text
         *               |
         *              \/
         * Text    = |     |baaab|ab|
         * Pattern = |    a|  *  |ab|
         * Output  = false
         * 
         * 
         * Text    =       |ba|aab|ab|
         * Pattern =       |ba| * |a?|
         * Output  = true
         * 
         * Each occurrence of ‘?’ character in wildcard pattern can be replaced 
         * with any other character and each occurrence of ‘*’ with a sequence 
         * of characters such that the wildcard pattern becomes identical to 
         * the input string after replacement.
         * 
         * Let’s consider any character in the pattern.
         * 
         * Case 1: The character is ‘*’
         * 
         * Here two cases arise
         * 1a. We can ignore ‘*’ character and move to next character in the Pattern.
         * 
         * 1b. ‘*’ character matches with one or more characters in Text.
         *      Here we will move to next character in the string.
         * 
         * Case 2: The character is ‘?’
         * We can ignore current character in Text and move to next character 
         * in the Pattern and Text.
         * 
         * Case 3: The character is not a wildcard character
         * If current character in Text matches with current character in 
         * Pattern, we move to next character in the Pattern and Text. If they 
         * do not match, wildcard pattern and Text do not match.
         * 
         * We can use Dynamic Programming to solve this problem -
         * 
         * Let T[i][j] is true if first i characters in given string matches the first j characters of pattern.
         * 
         * DP Initialization:
         * 
         * both text and pattern are null
         * T[0][0] = true; 
         * 
         * pattern is null
         * T[i][0] = false; 
         * 
         * text is null
         * T[0][j] = T[0][j - 1] if pattern[j – 1] is '*'  
         * 
         * 
         * DP relation :
         * 
         * If current characters match, result is same as 
         * result for lengths minus one. Characters match
         * in two cases:
         * 
         * a) If pattern character is '?' then it matches  
         *    with any character of text. 
         * b) If current characters in both match
         * 
         * if (pattern[j – 1] == ‘?’) || (pattern[j – 1] == text[i - 1])
         *     T[i][j] = T[i-1][j-1]
         *     
         * If we encounter ‘*’, two choices are possible -
         *   a) We ignore ‘*’ character and move to next 
         *      character in the pattern, i.e., ‘*’ 
         *      indicates an empty sequence.
         *   b) '*' character matches with ith character in input 
         *   
         * else if (pattern[j – 1] == ‘*’)
         *     T[i][j] = T[i][j-1] || T[i-1][j]  
         * 
         * pattern[j – 1] is not equal to text[i - 1]
         *  
         * else 
         *     T[i][j]  = false 
         */
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
                    dp[0, i] = dp[0, i - 1];

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= p.Length; j++)
                {
                    // Two cases if we see a '*' 
                    // a) We ignore '*' character and move 
                    //    to next  character in the pattern, 
                    //     i.e., '*' indicates an empty sequence. 
                    // b) '*' character matches with ith 
                    //     character in input 
                    if (p[j - 1] == '*')
                        dp[i, j] = dp[i, j - 1] || dp[i - 1, j];

                    // Current characters are considered as 
                    // matching in two cases 
                    // (a) current character of pattern is '?' 
                    // (b) characters actually match 
                    else if (p[j - 1] == '?' || s[i - 1] == p[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];

                    // If characters don't match 
                    else dp[i, j] = false;
                }
            }

            return dp[s.Length, p.Length];
        }
    }

}
