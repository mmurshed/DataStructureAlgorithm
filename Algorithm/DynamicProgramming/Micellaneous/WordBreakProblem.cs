using System;
using System.Collections.Generic;
using DataStructure.Tree;

namespace Algorithm.DynamicProgramming.Micellaneous
{
    // https://www.geeksforgeeks.org/dynamic-programming-set-32-word-break-problem/
    /*
Given an input string and a dictionary of words, find out if the input string can be segmented into a space-separated sequence of dictionary words.

Consider the following dictionary 
{ i, like, sam, sung, samsung, mobile, ice, cream, icecream, man, go, mango}

Input:  ilike
Output: Yes 
The string can be segmented as "i like".

Input:  ilikesamsung
Output: Yes
The string can be segmented as "i like samsung" 
or "i like sam sung".

Alternatively, the dictionary can be a list of Periodic Element Sumbols

Symbols
{ Ba, Na, H, O }

Input: Banana
Output: Yes
The string can be segmented as "Ba Na Na"

Input: Babul
Output: No
    */
    public class WordBreakProblem
    {
        // returns true if string can be segmented into space 
        // separated words, otherwise returns false
        // O(N^Length of dictionary)
        public bool WordBreakNaive(string str, int start, HashSet<string> dictionary)
        {
            // Base case
            if (start == str.Length)
                return true;

            // Try all prefixes of lengths from 1 to size
            for (int i = start; i < str.Length; i++)
            {
                // The parameter for dictionaryContains is 
                // str.substr(0, i) which is prefix (of input 
                // string) of length 'i'. We first check whether 
                // current prefix is in  dictionary. Then we 
                // recursively check for remaining string
                // str.substr(i, size-i) which is suffix of  
                // length size-i
                if (dictionary.Contains(str.Substring(0, i)) && WordBreakNaive(str, i + 1, dictionary))
                    return true;
            }

            // If we have tried all prefixes and 
            // none of them worked
            return false;
        }

        // Returns true if string can be segmented into space separated
        // words, otherwise returns false
        public bool WordBreakDP(string str, int start, HashSet<string> dictionary)
        {
            int len = str.Length;
            if (start == len)
                return true;

            // Create the DP table to store results of subroblems. The value wb[i]
            // will be true if str[0..i-1] can be segmented into dictionary words,
            // otherwise false.
            var wb = new bool[len + 1];

            for (int i = 1; i <= len; i++)
            {
                // if wb[i] is false, then check if current prefix can make it true.
                // Current prefix is "str.Substring(0, i)"
                if (wb[i] == false && dictionary.Contains(str.Substring(0, i)))
                    wb[i] = true;

                // wb[i] is true, then check for all substrings starting from
                // (i+1)th character and store their results.
                if (wb[i] == true)
                {
                    // If we reached the last prefix
                    if (i == len)
                        return true;

                    for (int j = i + 1; j <= len; j++)
                    {
                        // Update wb[j] if it is false and can be updated
                        // Note the parameter passed to dictionaryContains() is
                        // substring starting from index 'i' and length 'j-i'
                        if (wb[j] == false && dictionary.Contains(str.Substring(i, j - i)))
                            wb[j] = true;

                        // If we reached the last character
                        if (j == len && wb[j] == true)
                            return true;
                    }
                }
            }

            /* Uncomment these lines to print DP table "wb[]"
             for (int i = 1; i <= size; i++)
                Console.Print(" " + wb[i]); */

            // If we have tried all prefixes and none of them worked
            return false;
        }

        // O(n)
        public bool WordBreakDPImproved(string str, HashSet<string> dictionary)
        {
            // Create the DP table to store results of subroblems. The value wb[i]
            // will be true if str[0..i-1] can be segmented into dictionary words,
            // otherwise false.
            var wb = new int[str.Length + 1];

            return WordBreakDPImproved(str, 0, dictionary, wb);
        }

