using System;
using System.Text;
using System.Collections.Generic;

namespace Algorithm.FacebookProblems
{
    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node() { }
        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right)
        {
            val = _val;
            left = _left;
            right = _right;
        }
    }

    public class NodePair
    {
        public Node head;
        public Node tail;
        public NodePair(Node h, Node t)
        {
            head = h;
            tail = t;
        }
        public NodePair() { }
    }

    public class TreeToDoublyLinkedList
    {
        public Node TreeToDoublyList(Node root)
        {
            if (root == null)
                return root;
            var pair = TreeToDoublyListInternal(root);


            pair.tail.right = pair.head;
            pair.head.left = pair.tail;

            return pair.head;

        }

        public NodePair TreeToDoublyListInternal(Node root)
        {
            if(root.left == null && root.right == null)
            {
                return new NodePair(root, root);
            }

            NodePair leftBranch = null;
            NodePair rightBranch = null;

            if (root.left != null)
            {
                leftBranch = TreeToDoublyListInternal(root.left);
                
            }
            if (root.right != null)
            {
                rightBranch = TreeToDoublyListInternal(root.right);
            }

            Node head = null, tail = null;

            if (leftBranch != null && rightBranch != null)
            {
                rightBranch.head.left = root;
                root.right = rightBranch.head;

                leftBranch.tail.right = root;
                root.left = leftBranch.tail;

                head = leftBranch.head;
                tail = rightBranch.tail;
            }
            else if(leftBranch != null && rightBranch == null)
            {
                leftBranch.tail.right = root;
                root.left = leftBranch.tail;

                head = leftBranch.head;
                tail = root;
            }
            else if (leftBranch == null && rightBranch != null)
            {
                rightBranch.head.left = root;
                root.right = rightBranch.head;

                head = root;
                tail = rightBranch.tail;
            }

            return new NodePair(head, tail);
        }
    }
}