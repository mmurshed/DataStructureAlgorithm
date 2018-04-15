using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class GraphMatrix<V, E> : IGraph<V, E>
    {
        private List<IVertex<V>> vertices;
        public ICollection<IVertex<V>> Vertices => vertices;
        private IEdge<V, E>[,] Matrix;
        public int Size => Vertices.Count;

        public GraphMatrix(int count)
        {
            vertices = new List<IVertex<V>>(count);
            Matrix = new IEdge<V, E>[count, count];
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
            Matrix[edge.Start.ID, edge.End.ID] = edge;
        }

        public IVertex<V> GetVertex(uint ID)
        {
            return vertices[(int)ID];
        }

        public IEdge<V, E> GetEdge(IVertex<V> start, IVertex<V> end)
        {
            return Matrix[start.ID, end.ID];
        }

        public bool HasEdge(IVertex<V> start, IVertex<V> end)
        {
            return Matrix[start.ID, end.ID] != null;
        }
    }
}