        private bool WordBreakDPImproved(string str, int start, HashSet<string> dictionary, int[] wb)
        {
            if (start == str.Length)
                return true;

            for (int i = start; i < str.Length; i++)
            {
                // if wb[i] is false, then check if current prefix can make it true.
                // Current prefix is "str.Substring(0, i)"
                if (wb[i] == 0) // Not calculated
                    wb[i] = dictionary.Contains(str.Substring(0, i)) ? 1 : -1;

                // wb[i] is true, then check for all substrings starting from
                // (i+1)th character and store their results.
                if (wb[i] == 1 && WordBreakDPImproved(str, i + 1, dictionary, wb))
                {
                    return true;
                }
            }

            /* Uncomment these lines to print DP table "wb[]"
             for (int i = 1; i <= size; i++)
                Console.Print(" " + wb[i]); */

            // If we have tried all prefixes and none of them worked
            return false;
        }

        // https://www.geeksforgeeks.org/word-break-problem-trie-solution/
        // returns true if string can be segmented into
        // space separated words, otherwise returns false
        bool WordBreak(string str, int start, Trie trie)
        {
            int len = str.Length;

            // Base case
            if (start == len)
                return true;

            // Try all prefixes of lengths from 1 to size
            for (int i = start; i <= len; i++)
            {
                // The parameter for search is str.substr(0, i)
                // str.Substring(0, i) which is prefix (of input
                // string) of length 'i'. We first check whether
                // current prefix is in dictionary. Then we
                // recursively check for remaining string
                // str.substr(i, size-i) which is suffix of
                // length size-i
                if (trie.FindSubstring(str, 0, i) && WordBreak(str, i + 1, trie))
                    return true;
            }

            // If we have tried all prefixes and none
            // of them worked
            return false;
        }

        // O(n)
        bool WordBreakImproved(string str, int start, Trie trie)
        {
            // Base case
            if (start == str.Length)
                return true;

            Trie.Node cur = trie.Root;

            // Try all prefixes of lengths from 1 to size
            for (int i = start; i < str.Length; i++)
            {
                cur = cur.Get(str[i]);
                if (cur == null)
                    return false;
                if (cur.IsTerminal == true && WordBreak(str, i + 1, trie))
                    return true;
            }

            // If we have tried all prefixes and none
            // of them worked
            return false;
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            Trie trie = new Trie();
            foreach (var word in wordDict)
                trie.Insert(word);
            var memo = new bool[s.Length];
            return WordBreak(s, 0, trie, memo);
        }

        private bool WordBreak(string str, int start, Trie trie, bool[] memo)
        {
            // Base case
            if (start == str.Length)
                return true;
            if (memo[start])
                return false;

            Trie.Node cur = trie.Root;

            // Try all prefixes of lengths from 1 to size
            for (int i = start; i < str.Length; i++)
            {
                cur = cur.Get(str[i]);
                if (cur == null)
                {
                    memo[start] = true;
                    return false;
                }
                if (cur.IsTerminal == true && WordBreak(str, i + 1, trie, memo))
                    return true;
            }

            memo[start] = true;
            // If we have tried all prefixes and none
            // of them worked
            return false;
        }

        public bool WordBreakNR(string s, IList<string> wordDict)
        {
            Trie trie = new Trie();
            foreach (var word in wordDict)
                trie.Insert(word);
            return WordBreakNR(s, trie);
        }

        private bool WordBreakNR(string str, Trie trie)
        {
            if (str.Length == 0)
                return false;

            var memo = new bool[str.Length];
            var stack = new Stack<Tuple<Trie.Node, int>>();

            stack.Push(new Tuple<Trie.Node, int>(trie.Root, 0));

            while (stack.Count > 0)
            {
                var val = stack.Pop();

                var cur = val.Item1;
                int start = val.Item2;

                if (!memo[start])
                {
                    int lastStart = start;
                    for (int i = start; i < str.Length; i++)
                    {
                        cur = cur.Get(str[i]);

                        if (cur == null)
                            break;

                        if (cur.IsTerminal && i == str.Length - 1)
                            return true;

                        if (cur.IsTerminal)
                        {
                            lastStart = i + 1;
                            stack.Push(new Tuple<Trie.Node, int>(cur, lastStart));
                            cur = trie.Root;
                        }
                    }
                    memo[lastStart] = true;
                }
            }

            return false;
        }
    }
}
