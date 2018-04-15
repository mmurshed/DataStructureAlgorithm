using System;
using System.Collections.Generic;

namespace Graph
{
    public class BreadthFirstSearch<V, E> : GraphSearch<V, E>
    {
        public override void Search(IVertex<V> root, IVisitor<IVertex<V>> visitor)
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
                    visitor.PreVisit(vertex);
                    SetVisited(vertex);

                    foreach (var neighbour in vertex.Neighbours)
                    {
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }
    }
}
