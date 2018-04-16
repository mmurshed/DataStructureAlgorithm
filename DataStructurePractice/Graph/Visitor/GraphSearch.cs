using System;
using System.Collections.Generic;

namespace Graph
{
    public abstract class GraphSearch<V, E>
    {
        private readonly HashSet<IVertex<V>> visited = new HashSet<IVertex<V>>();

        public void Search(IGraph<V, E> graph, IVisitor<IVertex<V>> vextexVisitor, IVisitor<IEdge<V, E>> edgeVisitor)
        {
            visited.Clear();
            foreach (var vertex in graph.Vertices)
            {
                Search(graph, vertex, vextexVisitor, edgeVisitor);
            }
        }

        public bool IsVisited(IVertex<V> vertex)
        {
            return visited.Contains(vertex);
        }

        public void SetVisited(IVertex<V> vertex)
        {
            visited.Add(vertex);
        }

        public abstract void Search(IGraph<V, E> graph, IVertex<V> root, IVisitor<IVertex<V>> vertexVisitor, IVisitor<IEdge<V, E>> edgeVisitor);
    }
}
