using System;
using System.Collections.Generic;

namespace Algorithm.String
{
    public class RabinKarpStringMatch : IStringMatch
    {
        private const int PRIME = 101;
        private const int d = 256;

        /*
         * Hash must be fast for this algorithm to work efficiently.
         * Hash of text[s+1...s+m], must efficiently computable from the
         * hash text[s..s+m-1]
         * 
         * Rabin-Karp suggested
         * "127" --->  127
         * 
         * Hash of pattern, p, length m
         * h_p = p[m-1] + 10(p[m-2] + ... 10(p[1] + 10p[0]))
         * aka. Horner's Rule
         * 
         * Instead of 10, we use d = 256 (# alphabets)
         * To keep the hash value small we mod by a primer number.
         * 
         * Hash of pattern, p, length m
         * h_t = p[m-1] + d*(p[m-2] + ... d*(p[1] + d*p[0])
         *     = p[m-1] + d*p[m-2] + d^2*p[m-3] + ... + d^(m-2)*p[1] + d^(m-1)*p[0]
         * 
         * Hash of text, t, upto length m
         * h_t = t[m-1] + t*(p[m-2] + ... d*(t[1] + d*t[0]))
         * 
         * Thus
         * Hash(text[s+1...s+m]) = d * ( Hash(text[s...s+m-1] - text[s] * h ) + text[s+m]
         * where h = d^(m-1)
         * 
         * Example:
         * d = 10
         * m = 3
         * text = "1357898"
         * pattern = "785"
         * 
         * h_p = 5 + 10(8 + 10*7)
         *     = 5 + 10*8 + 10^2*7
         *     = 5 + 80 + 700
         *     = 785
         *     
         * h = 10^(m-1) = 10^2 = 100
         * 
         * text[0..m] = "135"
         * h_t = 5 + 10(3 + 10*1) = 135
         * 
         *                           123
         * New h_t for text[1..m+1] "357"
         * 
         * h'_t = 10*(h_t-text[0]*h) + text[3]
         *      = 10*(135-1*100) + 7
         *      = 10*35 + 7
         *      = 357
         */
        private (int, int, int) CalculateHash(string text, string pattern)
        {
            int h = 1;
            int patternHash = 0;
            int textHash = 0;
            // Horner's rule
            for (int i = 0; i < pattern.Length; i++)
            {
                if (i > 0)
                    h = (h * d) % PRIME;
                patternHash = (patternHash * d + pattern[i]) % PRIME;
                textHash    = (textHash    * d + text[i])    % PRIME;
            }
            return (textHash, patternHash, h);
        }

        public IEnumerable<int> Search(string text, string pattern)
        {
            var (textHash, patternHash, h) = CalculateHash(text, pattern);

            int m = pattern.Length;
            int n = text.Length;

            for (int i = 0; i <= n - m; i++)
            {
                if (patternHash == textHash)
                {
                    int j = 0;
                    while (j < m && pattern[j] == text[i + j])
                        j++;
                    if (j == m)
                        yield return i;
                }

                // Recalculate hash by pushing the first char out and inserting the new char in the back
                if(i < n - m)
                {
                    textHash = (d * (textHash - text[i] * h) + text[i + m]) % PRIME;
                    textHash = textHash < 0 ? textHash + PRIME : textHash; // Avoid negative hash
                }
            }
        }
    }
}
