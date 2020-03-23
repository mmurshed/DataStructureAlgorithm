using System;
using System.Text;
using System.Collections.Generic;

namespace Algorithm.Facebook
{
    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class NodePair2
    {
        public TreeNode head;
        public TreeNode tail;
        public NodePair2(TreeNode h, TreeNode t)
        {
            head = h;
            tail = t;
        }
        public NodePair2() { }
    }

    public class TreeToLinkedList
    {
        public void Flatten(TreeNode root)
        {
            if (root == null)
                return;
            TreeToList(root);
        }

        private NodePair2 TreeToList(TreeNode root)
        {
            if(root.left == null && root.right == null)
            {
                return new NodePair2(root, root);
            }

            NodePair2 leftBranch = null;
            NodePair2 rightBranch = null;

            if (root.left != null)
            {
                leftBranch = TreeToList(root.left);
                
            }
            if (root.right != null)
            {
                rightBranch = TreeToList(root.right);
            }

            TreeNode tail = null;

            if (leftBranch != null && rightBranch != null)
            {
                root.right = leftBranch.head;

                leftBranch.tail.right = rightBranch.head;

                tail = rightBranch.tail;
            }
            else if(leftBranch != null && rightBranch == null)
            {
                root.right = leftBranch.head;

                tail = leftBranch.tail;
            }
            else if (leftBranch == null && rightBranch != null)
            {
                root.right = rightBranch.head;

                tail = rightBranch.tail;
            }

            root.left = null;

            return new NodePair2(root, tail);
        }
    }
}