using System.Collections.Generic;
using DataStructure.Graph;

namespace Algorithm.Graph.ShortestPath
{
    public class AllSourceShortestPath<V> : IShortestPath<V>
    {
        private const int INFINITY = 99999;
        private readonly IGraph<V, int> graph;

        public int[,] Distance { get; }
        public IVertex<V>[,] NextVertex { get; }

        public AllSourceShortestPath(IGraph<V, int> graph)
        {
            this.graph = graph;
            Distance = new int[graph.Size, graph.Size];
            NextVertex = new IVertex<V>[graph.Size, graph.Size];
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

        public int GetDistance(IVertex<V> u, IVertex<V> v)
        {
            return Distance[u.ID, v.ID];
        }

        public LinkedList<IVertex<V>> GetPath(IVertex<V> u, IVertex<V> v)
        {
            var path = new LinkedList<IVertex<V>>();
            if (NextVertex[u.ID, v.ID] == null)
                return path;

            path.AddLast(u);

            var next = u;

            while(next != v)
            {
                next = NextVertex[next.ID, v.ID];
                if (next == null)
                    break;
                path.AddLast(next);
            }

            return path;
        }
    }
}
