using System;
using System.Collections.Generic;

namespace DataStructure.String
{
    public class BoyerMooreStringMatch : IStringMatch
    {
        private const int SIZE = 256;

        private int[] ComputerLastOccurrences(char[] text)
        {
            var lastOccurrences = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
                lastOccurrences[i] = -1;
            for (int i = 0; i < text.Length; i++)
                lastOccurrences[text[i]] = i;
            return lastOccurrences;
        }

        public IEnumerable<int> Search(char[] text, char[] pattern)
        {
            var lastOccurences = ComputerLastOccurrences(text);

            int shift = 0;

            while(shift <= text.Length - pattern.Length)
            {
                int j = pattern.Length - 1;
                while (j >= 0 && pattern[j] == text[shift + j])
                    j--;
                if(j < 0) // Found
                {
                    yield return shift;
                    int patternPos = shift + pattern.Length;
                    shift += patternPos < text.Length ? pattern.Length - lastOccurences[text[patternPos]] : 1;
                }
                else
                {
                    shift += Math.Max(1, j - lastOccurences[text[j + shift]]);
                }
            }
        }
    }
}
