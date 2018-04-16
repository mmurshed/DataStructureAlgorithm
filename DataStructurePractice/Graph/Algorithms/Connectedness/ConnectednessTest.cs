using System;
using System.Collections.Generic;

namespace Graph.Algorithms
{
    public class ConnectednessTest<V, E>
    {
        public int FindPartitions(IGraph<V, E> graph)
        {
            int partitions = 0;
            var search = new BreadthFirstSearch<V, E>();
            var vertexVisitor = new DummyVertexVisitor<V>();
            var edgeVisitor = new DummyEdgeVisitor<V, E>();

            foreach (var vertex in graph.Vertices)
            {
                if (!search.IsVisited(vertex))
                {
                    partitions++;
                    search.Search(graph, vertex, vertexVisitor, edgeVisitor);
                }
            }

            return partitions;
        }
    }
}
