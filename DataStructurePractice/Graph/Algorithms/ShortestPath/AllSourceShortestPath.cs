using System;
using System.Collections.Generic;

namespace Graph.Algorithms
{
    public class AllSourceShortestPath<V> : IShortestPath<V>
    {
        private const int INFINITY = 99999;
        private readonly IGraph2<V, int> graph;

        public int[,] Distance { get; }
        public IVertex2<V>[,] NextVertex { get; }

        public AllSourceShortestPath(IGraph2<V, int> graph)
        {
            this.graph = graph;
            Distance = new int[graph.Size, graph.Size];
            NextVertex = new IVertex2<V>[graph.Size, graph.Size];
        }

        private void Init()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    Distance[i, j] = INFINITY;
                }
            }
            
            foreach (var u in graph.Vertices)
            {
                Distance[u.ID, u.ID] = 0;
            }

            foreach (var edge in graph.Edges)
            {
                Distance[edge.Start.ID, edge.End.ID] = edge.Value;
                NextVertex[edge.Start.ID, edge.End.ID] = edge.End;
            }
        }

        // Floyd-Warshall
        public void ShortestPath()
        {
            Init();

            for (int k = 0; k < graph.Size; k++)
            {
                for (int i = 0; i < graph.Size; i++)
                {
                    for (int j = 0; j < graph.Size; j++)
                    {
                        int newDistance = Distance[i, k] + Distance[k, j];
                        if(Distance[i,j] > newDistance)
                        {
                            Distance[i, j] = newDistance;
                            NextVertex[i, j] = NextVertex[i, k];
                        }
                    }
                }
            }
        }

        public int GetDistance(IVertex2<V> u, IVertex2<V> v)
        {
            return Distance[u.ID, v.ID];
        }

        public LinkedList<IVertex2<V>> GetPath(IVertex2<V> u, IVertex2<V> v)
        {
            var path = new LinkedList<IVertex2<V>>();
            if (NextVertex[u.ID, v.ID] == null)
                return path;

            path.AddLast(u);

            while(u != v)
            {
                u = NextVertex[u.ID, v.ID];
                if (u == null)
                    break;
                path.AddLast(u);
            }

            return path;
        }
    }
}
