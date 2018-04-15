using System.Collections.Generic;

namespace Tree
{
    /// <summary>
    /// Trie or PrefixTree
    /// </summary>
    public class MahbubTrie
    {
        public const int SIZE = 26;
        public class Node
        {
            public bool IsTerminal;

            public Node[] Children;

            private int Map(char ch)
            {
                return char.ToUpper(ch) - 'A';
            }

            public char GetChar(int i)
            {
                return (char)(i + 'A');
            }

            public Node Get(char ch)
            {
                return Children[Map(ch)];
            }

            public Node Set(char ch, bool isterminal)
            {
                var index = Map(ch);
                Children[index] = new Node(isterminal);
                return Children[index];
            }

            public Node(bool isterminal)
            {
                Children = new Node[SIZE];
                IsTerminal = isterminal;
            }
        }

        public Node Root;

        public MahbubTrie()
        {
            Root = new Node(false);
        }

        public void Insert(string word)
        {
            var node = Root;
            for (int len = 0; len < word.Length; len++)
            {
                var letter = word[len];
                var next = node.Get(letter);
                if (next == null)
                {
                    next = node.Set(letter, len == word.Length - 1);
                }
                else if(next != null && len == word.Length - 1)
                {
                    next.IsTerminal = true;
                }
                node = next;
            }            
        }

        public bool Find(string word)
        {
            var node = Root;
            foreach(var letter in word)
            {
                node = node.Get(letter);
                if (node == null)
                {
                    return false;
                }
            }
            if (node.IsTerminal)
                return true;
            return false;
        }

        public bool StartsWith(string word)
        {
            var node = Root;
            foreach (var letter in word)
            {
                node = node.Get(letter);
                if (node == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}