using System.Collections.Generic;
using DataStructure.Graph;

namespace Algorithm.Graph
{
    public class TopologicalSortDFS<V, E>
    {
        public LinkedList<IVertex<V>> Sort(IGraph<V, E> graph)
        {
            DFSTopoSortVisitor<V> dfsTopV = new DFSTopoSortVisitor<V>();
            var edgeVisitor = new DummyEdgeVisitor<V, E>();
            GraphSearch<V, E> graphSearch = new DepthFirstSearch<V, E>();
            graphSearch.Search(graph, dfsTopV, edgeVisitor);
            return dfsTopV.TopologicalSortedList;
        }
    }
}
