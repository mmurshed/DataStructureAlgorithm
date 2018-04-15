using System;
using System.Collections.Generic;

namespace Graph
{
    public abstract class GraphSearch<V, E>
    {
        private readonly HashSet<IVertex<V>> visited = new HashSet<IVertex<V>>();
        public void Search(IGraph<V, E> graph, IVisitor<IVertex<V>> visitor)
        {
            visited.Clear();
            foreach (var vertex in graph.Vertices)
            {
                Search(vertex, visitor);
            }
        }

        protected bool IsVisited(IVertex<V> vertex)
        {
            return visited.Contains(vertex);
        }

        protected void SetVisited(IVertex<V> vertex)
        {
            visited.Add(vertex);
        }

        public abstract void Search(IVertex<V> root, IVisitor<IVertex<V>> visitor);
    }
}
