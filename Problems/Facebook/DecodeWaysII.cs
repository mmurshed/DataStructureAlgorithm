using System;
using System.Linq;

namespace Algorithm.Facebook
{
    public class DecodeWaysII
    {
        private const int M = 1000000007;
        private int[] memo;
        public int NumDecodings(string s)
        {
            memo = Enumerable.Repeat(-1, s.Length).ToArray();
            return NumDecodings(s, s.Length - 1);
        }

        public int NumDecodings2(string s)
        {
            return NumDecodings(s, 0);
        }
        private int NumDecodingsDeprecated(string s, int start)
        {
            if (start == s.Length)
                return 1;

            int count = 0;
            int n = 0;
            for (int i = start; i < s.Length; i++)
            {
                if (i > start && s[i] == '*' && s[i-1] == '*')
                {
                    count += 15 * NumDecodings(s, i + 1);
                    count %= M;
                    continue;
                }

                if (s[i] == '*')
                {
                    n = n * 10 + 9;
                }
                else
                {
                    n = n * 10 + (int)(s[i] - '0');
                }

                if (n != 99 && (n == 0 || n > 29))
                    break;
                int c = 1;
                if (s[i] == '*' && n > 26)
                    c = 6;
                else if (s[i] == '*')
                    c = 9;
                else if (i > start && s[i] < '7' && s[i - 1] == '*')
                {
                    c = 2;
                }
                if (c == 1 && n == 99)
                    break;

                count += c * NumDecodings(s, i + 1);
                count %= M;
            }

            return count;
        }

        public int NumDecodings(string s, int i)
        {
            if (i < 0)
                return 1;
            if (memo[i] != -1)
                return memo[i];

            long res = 0;
            if (s[i] == '*')
            {
                res = 9 * NumDecodings(s, i - 1);

                if (i > 0)
                {
                    long num = NumDecodings(s, i - 2);
                    if (s[i - 1] == '1') // 1*
                        res += 9 * num;
                    else if (s[i - 1] == '2') // 2*
                        res += 6 * num;
                    else if (s[i - 1] == '*') // **
                        res += 15 * num;
                }
            }
            else
            {
                res = s[i] == '0' ? 0 : NumDecodings(s, i - 1);

                if (i > 0)
                {
                    long num = NumDecodings(s, i - 2);
                    if (s[i - 1] == '1') // 1[0-9]
                        res += num;
                    else if (s[i - 1] == '2' && s[i] < '7') // 2[0-6]
                        res += num;
                    else if (s[i - 1] == '*') // *[0-9]
                        res += (s[i] < '7' ? 2 : 1) * num;
                }
            }
            memo[i] = (int)(res % M);
            return memo[i];
        }
    }
}
