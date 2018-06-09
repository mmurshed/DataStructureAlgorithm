using System.Collections.Generic;

namespace DataStructure.Graph.Simple2
{
    public class Graph
    {
        public readonly List<Vertex> Vertices;
        public readonly List<Edge> Edges;

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }

        public void AddVertex(Vertex v)
        {
            Vertices.Add(v);
        }

        public void AddEdge(Edge e)
        {
            Edges.Add(e);
            Vertices[e.First].Neighbours.Add(e.Second);
        }
    }
}
