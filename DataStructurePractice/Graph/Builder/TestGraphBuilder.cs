using System;

namespace Graph
{
    public class TestGraphBuilder : IGraphBuilder<string, int>
    {
        public IGraph<string, int> Graph { get; }

        public TestGraphBuilder()
        {
            Graph = new GraphList<string, int>();
        }

        public void Build()
        {
            var la = new Vertex<string>("Los Angeles");
            var sf = new Vertex<string>("San Francisco");
            var lv = new Vertex<string>("Las Vegas");
            var se = new Vertex<string>("Seattle");
            var au = new Vertex<string>("Austin");
            var po = new Vertex<string>("Portland");

            // la <=> sf, lv, po
            AddUndirectedEdge(la, sf);
            AddUndirectedEdge(la, lv);
            AddUndirectedEdge(la, po);

            // sf <=> se, po
            AddUndirectedEdge(sf, se);
            AddUndirectedEdge(sf, po);

            // lv <=> au
            AddUndirectedEdge(lv, au);

            // se <=> po
            AddUndirectedEdge(se, po);
        }

        public void AddUndirectedEdge(IVertex<string> start, IVertex<string> end)
        {
            Graph.AddVertex(start);
            Graph.AddVertex(end);
            var ed1 = new Edge<string, int>(start, end, default(int));
            var ed2 = new Edge<string, int>(end, start, default(int));
            Graph.AddEdge(ed1);
            Graph.AddEdge(ed2);
        }

    }
}
