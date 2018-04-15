using System;
using System.Collections.Generic;

namespace Graph
{
    // Alternate implemented of depth first using stack. It's exactly the same
    // As the BreadthFirstSearch but using Stack instead of queue.
    public class DepthFirstSearchStack<V, E> : GraphSearch<V, E>
    {
        public override void Search(IVertex<V> root, IVisitor<IVertex<V>> visitor)
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
                    visitor.PreVisit(vertex);
                    SetVisited(vertex);

                    foreach (var neighbour in vertex.Neighbours)
                    {
                        stack.Push(neighbour);
                    }
                }
            }
        }
    }
}
