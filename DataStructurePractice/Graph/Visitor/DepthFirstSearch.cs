using System;
using System.Collections.Generic;

namespace Graph
{
    public class DepthFirstSearch<V, E> : GraphSearch<V, E>
    {
        public override void Search(IVertex<V> root, IVisitor<IVertex<V>> visitor)
        {
            if (IsVisited(root))
                return;
            visitor.PreVisit(root);
            SetVisited(root);

            foreach (var neighbor in root.Neighbours)
            {
                Search(neighbor, visitor);
            }

            visitor.PostVisit(root);
        }
    }
}
