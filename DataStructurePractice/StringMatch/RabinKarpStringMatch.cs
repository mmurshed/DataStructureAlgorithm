using System;
using System.Collections.Generic;

namespace DataStructurePractice.StringMatch
{
    public class RabinKarpStringMatch : IStringMatch
    {
        private const int PRIME = 101;
        private const int SIZE = 256;

        private Tuple<int, int, int> CalculateHash(char[] text, char[] pattern)
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
                textHash = (textHash * SIZE + pattern[i]) % PRIME;
            }
            return new Tuple<int, int, int>(textHash, patternHash, h);
        }

        public IEnumerable<int> Search(char[] text, char[] pattern)
        {
            var hashes = CalculateHash(text, pattern);

            int patternHash = hashes.Item1;
            int textHash = hashes.Item2;
            int h = hashes.Item3;

            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                if (patternHash == textHash)
                {
                    int j = 0;
                    while (j < pattern.Length && pattern[j] == text[i + j])
                        j++;
                    if (j == pattern.Length)
                        yield return i;
                }

                // Recalculate hash by pushing the first char out and inserting the new char in the back
                if( i < text.Length - pattern.Length)
                {
                    textHash = (SIZE * (textHash - text[i] * h) + text[i + pattern.Length]) % PRIME;
                    textHash = textHash < 0 ? textHash + PRIME : textHash; // Avoid negative hash
                }
            }
        }
    }
}
