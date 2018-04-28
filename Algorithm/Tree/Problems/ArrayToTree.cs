using System;
namespace Algorithm.Tree.Problems
{
    public class ArrayToTree
    {
        public TreeNode Construct(int?[] array)
        {
            TreeNode root = null;
            if (array == null || array.Length == 0 || array[0] == null)
                return root;

            root = new TreeNode(array[0] ?? 0);

            Construct(array, 0, root);

            return root;
        }

        //  0  1    2             3
        //  0  1 2  3  4    5  6  7 8 9    10   11  12
        // [5, 4,8, 11,null,13,4, 7,2,null,null,null,1]
        private void Construct(int?[] array, int level, TreeNode cur)
        {
            if (cur == null)
                return;
            int i = 2 * level + 1;
            if (i >= array.Length)
                return;
            if (i < array.Length && array[i] != null)
            {
                cur.left = new TreeNode(array[i] ?? 0);
                Construct(array, i, cur.left);
            }
            i++;
            if (i < array.Length && array[i] != null)
            {
                cur.right = new TreeNode(array[i] ?? 0);
                Construct(array, i, cur.right);
            }
        }
    }
}
