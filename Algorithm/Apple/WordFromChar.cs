using System;
using System.Collections.Generic;

namespace Algorithm.Apple
{
    /*
     * https://www.careercup.com/question?id=5619363327508480
     * given 2 arrays wrds[] , chars[] as an input to a function such that 
wrds[] = [ "abc" , "baa" , "caan" , "an" , "banc" ] 
chars[] = [ "a" , "a" , "n" , "c" , "b"] 
Function should return the longest word from words[] which can be constructed from the chars in chars[] array. 
for above example - "caan" , "banc" should be returned 

Note: Once a character in chars[] array is used, it cant be used again. 
eg: words[] = [ "aat" ] 
characters[] = [ "a" , "t" ] 
then word "aat" can't be constructed, since we've only 1 "a" in chars[].
    */
    public class WordFromChar
    {
        public string[] FindWordsFromChar(string [] words, char[] chars)
        {
            var list = new List<string>();
            var dict = new int[26];

            int maxLen = 0;

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                    dict[j] = 0;
                for (int j = 0; j < chars.Length; j++)
                    dict[chars[j] - 'a']++;

                bool found = true;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if(dict[words[i][j]] == 0)
                    {
                        found = false;
                        break;
                    }
                }
                if (found && words[i].Length >= maxLen)
                    list.Add(words[i]);
            }

            return list.ToArray();
        }
    }
}
