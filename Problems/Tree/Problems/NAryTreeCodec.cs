
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Algorithm.Tree.Problems.NAryCodec
{
    // Definition for a Node.
    public class Node {
        public int val;
        public IList<Node> children;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }

    public class Codec
    {
        private readonly char seperator;
        private readonly char start;
        private readonly char end;

        public Codec(char sep = ',', char start = '[', char end = ']')
        {
            this.seperator = sep;
            this.start = start;
            this.end = end;
        }

        public string serialize(Node root)
        {
            if (root == null)
                return string.Empty;

            var strb = new StringBuilder();
            serialize(root, strb);

            return strb.ToString();
        }

        // DFS
        private void serialize(Node root, StringBuilder strb)
        {
            if (root == null)
                return;

            strb.Append(root.val.ToString());

            if (root.children == null || root.children.Count == 0)
                return;

            strb.Append(start);

            bool beginning = true;
            foreach (var child in root.children)
            {
                if (!beginning)
                    strb.Append(seperator);

                serialize(child, strb);

                if (beginning)
                    beginning = false;
            }

            strb.Append(end);
        }

        public Node deserialize(string data)
        {
            if (data == null || data == string.Empty)
                return null;

            int d = 0;
            int i = 0;

            while(i < data.Length && data[i] != start)

            {
                d *= 10;
                d += (int)(data[i] - '0');
                i++;
            }

            var root = new Node(d, new List<Node>());

            deserialize(root, data, i);

            return root;
        }

        public int deserialize(Node root, string data, int i)
        {
            if (i >= data.Length)
                return i;

            if (data[i] == start)
                i++;

            int d = 0;
            var child = new Node(d, new List<Node>());

            while (data[i] != end && i < data.Length)
            {
                if (data[i] == start)
                {
                    i = deserialize(child, data, i);
                    continue;
                }
                else if (data[i] == seperator)
                {
                    child.val = d;
                    root.children.Add(child);

                    d = 0;
                    child = new Node(d, new List<Node>());
                }
                else
                {
                    d *= 10;
                    d += (int)(data[i] - '0');
                }
                i++;
            }

            if (data[i] == end)
            {
                if (d > 0)
                {
                    child.val = d;
                    root.children.Add(child);
                }

                i++;
            }

            return i;
        }
    }


    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}
