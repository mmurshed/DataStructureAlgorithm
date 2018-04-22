using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure.Graph.Deprecated
{
    public class GraphListWeighted<V, E> : IGraph<V, E>
    {
        private List<IVertex<V>> vertices;
        public ICollection<IVertex<V>> Vertices => vertices;
        public int Size => Vertices.Count;
        public IDictionary<IEdge<V, E>, IEdge<V, E>> Edges { get; }

        public GraphListWeighted()
        {
            vertices = new List<IVertex<V>>();
            Edges = new Dictionary<IEdge<V, E>, IEdge<V, E>>();
        }

        public void AddVertex(IVertex<V> vertex)
        {
            if (!Vertices.Contains(vertex))
            {
                Vertices.Add(vertex);
            }
        }

        public void AddEdge(IEdge<V, E> edge)
        {
            if (!edge.Start.Neighbours.Contains(edge.End))
            {
                edge.Start.Neighbours.Add(edge.End);
            }
            Edges.Add(edge, edge);
        }

        public IVertex<V> GetVertex(uint ID)
        {
            return vertices[(int)ID];
        }

        public IEdge<V, E> GetEdge(IVertex<V> start, IVertex<V> end)
        {
            var index = new Edge<V, E>(start, end);
            return Edges[index];
        }

        public bool HasEdge(IVertex<V> start, IVertex<V> end)
        {
            var index = new Edge<V, E>(start, end);
            return Edges.ContainsKey(index);
        }
    }
}
