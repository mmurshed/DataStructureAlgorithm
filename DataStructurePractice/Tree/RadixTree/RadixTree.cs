using System;
using System.Collections.Generic;

namespace Tree
{
    public class RadixTree
    {
        public class Node
        {
            public bool IsTerminal;
            public string Label;
            public Dictionary<string, Node> Children;

            public Node() : this(null, false)
            {   
            }

            public Node(string label, bool terminal)
            {
                Label = label;
                IsTerminal = terminal;
                Children = new Dictionary<string, Node>();
            }

            public Node Get(string str)
            {
                return Children[str];
            }

            public Node Insert(string str, bool terminal)
            {
                var node = new Node(str, terminal);
                Children[str] = node;
                return node;
            }
        }

        public Node Root;

        public RadixTree()
        {
            Root = new Node();
        }

        public void Insert(string word)
        {
            Insert(word, Root);
        }

        private void Insert(string word, Node node)
        {
            if (word == null)
                return;
            if(word.Length == 0)
            {
                node.IsTerminal = true;
                return;
            }

            var childMatch = FindChildMatch(word, node);
            int l = childMatch.Item1;
            Node match = childMatch.Item2;

            if(l == 0)
            {
                node.Insert(word, true);
                return;
            }


            if(l == match.Label.Length)
            {
                Insert(word.Substring(l), match);
                return;
            }


            if(l < word.Length || l < match.Label.Length)
            {
                Insert(word.Substring(l), match);
                Insert(match.Label.Substring(l), match);

                node.Children.Remove(match.Label);
                match.Label = match.Label.Substring(0, l);
                node.Children.Add(match.Label, match);
            }
        }

        private Tuple<int, Node> FindChildMatch(string word, Node node)
        {
            int l = 0;
            Node match = null;
            foreach (var child in node.Children)
            {
                l = FindMatch(word, child.Key);
                if (l != 0)
                {
                    match = child.Value;
                    break;
                }
            }
            return new Tuple<int, Node>(l, match);
        }

        private int FindMatch(string word, string label)
        {
            if (word == null || label == null)
                return 0;
            int l = 0;
            int len = Math.Min(word.Length, label.Length);
            while (l < len && word[l] == label[l])
                l++;
            return l;
        }

        public Node Find(string word)
        {
            return Find(word, Root, false);
        }

        public Node FindPartial(string word)
        {
            return Find(word, Root, true);
        }

        private Node Find(string word, Node node, bool findPartial)
        {
            if (word == null)
                return null;
            if (word.Length == 0)
            {
                return node.IsTerminal || findPartial ? node : null;
            }

            var childMatch = FindChildMatch(word, node);
            int l = childMatch.Item1;
            Node match = childMatch.Item2;

            if (match == null)
                return null;

            if(l == word.Length)
            {
                return match.IsTerminal || findPartial ? match : null;
            }

            if (l < word.Length && l == match.Label.Length)
            {
                return Find(word.Substring(l), match, findPartial);
            }

            return null;
        }
    }
}