using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.UberProblems
{
    public class GroupAnagramsSolution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, List<string>>();

            foreach (var s in strs)
            {
                var str = SortString(s);
                if (dict.ContainsKey(str))
                    dict[str].Add(s);
                else
                    dict.Add(str, new List<string> { s });
            }

            return dict
                .Select(d => (IList<string>)d.Value)
                .ToList();
        }

        const int w = 26;
        int[] count = new int[w];

        string SortString(string s)
        {
            int l = s.Length;
            var t = new char[l];

            for (int i = 0; i < w; i++)
                count[i] = 0;

            for (int i = 0; i < l; i++)
                count[s[i] - 'a']++;

            for (int i = 1; i < w; i++)
                count[i] += count[i - 1];

            for (int i = 0; i < l; i++)
            {
                var index = s[i]-'a';
                count[index]--;
                t[count[index]] = s[i];
            }

            return new string(t);
        }

        int Hashcode(string s)
        {
            int l = s.Length;
            int hash = 19;

            for (int i = 1; i < w; i++)
                count[w] = 0;

            for (int i = 0; i < l; i++)
                count[s[i] - 'a']++;

            for (int i = 0; i < w; i++)
            {
                int c = i + 'a';
                while (count[i] > 0)
                {
                    hash = hash * 31 + c;
                    count[i]--;
                }
                hash %= Int32.MaxValue;
            }

            return hash;
        }
    }
}
