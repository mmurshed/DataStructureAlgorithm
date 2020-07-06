
using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithm.Facebook
{
    public class FindAnagramsProblem
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            var map = new int[256];
            var window = new int[256];
            var list = new List<int>();
            int unique = 0;
            int foundUnique = 0;

            // a b c
            // 1 1 1
            // unique = 3
            foreach (var c in p)
            {
                if (map[c - 'a'] == 0)
                    unique++;
                map[c - 'a']++;
            }


            int l = 0;
            int r = 0;
            // a b c d e
            // 2 2 0 0 1
            while (r < s.Length)
            {
                int j = s[r] - 'a';
                window[j]++;

                if (window[j] == map[j])
                    foundUnique++;

                if (unique == foundUnique)
                    list.Add(l); 

                if (r - l == p.Length - 1)
                {
                    int m = s[l] - 'a';
                    window[m]--;

                    if(window[m] < map[m] && foundUnique > 0)
                        --foundUnique;

                    l++;
                }

                r++;
            }

            return list;
        }
    }
}
