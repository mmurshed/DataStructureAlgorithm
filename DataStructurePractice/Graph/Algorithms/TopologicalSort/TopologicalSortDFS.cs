using System;
using System.Collections.Generic;

namespace Graph.Algorithms
{
    public class TopologicalSortDFS<V, E>
    {
        public LinkedList<IVertex<V>> Sort(IGraph<V, E> graph)
        {
            DFSTopoSortVisitor<V> dfsTopV = new DFSTopoSortVisitor<V>();
            GraphSearch<V, E> graphSearch = new DepthFirstSearch<V, E>();
            graphSearch.Search(graph, dfsTopV);
            return dfsTopV.TopologicalSortedList;
        }
    }
}
