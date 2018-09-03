using System;
namespace Algorithm.Tree.Problems
{
    public class MaxSumPath
    {
        public int MaxPathSum(TreeNode root)
        {
            return MaxPathSumInternal1(root).Item2;
        }

        private Tuple<int, int> MaxPathSumInternal1(TreeNode root)
        {
            if (root == null)
                return new Tuple<int, int>(Int32.MinValue, Int32.MinValue);

            var left = MaxPathSumInternal1(root.left);
            var right = MaxPathSumInternal1(root.right);

            var leftMax = left.Item2;
            var rightMax = right.Item2;

            var leftPath = left.Item1;
            var rightPath = right.Item1;

            int path = Int32.MinValue;

            int max = Math.Max(leftMax, rightMax);

            if(leftPath == Int32.MinValue && rightPath == Int32.MinValue)
            {
                path = root.val;
            }
            else if(leftPath == Int32.MinValue)
            {
                int path1 = rightPath + root.val;
                int path2 = root.val;
                path = Math.Max(path1, path2);
            }
            else if(rightPath == Int32.MinValue)
            {
                int path1 = leftPath + root.val;
                int path2 = root.val;
                path = Math.Max(path1, path2);
            }
            else
            {
                int path1 = leftPath + root.val + rightPath;
                int path2 = leftPath + root.val;
                int path3 = root.val + rightPath;
                int path4 = root.val;
                path = Math.Max(path2, path3);
                path = Math.Max(path, path4);
                max = Math.Max(max, path1);
            }

            max = Math.Max(max, path);

            return new Tuple<int, int>(path, max);
        }

        private class PathMax{
            public int Path;
            public int Max;
            public PathMax(int p, int m)
            {
                Path = p;
                Max = m;
            }
        }

        private int Max3(int x, int y, int z)
        {
            return Math.Max(x, Math.Max(y, z));
        }

        private int Max4(int x, int y, int z, int p)
        {
            return Math.Max(Max3(x, y, z), p);
        }

        private int MIN = -99999;
        private PathMax MaxPathSumInternal(TreeNode root)
        {
            if (root == null)
                return new PathMax(MIN, MIN);

            var left = MaxPathSumInternal(root.left);
            var right = MaxPathSumInternal(root.right);

            int pathLeftExtended  = left.Path + root.val;
            int pathRightExtended =             root.val + right.Path;
            int pathStartHere = root.val;

            int maxPath = Max3(pathLeftExtended, pathRightExtended, pathStartHere);

            int pathAccross = left.Path + root.val + right.Path;

            int max = Max4(left.Max, right.Max, pathAccross, maxPath);

            return new PathMax(maxPath, max);
        }

    }
}
