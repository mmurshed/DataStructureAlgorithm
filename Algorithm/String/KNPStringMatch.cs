using System;
using System.Collections.Generic;

namespace DataStructure.String
{
    public class KNPStringMatch : IStringMatch
    {
        /*
         * A proper prefix is prefix with whole string not allowed. For example, 
         * prefixes of “ABC” are “”, “A”, “AB” and “ABC”. Proper prefixes are 
         * “”, “A” and “AB”. Suffixes of the string are “”, “C”, “BC” and “ABC”.
         * 
         * For each sub-pattern pat[0..i] where i = 0 to m-1, lps[i] stores 
         * length of the maximum matching proper prefix which is also a suffix 
         * of the sub-pattern pat[0..i].
         * 
         * lps[i] = the longest proper prefix of pat[0..i] 
         *          which is also a suffix of pat[0..i]. 
         * 
         * Note: lps[i] could also be defined as longest prefix which is also 
         * proper suffix. We need to use proper at one place to make sure that
         * the whole substring is not considered.
        */
        private int[] ComputerLongestProperPrefix(char[] pattern)
        {
            var longestProperPrefix = new int[pattern.Length];
            longestProperPrefix[0] = 0;

            int j = 0;
            int i = 1;

            while(i < pattern.Length)
            {
                if(pattern[i] == pattern[j])
                {
                    longestProperPrefix[i] = ++j;
                    i++;
                }
                else
                {
                    if (j != 0)
                        j = longestProperPrefix[j - 1];
                    else
                        longestProperPrefix[i++] = 0;
                }
            }

            return longestProperPrefix;
        }

        public IEnumerable<int> Search(char[] text, char[] pattern)
        {
            var longestProperPrefix = ComputerLongestProperPrefix(pattern);
            int i = 0;
            int j = 0;

            while(i < text.Length)
            {
                if(pattern[j] == text[i])
                {
                    i++;
                    j++;
                }

                if(j == pattern.Length)
                {
                    yield return i - j;
                    j = longestProperPrefix[j - 1];
                }
                else if(i < text.Length && pattern[j] != text[i])
                {
                    if (j != 0)
                        j = longestProperPrefix[j - 1];
                    else
                        i++;
                }
            }
        }
    }
}
