using System.Collections.Generic;
using DataStructure.Graph;

namespace Algorithm.Graph
{
    /*
PropositionF. ReversepostorderinaDAGisatopologicalsort.
Proof: Consider any edge v->w. One of the following three cases must hold when dfs(v) is called (see the diagram on page 583):
■ dfs(w) has already been called and has returned (w is marked).
■ dfs(w) has not yet been called (w is unmarked), so v->w will cause dfs(w) to
be called (and return), either directly or indirectly, before dfs(v) returns.
■ dfs(w) has been called and has not yet returned when dfs(v) is called. The
key to the proof is that this case is impossible in a DAG, because the recursive call chain implies a path from w to v and v->w would complete a directed cycle.
In the two possible cases, dfs(w) is done before dfs(v), so w appears before v in postorder and after v in reverse postorder. Thus, each edge v->w points from a ver- tex earlier in the order to a vertex later in the order, as desired.
    */
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
