using System;
using System.Collections.Generic;

namespace Algorithm.MicrosoftProblems
{
	// https://leetcode.com/problems/spiral-matrix/description/
    public class SpiralMatrix
    {
		public IList<int> SpiralOrder(int[,] matrix)
        {
			if (matrix == null || matrix.Length == 0)
				return new List<int>();
            int m = matrix.GetLength(0);
			int n = matrix.GetLength(1);

			var list = new List<int>(m * n);

			int i = 0;
			int j = 0;
			while(i < m && j < n)
			{
				SpiralOrder(matrix, i, m, j, n, list);
				i++; j++;
				m--; n--;
			}

			return list;
        }

		private void SpiralOrder(int[,] matrix, int i, int m, int j, int n, IList<int> list)
		{
			// Top
			for (int x = j; x < n; x++)
				list.Add(matrix[i, x]);

            // Right
			for (int y = i + 1; y < m; y++)
				list.Add(matrix[y, n - 1]);

			// Bottom
			if (i != m - 1)
			{
				for (int x = n - 2; x >= j && i < m; x--)
					list.Add(matrix[m - 1, x]);
			}

			// Left
			if (j != n - 1)
			{
				for (int y = m - 2; y > i && j < n; y--)
					list.Add(matrix[y, j]);
			}
		}
	}
}
