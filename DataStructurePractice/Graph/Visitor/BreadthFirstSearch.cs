using System;
using System.Collections.Generic;

namespace Graph
{
    public class BreadthFirstSearch<V, E> : GraphSearch<V, E>
    {
        public override void Search(IGraph<V, E> graph, IVertex<V> root, IVisitor<IVertex<V>> vertexVisitor, IVisitor<IEdge<V, E>> edgeVisitor)
        {
            if (IsVisited(root))
                return;

            Queue<IVertex<V>> queue = new Queue<IVertex<V>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (!IsVisited(vertex))
                {
                    vertexVisitor.PreVisit(vertex);
                    SetVisited(vertex);

                    foreach (var neighbour in graph.GetNeighbours(vertex))
                    {
                        edgeVisitor.Visit(graph.GetEdge(vertex, neighbour));
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }
    }
}
