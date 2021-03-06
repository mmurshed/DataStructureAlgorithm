﻿using System;
using DataStructure.Graph;

namespace DataStructure.NUnit.Graph.Builder
{
    public class ShortestPathGraphListBuilder : IGraphBuilder<int, int>
    {
        public IGraph<int, int> Graph { get; }

        public ShortestPathGraphListBuilder()
        {
            Graph = new GraphList<int, int>();
        }

        public void Build()
        {
            var _0 = new Vertex<int>(0);
            var _1 = new Vertex<int>(1);
            var _2 = new Vertex<int>(2);
            var _3 = new Vertex<int>(3);
            var _4 = new Vertex<int>(4);

            Graph.AddVertex(_0);
            Graph.AddVertex(_1);
            Graph.AddVertex(_2);
            Graph.AddVertex(_3);
            Graph.AddVertex(_4);

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
            var edge = new Edge<int, int>(start, end, weight);
            Graph.AddEdge(edge);
        }

    }
}
