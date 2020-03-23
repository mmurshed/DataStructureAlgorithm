using System;
using System.Collections.Generic;

class LevelOrderTraversal
{
    public class Node
    {
        public int data;
        public Node Left;
        public Node Right;
        public Node Next;
        public Node(int d) { data = d; }
    }

    private static void Connect(Node root)
    {
        var q = new Queue<Tuple<Node, int>>();

        q.Enqueue(new Tuple<Node, int>(root, 0));

        Node prev = null;
        int prevLevel = 0;

        while (q.Count != 0)
        {
            var x = q.Dequeue();
            if (x.Item1.Left != null)
                q.Enqueue(new Tuple<Node, int>(x.Item1.Left, x.Item2 + 1));
            if (x.Item1.Right != null)
                q.Enqueue(new Tuple<Node, int>(x.Item1.Right, x.Item2 + 1));
            if (prev == null || prevLevel != x.Item2)
            {
                prev = x.Item1;
                prevLevel = x.Item2;
                Console.WriteLine("{0}", x.Item1.data);
            }
            else
            {
                prev.Next = x.Item1;
                Console.WriteLine("{0}->{1}", prev.data, x.Item1.data);
                prev = x.Item1;
            }
        }
    }


    public static void Test()
    {
        Node root = new Node(10);
        root.Left = new Node(9);
        root.Right = new Node(8);
        root.Right.Left = new Node(7);
        root.Right.Right = new Node(6);
        root.Left.Left = new Node(5);
        root.Left.Right = new Node(4);

        Connect(root);
    }
}