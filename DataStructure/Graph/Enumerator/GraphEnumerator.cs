using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public abstract class GraphEnumerator<V, E> : IEnumerator<IVertex<V>>
    {
        protected readonly IGraph<V, E> graph;
        private readonly HashSet<IVertex<V>> visited = new HashSet<IVertex<V>>();

        protected IEnumerator<IVertex<V>> vertexEnumerator;
        protected IEnumerator<IVertex<V>> searchEnumerator;

        public GraphEnumerator(IGraph<V, E> graph)
        {
            this.graph = graph;
            vertexEnumerator = graph.Vertices.GetEnumerator();
        }

        protected IVertex<V> current;
        object IEnumerator.Current => current;
        public IVertex<V> Current => current;

        protected bool IsVisited(IVertex<V> vertex)
        {
            return visited.Contains(vertex);
        }

        protected void SetVisited(IVertex<V> vertex)
        {
            visited.Add(vertex);
        }

        public void Dispose() { }

        public void Reset()
        {
            visited.Clear();
        }

        public bool MoveNext()
        {
            bool succeeded = false;

            if (searchEnumerator != null)
            {
                succeeded = searchEnumerator.MoveNext();
            }

            if (!succeeded)
            {
                while (vertexEnumerator.MoveNext())
                {
                    if (!IsVisited(vertexEnumerator.Current))
                        break;
                }

                if (vertexEnumerator.Current != null && !IsVisited(vertexEnumerator.Current))
                {
                    searchEnumerator = Search(vertexEnumerator.Current).GetEnumerator();
                    succeeded = searchEnumerator.MoveNext();
                }
            }

            if (succeeded)
            {
                current = searchEnumerator?.Current;
            }

			return succeeded;
        }

        protected abstract IEnumerable<IVertex<V>> Search(IVertex<V> root);
    }
}
