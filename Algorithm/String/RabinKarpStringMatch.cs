using System;
using System.Collections.Generic;

namespace Algorithm.String
{
    public class RabinKarpStringMatch : IStringMatch
    {
        private const int PRIME = 101;
        private const int SIZE = 256;

        private Tuple<int, int, int> CalculateHash(string text, string pattern)
        {
            int h = 1;
            int patternHash = 0;
            int textHash = 0;
            // Horner's rule
            for (int i = 0; i < pattern.Length; i++)
            {
                if (i > 0)
                    h = (h * SIZE) % PRIME;
                patternHash = (patternHash * SIZE + pattern[i]) % PRIME;
                textHash    = (textHash    * SIZE + text[i])    % PRIME;
            }
            return new Tuple<int, int, int>(textHash, patternHash, h);
        }

        public IEnumerable<int> Search(string text, string pattern)
        {
            var hashes = CalculateHash(text, pattern);

            int textHash = hashes.Item1;
            int patternHash = hashes.Item2;
            int h = hashes.Item3;

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
                if( i < n - m)
                {
                    textHash = (SIZE * (textHash - text[i] * h) + text[i + m]) % PRIME;
                    textHash = textHash < 0 ? textHash + PRIME : textHash; // Avoid negative hash
                }
            }
        }
    }
}
