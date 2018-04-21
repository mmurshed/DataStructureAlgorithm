using System;
using System.Collections.Generic;

namespace Graph
{
    // Alternate implemented of depth first using stack. It's exactly the same
    // As the BreadthFirstSearch but using Stack instead of queue.
    public class DepthFirstSearchStack<V, E> : GraphSearch<V, E>
    {
        public override void Search(IGraph<V, E> graph, IVertex<V> root, IVisitor<IVertex<V>> vertexVisitor, IVisitor<IEdge<V, E>> edgeVisitor)
        {
            if (IsVisited(root))
                return;

            Stack<IVertex<V>> stack = new Stack<IVertex<V>>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (!IsVisited(vertex))
                {
                    vertexVisitor.PreVisit(vertex);
                    SetVisited(vertex);

                    foreach (var neighbour in graph.GetNeighbours(vertex))
                    {
                        edgeVisitor.Visit(graph.GetEdge(vertex, neighbour));
                        stack.Push(neighbour);
                    }
                }
            }
        }
    }
}
