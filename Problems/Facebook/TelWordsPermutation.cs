using System;
using System.Text;
using System.Collections.Generic;

namespace Algorithm.Facebook
{
    /*
Given a string as input, return the list of all the patterns possible:


'1' : ['A', 'B', 'C'], 
'2' : ['D', 'E'],
'12' : ['X']
'3' : ['P', 'Q']
Example if input is '123', then output should be [ADP, ADQ, AEP, AEQ, BDP, BDQ, BEP, BEQ, CDP, CDQ, CEP, CEQ, XP, XQ]
    */
    public class TelWordsPermutation
    {
        public List<string> GenTelWordsPermutation(Dictionary<string, List<char>> dict, string line)
        {
            var result = new List<string>();
            GenTelWordsPermutation(dict, line, 0, new StringBuilder(), result);

            return result;
        }

        private bool GenTelWordsPermutation(Dictionary<string, List<char>> dict, string line, int start, StringBuilder partial, List<string> result)
        {
            if(start == line.Length)
            {
                result.Add(partial.ToString());
                return true;
            }

            bool completed = false;
            for (int i = start + 1; i < line.Length; i++)
            {
                var sub = line.Substring(start, start + i);
                if(dict.ContainsKey(sub))
                {
                    foreach(var c in dict[sub])
                    {
                        partial.Append(c);
                        completed = completed || GenTelWordsPermutation(dict, line, i + 1, partial, result);
                        if (completed == false)
                            break;
                        partial.Length--;
                    }
                }
            }

            return completed;
        }


        public List<string> GenTelWordsPermutation2(Dictionary<string, List<char>> dict, string line)
        {
            var list = new List<List<string>>();
            GenTelWords(dict, line, 0, new List<string>(), list);

            var result = new List<string>();
            foreach (var l in list)
            {
                GenPermutation(dict, l, 0, new StringBuilder(), result);
            }

            return result;
        }

        private void GenTelWords(Dictionary<string, List<char>> dict, string line, int start, List<string> partial, List<List<string>> result)
        {
            if (start == line.Length)
            {
                result.Add(new List<string>(partial));
                return;
            }

            for (int i = start + 1; i <= line.Length; i++)
            {
                var sub = line.Substring(start, i - start);
                if (dict.ContainsKey(sub))
                {
                    int len = partial.Count;
                    partial.Add(sub);
                    GenTelWords(dict, line, i, partial, result);
                    partial.RemoveAt(len);
                }
            }
        }

        private void GenPermutation(Dictionary<string, List<char>> dict, List<string> list, int start, StringBuilder partial, List<string> result)
        {
            if (start == list.Count)
            {
                result.Add(partial.ToString());
                return;
            }
            foreach (var c in dict[list[start]])
            {
                partial.Append(c);
                GenPermutation(dict, list, start + 1, partial, result);
                partial.Length--;
            }
        }

    }
}
