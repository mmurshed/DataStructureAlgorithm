using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Graph.Barebbone
{
    public class BareboneGraph
    {
        public int[][] adj;
        public int n;

        public BareboneGraph(int _n)
        {
            n = _n;
            adj = new int[n][];
        }

        public void AddChildren(int v, int[] c)
        {
            adj[v] = c;
        }

        private void PreProcessVertex(int x)
        {
        }

        private void PostProcessVertex(int x)
        {
        }

        private void ProcessEdge(int x, int y)
        {
        }

        private void BFS(int s, bool[] visited)
        {
            var q = new Queue<int>();

            q.Enqueue(s);

            while (q.Count > 0)
            {
                var m = q.Dequeue();
                if (visited[m])
                    continue;

                PreProcessVertex(m);

                foreach (var n in adj[m])
                {
                    ProcessEdge(m, n);

                    q.Enqueue(n);
                }

                visited[m] = true;
                PostProcessVertex(m);
            }
        }

        public void BFS()
        {
            var visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    BFS(i, visited);
                }
            }
        }

        private void DFSR(int s, bool[] visited)
        {

            if (visited[s])
                return;

            PreProcessVertex(s);

            foreach (var n in adj[s])
            {
                ProcessEdge(s, n);

                DFS(n, visited);
            }

            visited[s] = true;
            PostProcessVertex(s);
        }

        private void DFS(int s, bool[] visited)
        {
            var q = new Stack<int>();

            q.Push(s);

            while (q.Count > 0)
            {
                var m = q.Pop();
                if (visited[m])
                    continue;

                PreProcessVertex(m);

                foreach (var n in adj[m])
                {
                    ProcessEdge(m, n);

                    q.Push(n);
                }

                visited[m] = true;
                PostProcessVertex(m);
            }
        }

        public void DFS()
        {
            var visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    DFS(i, visited);
                }
            }
        }

    }
}
