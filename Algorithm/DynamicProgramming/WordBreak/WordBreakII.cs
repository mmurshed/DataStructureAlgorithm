using System;
using System.Collections.Generic;
using DataStructure.Tree;
using System.Text;
using System.Linq;

namespace Algorithm.DynamicProgramming.Micellaneous
{
    //public class Trie
    //{
    //    public const int SIZE = 26;
    //    public class Node
    //    {
    //        public bool IsTerminal;

    //        public Node[] Children;

    //        private int Map(char ch)
    //        {
    //            return char.ToUpper(ch) - 'A';
    //        }

    //        public Node Get(char ch)
    //        {
    //            return Children[Map(ch)];
    //        }

    //        public Node Set(char ch, bool isterminal)
    //        {
    //            var index = Map(ch);
    //            Children[index] = new Node(isterminal);
    //            return Children[index];
    //        }

    //        public Node(bool isterminal)
    //        {
    //            Children = new Node[SIZE];
    //            IsTerminal = isterminal;
    //        }
    //    }

    //    public Node Root;

    //    public Trie()
    //    {
    //        Root = new Node(false);
    //    }

    //    public void Insert(string word)
    //    {
    //        var node = Root;
    //        for (int len = 0; len < word.Length; len++)
    //        {
    //            var letter = word[len];
    //            var next = node.Get(letter);
    //            if (next == null)
    //            {
    //                next = node.Set(letter, len == word.Length - 1);
    //            }
    //            else if (next != null && len == word.Length - 1)
    //            {
    //                next.IsTerminal = true;
    //            }
    //            node = next;
    //        }
    //    }
    //}

    // https://leetcode.com/problems/word-break-ii/description/
    public class WordBreakII
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            Trie trie = new Trie();
            foreach (var word in wordDict)
                trie.Insert(word);
            var memo = new bool[s.Length];
            var queue = new LinkedList<string>();
            var list = new List<string>();
            WordBreak(s, 0, trie, memo, queue, list);
            return list;
        }


        private string Combine(LinkedList<string> queue)
        {
            var strb = new StringBuilder();
            var en = queue.GetEnumerator();
            bool first = true;
            while(en.MoveNext())
            {
                if (!first)
                    strb.Append(' ');
                strb.Append(en.Current);
                first = false;
            }
            return strb.ToString();
        }

        private bool WordBreak(string str, int start, Trie trie, bool[] memo, LinkedList<string> queue, List<string> list)
        {
            // Base case
            if (start == str.Length)
            {
                if (queue.Count > 0)
                    list.Add(Combine(queue));
                return true;
            }
            if (memo[start])
                return false;

            var cur = trie.Root;

            memo[start] = true;
            for (int i = start; i < str.Length; i++)
            {
                cur = cur.Get(str[i]);
                if (cur == null)
                    break;

                if (cur.IsTerminal)
                {
                    queue.AddLast(str.Substring(start, i - start + 1));
                    bool wb = WordBreak(str, i + 1, trie, memo, queue, list);
                    queue.RemoveLast();
                    if(wb)
                        memo[start] = false;
                }
            }

            return !memo[start];
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
