using System;
using System.Collections.Generic;

namespace DataStructurePractice.StringMatch
{
    public class NaiveStringMatch : IStringMatch
    {
        public IEnumerable<int> Search(char[] text, char[] pattern)
        {
            for (int i = 0; i <= text.Length - pattern.Length; i++)
            {
                int j = 0;
                while (j < pattern.Length && pattern[j] == text[i + j])
                    j++;
                if (j == pattern.Length)
                    yield return i;
            }
        }
    }
}
