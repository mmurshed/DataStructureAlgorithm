using System;
namespace Algorithm.Facebook
{
    public class DecodeWays
    {
        public int NumDecodings(string s)
        {
            return NumDecodings(s, 0);
        }

        private int NumDecodings(string s, int start)
        {
            if (start == s.Length)
                return 1;

            int count = 0;
            int n = 0;
            for (int i = start; i < s.Length; i++)
            {
                n = n * 10 + (int)(s[i] - '0');
                if (n == 0 || n > 26)
                    break;
                count += NumDecodings(s, i + 1);
            }

            return count;
        }

    }
}
