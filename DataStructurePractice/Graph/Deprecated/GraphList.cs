using System;
using System.Collections;
using System.Collections.Generic;

namespace Graph.Deprecated
{
    public class GraphList<V, E> : IGraph<V, E>
    {
        private List<IVertex<V>> vertices;
        public ICollection<IVertex<V>> Vertices => vertices;
        public int Size => Vertices.Count;

        public GraphList()
        {
            vertices = new List<IVertex<V>>();
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
        }

        public IVertex<V> GetVertex(uint ID)
        {
            return vertices[(int)ID];
        }

        public IEdge<V, E> GetEdge(IVertex<V> start, IVertex<V> end)
        {
            throw new NotImplementedException();
        }

        public bool HasEdge(IVertex<V> start, IVertex<V> end)
        {
            throw new NotImplementedException();
        }
    }
}
