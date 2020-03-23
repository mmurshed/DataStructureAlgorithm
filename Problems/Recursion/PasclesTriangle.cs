using System.Collections.Generic;

namespace Problems.Recursion
{
    public class PasclesTriangle
    {
        public IList<int> GetRow(int rowIndex)
        {
            var l = new int[rowIndex + 1][];
            Get(l, rowIndex);
            return l[rowIndex];
        }

        /*
        1
        11
        121
        1331
        14641
        */
        public void Get(int[][] l, int r)
        {
            l[r] = new int[r + 1];

            if (r == 0)
            {
                l[0][0] = 1;
                return;
            }

            Get(l, r - 1);

            l[r][0] = l[r][r] = 1;
            for (int i = 1; i < r; i++)
                l[r][i] = l[r - 1][i - 1] + l[r - 1][i];
        }
    }
}
