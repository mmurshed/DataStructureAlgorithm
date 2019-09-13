using System;
using System.Text;
using System.Collections.Generic;

namespace Algorithm.FacebookProblems
{

    public class ValidateBinaryTree
    {
        // Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public class ResultColl
        {
            public bool valid;
            public int min;
            public int max;

            public ResultColl() { }
            public ResultColl(bool v, int mn, int mx)
            {
                valid = v;
                min = mn;
                max = mx;
            }
        }

        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
                return true;
            return IsValidBSTInternal(root).valid;
        }

        private ResultColl IsValidBSTInternal(TreeNode root)
        {
            if(root.left == null && root.right == null)
            {
                return new ResultColl(true, root.val, root.val);
            }

            ResultColl leftResult = null;
            ResultColl rightResult = null;

            if (root.left != null)
            {
                leftResult = IsValidBSTInternal(root.left);
                if (!leftResult.valid)
                    return leftResult;
            }
            if(root.right != null)
            {
                rightResult = IsValidBSTInternal(root.right);
                if (!rightResult.valid)
                    return rightResult;
            }

            if(leftResult != null && rightResult != null)
            {
                if (leftResult.max >= root.val)
                    return new ResultColl(false, 0, 0);
                if(rightResult.min <= root.val)
                    return new ResultColl(false, 0, 0);
                return new ResultColl(true, leftResult.min, rightResult.max);
            }
            else if (leftResult != null && rightResult == null)
            {
                if (leftResult.max >= root.val)
                    return new ResultColl(false, 0, 0);
                return new ResultColl(true, leftResult.min, root.val);
            }
            else
            {
                if (rightResult.min <= root.val)
                    return new ResultColl(false, 0, 0);
                return new ResultColl(true, root.val, rightResult.max);
            }

        }

    }
}