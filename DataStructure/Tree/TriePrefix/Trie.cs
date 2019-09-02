using System.Collections.Generic;
using System.Text;

namespace DataStructure.Tree
{
    /// <summary>
    /// Trie or PrefixTree
    /// </summary>
    public class Trie
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
                Node node = new Node(isterminal);
                Set(ch, node);
                return node;
            }

            public void Set(char ch, Node node)
            {
                var index = Map(ch);
                Children[index] = node;
            }

            public Node(bool isterminal)
            {
                Children = new Node[SIZE];
                IsTerminal = isterminal;
            }
        }

        public Node Root;

        public Trie()
        {
            Root = new Node(false);
        }

        public string[] GetAll()
        {
            List<string> strings = new List<string>();
            GetAll(strings, new StringBuilder(), Root);
            return strings.ToArray();
        }

        public void GetAll(List<string> strings, StringBuilder stringBuilder, Node node)
        {
            if(node.IsTerminal)
            {
                strings.Add(stringBuilder.ToString());
            }
            for (int i = 0; i < SIZE; i++)
            {
                if(node.Children[i] != null)
                {
                    stringBuilder.Append(node.GetChar(i));
                    GetAll(strings, stringBuilder, node.Children[i]);
                    stringBuilder.Length--;
                }
            }
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

        public void InsertR(string word)
        {
            InsertR(word, 0, Root);
        }

        public void InsertR(string word, int i, Node subroot)
        {
            if(i == word.Length)
            {
                subroot.IsTerminal = true;
                return;
            }
            var node = subroot.Get(word[i]);
            if (node == null)
            {
                node = subroot.Set(word[i], false);
            }

            InsertR(word, i + 1, node);
        }

        public bool Remove(string str)
        {
            return Remove(str, 0, Root);
        }

        private bool Remove(string str, int i, Node node)
        {
            if(i == str.Length)
            {
                bool end = node.IsTerminal;
                node.IsTerminal = false;
                return end;
            }

            var letter = str[i];
            var next = node.Get(letter);
            if (next == null)
                return false;
            bool removed = Remove(str, i + 1, next);
            if(removed)
            {
                bool removeNode = !next.IsTerminal;

                if (removeNode)
                {
                    foreach (var child in next.Children)
                    {
                        if (child != null)
                        {
                            removeNode = false;
                            break;
                        }
                    }
                }

                if (removeNode)
                {
                    node.Set(letter, null);
                }
            }
            return removed;
        }

        public bool FindSubstring(string word, int start, int len)
        {
            var node = Root;
            while(start < len)
            {
                node = node.Get(word[start]);
                if (node == null)
                {
                    return false;
                }
                start++;
            }
            if (node.IsTerminal)
                return true;
            return false;
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

        public bool FindR(string word)
        {
            return FindR(word, 0, Root);
        }

        public bool FindR(string word, int i, Node subroot)
        {
            if (i == word.Length)
                return subroot.IsTerminal;
            Node node = subroot.Get(word[i]);
            if (node == null)
                return false;
            return FindR(word, i+1, node);
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