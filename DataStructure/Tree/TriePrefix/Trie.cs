using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public class Trie
    {
        private readonly TrieNode Root;

        public Trie()
        {
            Root = new TrieNode('^', 0, null);
        }

        public TrieNode Prefix(string s)
        {
            var currentTrieNode = Root;
            var result = currentTrieNode;

            foreach (var c in s)
            {
                currentTrieNode = currentTrieNode.FindChildNode(c);
                if (currentTrieNode == null)
                    break;
                result = currentTrieNode;
            }

            return result;
        }

        public bool Search(string s)
        {
            var prefix = Prefix(s);
            return prefix.Depth == s.Length && prefix.FindChildNode('$') != null;
        }

        public void InsertRange(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
                Insert(items[i]);
        }

        public void Insert(string s)
        {
            var commonPrefix = Prefix(s);
            var current = commonPrefix;

            for (var i = current.Depth; i < s.Length; i++)
            {
                var newTrieNode = new TrieNode(s[i], current.Depth + 1, current);
                current.Children.Add(newTrieNode);
                current = newTrieNode;
            }

            current.Children.Add(new TrieNode('$', current.Depth + 1, current));
        }

        public void Delete(string s)
        {
            if (Search(s))
            {
                var node = Prefix(s).FindChildNode('$');

                while (node.IsLeaf())
                {
                    var parent = node.Parent;
                    parent.DeleteChildNode(node.Value);
                    node = parent;
                }
            }
        }

    }

}
