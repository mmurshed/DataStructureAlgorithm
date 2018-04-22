using DataStructure.Graph;

namespace Algorithm.Graph
{
    /*
     * A graph is bipartite if it can be colored without conflicts while using 
     * only two colors. Bipartite graphs are important because they arise 
     * naturally in many applications. Consider the “had-sex-with” graph in a 
     * heterosexual world. Men have sex only with women, and vice versa. Thus, 
     * gender defines a legal two-coloring, in this simple model.
    */
    public class GraphCycle<V, E>
    {
        public bool TwoColor(IGraph<V, E> graph)
        {
            var search = new BreadthFirstSearch<V, E>();
            var vertexVisitor = new DummyVertexVisitor<V>();
            var edgeVisitor = new GraphCycleEdgeVisitor<V, E>(search);

            search.Search(graph, vertexVisitor, edgeVisitor);

            return edgeVisitor.HasCycle;
        }
    }
}
