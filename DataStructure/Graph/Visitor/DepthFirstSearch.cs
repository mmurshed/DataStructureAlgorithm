using System;
using System.Collections.Generic;

namespace DataStructure.Graph
{
    public class DepthFirstSearch<V, E> : GraphSearch<V, E>
    {
        public override void Search(IGraph<V, E> graph, IVertex<V> root, IVisitor<IVertex<V>> vertexVisitor, IVisitor<IEdge<V, E>> edgeVisitor)
        {
            if (IsVisited(root))
                return;
            vertexVisitor.PreVisit(root);
            SetVisited(root);

            foreach (var neighbor in graph.GetNeighbours(root))
            {
                edgeVisitor.Visit(graph.GetEdge(root, neighbor));
                Search(graph, neighbor, vertexVisitor, edgeVisitor);
            }

            vertexVisitor.PostVisit(root);
        }
    }
}
