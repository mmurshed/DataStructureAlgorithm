using System;

namespace DataStructure.NUnit.Graph.Builder
{
    public class ShortestPathGraphMatrixBuilder : IGraphBuilder<int, int>
    {
        public IGraph<int, int> Graph { get; }

        public ShortestPathGraphMatrixBuilder()
        {
            Graph = new GraphMatrix<int, int>(5);
        }

        public void Build()
        {
            var _0 = new Vertex<int>(0, 0);
            var _1 = new Vertex<int>(1, 1);
            var _2 = new Vertex<int>(2, 2);
            var _3 = new Vertex<int>(3, 3);
            var _4 = new Vertex<int>(4, 4);

            // 0 => 1, 2, 4
            AddEdge(_0, _1, 5);
            AddEdge(_0, _2, 3);
            AddEdge(_0, _4, 2);

            // 1 => 2, 3
            AddEdge(_1, _2, 2);
            AddEdge(_1, _3, 6);

            // 2 => 1, 3
            AddEdge(_2, _1, 1);
            AddEdge(_2, _3, 2);

            // 3 => None

            // 4 => 1, 2, 3
            AddEdge(_4, _1, 6);
            AddEdge(_4, _2, 10);
            AddEdge(_4, _3, 4);
        }

        public void AddEdge(IVertex<int> start, IVertex<int> end, int weight)
        {
            Graph.AddVertex(start);
            Graph.AddVertex(end);
            var edge = new Edge<int, int>(start, end, weight);
            Graph.AddEdge(edge);
        }

    }
}
