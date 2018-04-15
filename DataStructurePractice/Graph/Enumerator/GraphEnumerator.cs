using System;
using System.Collections;
using System.Collections.Generic;

namespace Graph
{
    public abstract class GraphEnumerator<V, E> : IEnumerator<IVertex2<V>>
    {
        protected readonly IGraph2<V, E> graph;
        private readonly HashSet<IVertex2<V>> visited = new HashSet<IVertex2<V>>();

        protected IEnumerator<IVertex2<V>> vertexEnumerator;
        protected IEnumerator<IVertex2<V>> searchEnumerator;

        public GraphEnumerator(IGraph2<V, E> graph)
        {
            this.graph = graph;
            vertexEnumerator = graph.Vertices.GetEnumerator();
        }

        protected IVertex2<V> current;
        object IEnumerator.Current => current;
        public IVertex2<V> Current => current;

        protected bool IsVisited(IVertex2<V> vertex)
        {
            return visited.Contains(vertex);
        }

        protected void SetVisited(IVertex2<V> vertex)
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

        protected abstract IEnumerable<IVertex2<V>> Search(IVertex2<V> root);
    }
}
