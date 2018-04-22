using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructurePractice.GoogleProblems
{
    public static class ValidWordAbbreviation
    {
        public class Abbreviation
        {
            public string Word;
            public int Length;

            public Abbreviation(string word, int length)
            {
                Word = word;
                Length = length;
            }
        }
        /*
A string such as "word" contains the following abbreviations:
["word", "1ord", "w1rd", "wo1d", "wor1", "2rd", "w2d", "wo2", "1o1d", "1or1", "w1r1", "1o2", "2r1", "3d", "w3", "4"]
Given a target string and a set of strings in a dictionary, find an abbreviation of this target string with thesmallest possible length such that it does not conflict with abbreviations of the strings in the dictionary.
Each number or letter in the abbreviation is considered length = 1. For example, the abbreviation "a32bc" has length = 4.
Note:
In the case of multiple answers as shown in the second example below, you may return any one of them.
Assume length of target string = m, and dictionary size = n. You may assume that m ≤ 21, n ≤ 1000, and log2(n) + m ≤ 20.

Examples:
"apple", ["blade"] -> "a4" (because "5" or "4e" conflicts with "blade")

"apple", ["plain", "amber", "blade"] -> "1p3" (other valid answers include "ap3", "a3e", "2p2", "3le", "3l1").


This is a combination of Valid Word Abbreviation and Generalized Abbreviation. We first find all abbreviations for the target word, then check with each word in the dict to see if it conflicts with any one of them (by checking if the abbreviation is a valid one for the word in the dict). Since we need to find the abbreviation with the minimum length, we use a priority queue which is ordered by length. Thus the first valid abbreviation is the one we want.
        */

        public static string MinimumUniqueWordAbbreviation(string word, string[] dict)
        {
            var abbriviations = GenerateAbbreviations2(word).OrderBy(x => x.Length);
            foreach(var abbr in abbriviations)
            {
                bool isValid = true;
                foreach(var wordindict in dict)
                {
                    if(ValidAbbr(wordindict, abbr.Word))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                    return abbr.Word;
            }
            return string.Empty;
        }

        public static List<Abbreviation> GenerateAbbreviations2(string word)
        {
            var abbr = new List<Abbreviation>();
            if (word.Length == 0)
            {
                return abbr;
            }
            GetWords(word, ref abbr, new StringBuilder(), 0, 0, 0);
            return abbr;
        }

        private static void GetWords(string word, ref List<Abbreviation> abbr, StringBuilder curStr, int currLength, int start, int gap)
        {
            int len = curStr.Length;

            if (start == word.Length)
            {
                if (gap > 0)
                {
                    curStr.Append(gap);
                    currLength++;
                }
                abbr.Add(new Abbreviation(curStr.ToString(), currLength) );
            }
            else
            {
                GetWords(word, ref abbr, curStr, currLength, start + 1, gap + 1);
                if (gap > 0)
                {
                    curStr.Append(gap);
                    currLength++;
                }
                curStr.Append(word[start]);
                currLength++;
                GetWords(word, ref abbr, curStr, currLength, start + 1, 0);
            }

            // Backtrack
            curStr.Remove(len, curStr.Length - len);
        }

        public static List<string> GenerateAbbreviations(string word)
        {
            List<string> abbr = new List<string>();
            if (word.Length == 0)
            {
                return abbr;
            }
            GetWords(word, ref abbr, new StringBuilder(), 0, 0);
            return abbr;
        }

        private static void GetWords(string word, ref List<string> abbr, StringBuilder curStr, int start, int gap)
        {
            int len = curStr.Length;

            if (start == word.Length)
            {
                if (gap > 0)
                {
                    curStr.Append(gap);
                }
                abbr.Add(curStr.ToString());
            }
            else
            {
                GetWords(word, ref abbr, curStr, start + 1, gap + 1);
                if (gap > 0)
                {
                    curStr.Append(gap);
                }
                curStr.Append(word[start]);
                GetWords(word, ref abbr, curStr, start + 1, 0);
            }

            // Backtrack
            curStr.Remove(len, curStr.Length - len);
        }

        public static List<string> GenerateAbbr(string str, int start, int gap)
        {
            if (gap >= str.Length)
                return null;

            List<string> abbr = new List<string>();

            string gapstr = gap.ToString();

            for (int s = start; s < str.Length; s++)
            {
                string newstr = str.Substring(0, s) + gapstr;
                for (int e = s + gap; e < str.Length; e++)
                {
                    var list = GenerateAbbr(str, s, e);
                    foreach (var item in list)
                        abbr.Add(newstr + item);
                }
            }

            return abbr;
        }

        public static List<string> GenerateAbbr(string str)
        {
            var abbr = GenerateAbbr(str, 0, 1);

            return abbr;
        }

        public static List<string> GenerateAbbr2(string str)
        {
            List<string> abbr = new List<string>();
            if (str == null || str.Length == 0)
                return abbr;
            var list = GenerateAbbr2R(str);
            abbr.AddRange(list);
            abbr.Add(str.Length.ToString());
            return abbr;
        }

        public static List<string> GenerateAbbr2R(string str)
        {
            List<string> abbr = new List<string>();
            if (str == null || str.Length == 0)
                return abbr;

            abbr.Add(str);
            for (int gap = 1; gap < str.Length; gap++)
            {
                string gapstr = gap.ToString();
                for (int start = 0; start <= str.Length; start++)
                {
                    int end = start + gap;
                    if (end > str.Length)
                        break;

                    if (end < str.Length - 1)
                    {
                        var newstr = str.Substring(0, start) + gapstr + str.Substring(end, 1);
                        var list = GenerateAbbr2(str.Substring(end + 1));
                        foreach (var item in list)
                            abbr.Add(newstr + item);
                    }
                    else
                    {
                        var newstr = str.Substring(0, start) + gapstr + str.Substring(end);
                        abbr.Add(newstr);
                    }
                }
            }

            return abbr;
        }

        // True: "internationalization", "i12iz5"
        // True: "internationalization", "i12iz4n"
        // False: "internationalizatio", "i12iz4n"
        // False: "internationalization", "i12iz4"
        // False: "jnternationalization", "i12iz4n"
        public static bool ValidAbbr(string s, string abbr)
        {
            int i = 0;
            int a = 0;
            int num = 0;
            while(a < abbr.Length && i < s.Length)
            {
                char ch = abbr[a];

                if(ch >= '0' && ch <= '9')
                {
                    num = num * 10 + (ch - '0');
                    a++;
                }
                else
                {
                    if (num != 0)
                    {
                        i += num;
                        num = 0;
                    }

                    if (i < s.Length && s[i] == ch)
                    {
                        i++;
                        a++;
                    }
                    else
                        return false;
                }
            }
            i += num;

            if(a == abbr.Length && i == s.Length)
                return true;

            return false;
        }
    }
}
