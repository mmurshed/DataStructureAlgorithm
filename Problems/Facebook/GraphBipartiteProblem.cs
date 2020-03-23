using System;
using System.Collections.Generic;

namespace Algorithm.Facebook
{

    public class GraphBipartiteProblem
    {
        int[] color;
        bool bipartite;

        private void BFS(int[][] g, int s)
        {
            var visited = new bool[g.Length];

            var q = new Queue<int>();

            q.Enqueue(s);

            while (q.Count > 0)
            {
                var m = q.Dequeue();
                if (visited[m])
                    continue;

                foreach (var n in g[m])
                {
                    ProcessEdge(m, n);

                    q.Enqueue(n);
                }

                visited[m] = true;
            }
        }

        private void ProcessEdge(int x, int y)
        {
            if (color[x] == color[y])
                bipartite = false;

            color[y] = Complement(color[x]);
        }

        private int Complement(int c) => -1 * c;

        public bool IsBipartite(int[][] g)
        {
            // -1 BLACK
            // 0 UNCOLORED
            // 1 WHITE
            color = new int[g.Length];
            bipartite = true;


            for (int i = 0; i < g.Length; i++)
            {
                if (color[i] == 0) // Uncolored
                {
                    color[i] = 1; // White

                    BFS(g, i);
                }
            }

            return bipartite;
        }


    }
}
