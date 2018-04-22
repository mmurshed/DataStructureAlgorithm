using System;
using DataStructure.Graph;

namespace DataStructure.NUnit.Graph.Builder
{
    public class TopoGraphListBuilder : IGraphBuilder<int, int>
    {
        public IGraph<int, int> Graph { get; }

        public TopoGraphListBuilder()
        {
            Graph = new GraphList<int, int>();
        }

        public void Build()
        {
            var _0 = new Vertex<int>(0, 0);
            var _1 = new Vertex<int>(1, 1);
            var _2 = new Vertex<int>(2, 2);
            var _3 = new Vertex<int>(3, 3);
            var _4 = new Vertex<int>(4, 4);
            var _5 = new Vertex<int>(5, 5);
            var _6 = new Vertex<int>(6, 6);
            var _7 = new Vertex<int>(7, 7);
            var _8 = new Vertex<int>(8, 8);
            var _9 = new Vertex<int>(9, 9);

            // 0 => 1, 5
            AddEdge(_0, _1);
            AddEdge(_0, _5);

            // 1 => 7
            AddEdge(_1, _7);

            // 3 => 2, 4, 7, 8
            AddEdge(_3, _2);
            AddEdge(_3, _4);
            AddEdge(_3, _7);
            AddEdge(_3, _8);

            // 4 => 8
            AddEdge(_4, _8);

            // 6 => 0, 1, 2
            AddEdge(_6, _0);
            AddEdge(_6, _1);
            AddEdge(_6, _2);

            // 8 => 2, 7
            AddEdge(_8, _2);
            AddEdge(_8, _7);

            // 9 => 4
            AddEdge(_9, _4);
        }

        public void AddEdge(IVertex<int> start, IVertex<int> end)
        {
            Graph.AddVertex(start);
            Graph.AddVertex(end);
            var edge = new Edge<int, int>(start, end, default(int));
            Graph.AddEdge(edge);
        }

    }
}
