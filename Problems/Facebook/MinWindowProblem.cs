
using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithm.Facebook
{
    public class MinWindowProblem
    {
        public string MinWindow(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
                return string.Empty;

            if (s.Length < t.Length)
                return string.Empty;

            var hash = new int[256];
            var window = new int[256];

            for (int i = 0; i < 256; i++)
            {
                hash[i] = 0;
                window[i] = 0;
            }

            int unique = 0;

            for (int i = 0; i < t.Length; i++)
            {
                var c = t[i];
                if (hash[c] == 0)
                    unique++;
                hash[c]++;
            }


            int l = 0;
            int r = 0;

            int minl = -1;
            int minr = s.Length;
            int formed = 0;

            while (r < s.Length)
            {
                while (r < s.Length && formed < unique)
                {
                    var c = s[r];
                    window[c]++;
                    if (hash[c] > 0 && window[c] == hash[c])
                        formed++;
                    r++;
                }

                while (l <= r && formed == unique)
                {
                    if (minl == -1 || r - l < minr - minl + 1)
                    {
                        minl = l;
                        minr = r - 1;
                    }

                    var c = s[l];
                    window[c]--;
                    if (hash[c] > 0 && window[c] < hash[c])
                        formed--;
                    l++;
                }
            }

            if (minl == -1)
                return string.Empty;

            return s.Substring(minl, minr - minl + 1);

        }


    }
}
