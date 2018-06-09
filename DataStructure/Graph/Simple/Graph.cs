using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Graph.Simple
{
    public class Graph
    {
        public readonly HashSet<int> Vertices;
        public readonly HashSet<Edge> Edges;
        private Dictionary<int, List<int>> adjacencyList;

        public int Size => Vertices.Count;

        public Graph()
        {
            Vertices = new HashSet<int>();
            Edges = new HashSet<Edge>();

            adjacencyList = new Dictionary<int, List<int>>();
        }

        public void AddVertex(int v)
        {
            Vertices.Add(v);
        }

        public void AddEdge(Edge e)
        {
            Edges.Add(e);

            if (!adjacencyList.ContainsKey(e.First))
                adjacencyList[e.First] = new List<int>();
            
            adjacencyList[e.First].Add(e.Second);
        }

        public IEnumerable<int> GetNeighbours(int v)
        {
            return adjacencyList[v];
        }
    }
}
