using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class GraphLinked<V, E> : ILinkedGraph<V, E>
    {
        public ICollection<ILinkedVertex<V, E>> Vertices { get; }
        public int Size => Vertices.Count;

        public ICollection<IEdge<V, E>> Edges { get; } 

        public GraphLinked()
        {
            Vertices = new List<ILinkedVertex<V, E>>();
        }

        public void AddVertex(ILinkedVertex<V, E> vertex)
        {
            if (!Vertices.Contains(vertex))
            {
                Vertices.Add(vertex);
            }
        }

        public void AddEdge(IEdge<V, E> edge)
        {
            if(!Edges.Contains(edge))
            {
                Edges.Add(edge);
            }
        }
    }
}
