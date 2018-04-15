using System;

namespace Graph
{
    public class MSTGraphListBuilder : IGraphBuilder2<int, int>
    {
        public IGraph2<int, int> Graph { get; }

        public MSTGraphListBuilder()
        {
            Graph = new GraphList2<int, int>();
        }

        public void Build()
        {
            var _0 = new Vertex2<int>(0);
            var _1 = new Vertex2<int>(1);
            var _2 = new Vertex2<int>(2);
            var _3 = new Vertex2<int>(3);
            var _4 = new Vertex2<int>(4);
            var _5 = new Vertex2<int>(5);

            Graph.AddVertex(_0);
            Graph.AddVertex(_1);
            Graph.AddVertex(_2);
            Graph.AddVertex(_3);
            Graph.AddVertex(_4);
            Graph.AddVertex(_5);

            // 0 => 1 - 5
            AddEdge(_0, _1, 3);
            AddEdge(_0, _2, 3);
            AddEdge(_0, _3, 3);
            AddEdge(_0, _4, 3);
            AddEdge(_0, _5, 3);

            // 1 => 0, 2, 5
            AddEdge(_1, _0, 3);
            AddEdge(_1, _2, 2);
            AddEdge(_1, _5, 2);

            // 2 => 0, 1, 3, 4
            AddEdge(_2, _0, 3);
            AddEdge(_2, _1, 2);
            AddEdge(_2, _3, 4);
            AddEdge(_2, _4, 2);

            // 3 => 0, 2, 4
            AddEdge(_3, _0, 3);
            AddEdge(_3, _2, 4);
            AddEdge(_3, _4, 4);

            // 4 => 0, 2, 3, 5
            AddEdge(_4, _0, 3);
            AddEdge(_4, _2, 2);
            AddEdge(_4, _3, 4);
            AddEdge(_4, _5, 1);

            // 5 => 0, 1, 4
            AddEdge(_5, _0, 3);
            AddEdge(_5, _1, 2);
            AddEdge(_5, _4, 1);
        }

        public void AddEdge(IVertex2<int> start, IVertex2<int> end, int weight)
        {
            var edge = new Edge2<int, int>(start, end, weight);
            Graph.AddEdge(edge);
        }

    }
}
