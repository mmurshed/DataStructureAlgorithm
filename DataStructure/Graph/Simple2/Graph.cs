using System.Collections.Generic;

namespace DataStructure.Graph.Simple2
{
    public class Graph
    {
        public readonly List<Vertex> Vertices;
        public readonly Dictionary<Edge, int> Edges;

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new Dictionary<Edge, int>();
        }

        public void Add(Vertex v)
        {
            Vertices.Add(v);
        }

        public void Add(Edge e)
        {
            Edges.Add(e, e.Weight);
            Vertices[e.First].Neighbours.Add(Vertices[e.Second]);
        }
    }
}
