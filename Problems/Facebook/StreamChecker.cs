using System;
namespace Problems.Facebook
{
    public class Trie
    {
        public class Node
        {
            public bool term;
            public Node[] childs;

            public Node Get(char c) => childs[c - 'a'];

            public Node Set(char c)
            {
                if (childs[c - 'a'] == null)
                    childs[c - 'a'] = new Node();
                return childs[c - 'a'];
            }

            public Node()
            {
                childs = new Node[26];
                term = false;
            }
        }

        public Node root;

        public Trie()
        {
            root = new Node();
        }

        public void InsertReverse(string word)
        {
            if (word.Length == 0)
                return;

            var cur = root;
            for (int l = word.Length - 1; l >= 0; l--)
                cur = cur.Set(word[l]);
            cur.term = true;
        }


        public bool FindReverse(char[] stream, int length)
        {
            var cur = root;
            for (int l = length - 1; l >= 0; l--)
            {
                cur = cur.Get(stream[l]);
                if (cur == null)
                    return false;
                if (cur.term)
                    return true;
            }
            return false;
        }
    }

    public class StreamChecker
    {
        private Trie t;

        private char[] stream;
        private int length;

        public StreamChecker(string[] words)
        {
            stream = new char[40005];
            length = 0;

            t = new Trie();
            foreach (var w in words)
            {
                t.InsertReverse(w);
            }
        }

        public bool Query(char c)
        {
            stream[length++] = c;
            return t.FindReverse(stream, length);
        }
    }
}
