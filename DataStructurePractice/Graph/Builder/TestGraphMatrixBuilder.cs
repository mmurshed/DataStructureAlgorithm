using System;

namespace Graph
{
    public class TestGraphMatrixBuilder : IGraphBuilder<string, int>
    {
        public IGraph<string, int> Graph { get; }

        public TestGraphMatrixBuilder()
        {
            Graph = new GraphMatrix<string, int>(6);
        }

/*
     6
 PO----LA
 |\   5/ \
 | \3 /   \10
7|  SF    LV
 | /       |
 |/2       |5
 SE        AU
*/
        public void Build()
        {
            var la = new Vertex<string>(0, "Los Angeles");
            var sf = new Vertex<string>(1, "San Francisco");
            var lv = new Vertex<string>(2, "Las Vegas");
            var se = new Vertex<string>(3, "Seattle");
            var au = new Vertex<string>(4, "Austin");
            var po = new Vertex<string>(5, "Portland");

            // la <=> sf, lv, po
            AddUndirectedEdge(la, sf, 5);
            AddUndirectedEdge(la, lv, 10);
            AddUndirectedEdge(la, po, 6);

            // sf <=> se, po
            AddUndirectedEdge(sf, se, 2);
            AddUndirectedEdge(sf, po, 3);

            // lv <=> au
            AddUndirectedEdge(lv, au, 5);

            // se <=> po
            AddUndirectedEdge(se, po, 7);
        }

        public void AddUndirectedEdge(IVertex<string> start, IVertex<string> end, int weight)
        {
            Graph.AddVertex(start);
            Graph.AddVertex(end);
            var ed1 = new Edge<string, int>(start, end, weight);
            var ed2 = new Edge<string, int>(end, start, weight);
            Graph.AddEdge(ed1);
            Graph.AddEdge(ed2);
        }

    }
}
