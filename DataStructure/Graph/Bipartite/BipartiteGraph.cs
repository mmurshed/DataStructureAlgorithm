using System;
using System.Collections.Generic;

namespace DataStructure.Graph.Algorithms
{
    /*
     * A graph is bipartite if it can be colored without conflicts while using 
     * only two colors. Bipartite graphs are important because they arise 
     * naturally in many appli- cations. Consider the “had-sex-with” graph in a 
     * heterosexual world. Men have sex only with women, and vice versa. Thus, 
     * gender defines a legal two-coloring, in this simple model.
    */
    public class BipartiteGraph<V, E>
    {
        public bool TwoColor(IGraph<V, E> graph)
        {
            var search = new BreadthFirstSearch<V, E>();
            var vertexVisitor = new DummyVertexVisitor<V>();
            var edgeVisitor = new BipartiteEdgeVisitor<V, E>(graph);

            foreach (var vertex in graph.Vertices)
            {
                if (!search.IsVisited(vertex))
                {
                    edgeVisitor.SetColor(vertex, BipartiteEdgeVisitor<V, E>.Color.White);
                    search.Search(graph, vertex, vertexVisitor, edgeVisitor);
                }
            }

            return edgeVisitor.IsBipartite;
        }
    }
}
