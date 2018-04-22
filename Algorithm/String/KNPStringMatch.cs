using System;
using System.Collections.Generic;

namespace DataStructure.String
{
    public class KNPStringMatch : IStringMatch
    {

        private int[] ComputerLongestProperPrefix(char[] pattern)
        {
            var longestProperPrefix = new int[pattern.Length];
            longestProperPrefix[0] = 0;

            int l = 0;
            int i = 1;

            while(i < pattern.Length)
            {
                if(pattern[i] == pattern[l])
                {
                    longestProperPrefix[i] = ++l;
                    i++;
                }
                else
                {
                    if (l != 0)
                        l = longestProperPrefix[l - 1];
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
