using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class BreadthFirstEnumerator<V, E> : GraphEnumerator<V, E>
    {
        public BreadthFirstEnumerator(IGraph<V, E> graph) : base(graph) { }

        protected override IEnumerable<IVertex<V>> Search(IVertex<V> root)
        {
            if (IsVisited(root))
                yield break;
           
            var queue = new Queue<IVertex<V>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (!IsVisited(vertex))
                {
                    SetVisited(vertex);
                    yield return vertex;

                    foreach (var neighbour in graph.GetNeighbours(vertex))
                    {
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }
    }
}
