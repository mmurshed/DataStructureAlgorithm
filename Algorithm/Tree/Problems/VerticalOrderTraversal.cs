using System;
using System.Collections.Generic;

namespace Algorithm.Tree.Problems
{
    /*
    Given a binary tree, return the vertical order traversal of its nodes' values. (ie, from top to bottom, column by column).

    If two nodes are in the same row and column, the order should be from left to right.

    Examples:
    Given binary tree [3,9,20,null,null,15,7],
        3
       / \
      9  20
        /  \
       15   7
    return its vertical order traversal as:
    [
      [9],
      [3,15],
      [20],
      [7]
    ]
    Given binary tree [3,9,20,4,5,2,7],
        _3_
       /   \
      9    20
     / \   / \
    4   5 2   7
    return its vertical order traversal as:
    [
      [4],
      [9],
      [3,5,2],
      [20],
      [7]
    ]
    */
    public class VerticalOrderTraversal
    {
        int min;
        int max;

        private Dictionary<int, List<int>> dict; 

        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            dict = new Dictionary<int, List<int>>();
            var list = new List<IList<int>>();
            min = Int32.MaxValue;
            max = Int32.MinValue;

            VerticalOrderDFS(root, 0);
            // VerticalOrderBFS(root);

            for (int i = min; i <= max; i++)
            {
                if(dict.ContainsKey(i))
                    list.Add(dict[i]);
            }

            return list;
        }

        private void VerticalOrderDFS(TreeNode root, int n)
        {
            if (root == null)
                return;
            min = Math.Min(min, n);
            max = Math.Max(max, n);

            if (dict.ContainsKey(n))
                dict[n].Add(root.val);
            else
                dict.Add(n, new List<int> { root.val });

            VerticalOrderDFS(root.left, n - 1);
            VerticalOrderDFS(root.right, n + 1);
        }

        private void VerticalOrderBFS(TreeNode root)
        {
            var q = new Queue<KeyValuePair<int, TreeNode>>();
            q.Enqueue(new KeyValuePair<int, TreeNode>(0, root));

            while (q.Count > 0)
            {
                var v = q.Dequeue();

                var n = v.Key;
                var node = v.Value;

                min = Math.Min(min, n);
                max = Math.Max(max, n);

                if (dict.ContainsKey(n))
                    dict[n].Add(node.val);
                else
                    dict.Add(n, new List<int> { node.val });

                if(node.left != null)
                    q.Enqueue(new KeyValuePair<int, TreeNode>(n - 1, node.left));
                if (node.right != null)
                    q.Enqueue(new KeyValuePair<int, TreeNode>(n + 1, node.right));
            }
        }
    }
}
